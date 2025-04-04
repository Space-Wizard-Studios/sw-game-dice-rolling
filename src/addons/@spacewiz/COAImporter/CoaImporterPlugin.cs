using Godot;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace DiceRolling.Editor;

/// <summary>
/// A plugin for importing Cutout Animation Tools generated JSON files into Godot scenes.
/// </summary>
[Tool]
public partial class CoaImporterPlugin : EditorPlugin {
    // UI Elements
    private Button? _openImporter;
    private ConfirmationDialog? _importWindow;
    private AcceptDialog? _warningDialog;
    private Button? _btnLoadJson;
    private Button? _btnDstFile;
    private EditorFileDialog? _srcDialog;
    private EditorFileDialog? _dstDialog;
    private Node2D? _srcScene;
    private Node2D? _dstScene;

    // UI Labels
    private Label? _labelSrcScene;
    private Label? _labelDstScene;
    private RichTextLabel? _jsonInfo;
    private CheckBox? _checkMerge;

    // State tracking
    private int _boneCount = 0;
    private int _spriteCount = 0;
    private Dictionary<string, object>? _jsonData;
    private string _jsonPath = string.Empty;
    private string _fileDstPath = string.Empty;
    private DirAccess? _dir;

    /// <summary>
    /// Data structures for COA (Cutout Animation) format
    /// </summary>
    public class CoaData {
        public string Name { get; set; } = string.Empty;
        public List<string>? Changelog { get; set; }
        public List<CoaNode> Nodes { get; set; } = [];
        public List<CoaAnimation> Animations { get; set; } = [];
    }

    public class CoaNode {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public float[] Position { get; set; } = new float[2];
        public float[] PositionTip { get; set; } = new float[2];
        public float Rotation { get; set; }
        public float[] Scale { get; set; } = new float[2];
        public int Z { get; set; }
        public float[] Offset { get; set; } = new float[2];
        public float[] PivotOffset { get; set; } = new float[2];
        public bool BoneConnected { get; set; }
        public bool DrawBone { get; set; }
        public int TilesX { get; set; } = 1;
        public int TilesY { get; set; } = 1;
        public int FrameIndex { get; set; }
        public string ResourcePath { get; set; } = string.Empty;
        public List<CoaNode>? Children { get; set; }
    }

    public class CoaAnimation {
        public string Name { get; set; } = string.Empty;
        public float Length { get; set; }
        public float Fps { get; set; }
        public Dictionary<string, Dictionary<string, CoaKeyframe>> Keyframes { get; set; } = [];
    }

    public class CoaKeyframe {
        public object Value { get; set; } = null!;
    }

    /// <summary>
    /// Called when the plugin enters the scene tree.
    /// </summary>
    public override void _EnterTree() {
        // Load the import dialog from the scene file
        // var importWindowRes = GD.Load<PackedScene>("res://addons/@spacewiz/COAImporter/import_dialog.tscn");
        // _importWindow = importWindowRes.Instantiate<ConfirmationDialog>();
        // _importWindow.Confirmed += CreateImportedScene;

        // Get references to UI elements in the dialog
        // _jsonInfo = _importWindow.GetNode<RichTextLabel>("json_info/text");
        // _checkMerge = _importWindow.GetNode<CheckBox>("check_merge_scenes");
        // _labelDstScene = _importWindow.GetNode<Label>("path_destination_file/label");
        // _labelSrcScene = _importWindow.GetNode<Label>("path_source_file/label");
        // _warningDialog = _importWindow.GetNode<AcceptDialog>("warning_dialog");

        // Check if scene file exists
        string scenePath = "res://addons/@spacewiz/COAImporter/import_dialog.tscn";
        if (!Godot.FileAccess.FileExists(scenePath)) {
            GD.PrintErr($"COA Importer: Scene file not found at {scenePath}");
            // Try alternative path from original plugin
            scenePath = "res://addons/coa_importer/import_dialog.tscn";
            if (Godot.FileAccess.FileExists(scenePath)) {
                GD.Print($"COA Importer: Found scene at alternative path {scenePath}");
            }
            else {
                GD.PrintErr("COA Importer: Could not find import dialog scene file");
                return;
            }
        }

        // Load the import dialog from the scene file
        try {
            var importWindowRes = GD.Load<PackedScene>(scenePath);
            if (importWindowRes == null) {
                GD.PrintErr($"COA Importer: Failed to load PackedScene from {scenePath}");
                return;
            }

            _importWindow = importWindowRes.Instantiate<ConfirmationDialog>();
            _importWindow.Visible = false;

            if (_importWindow == null) {
                GD.PrintErr("COA Importer: Failed to instantiate dialog as ConfirmationDialog");
                return;
            }

            // Hide child dialogs to prevent conflicts
            if (_importWindow.HasNode("file_source")) {
                var fileSource = _importWindow.GetNode<Window>("Container/file_source");
                fileSource.Visible = false;
            }
            if (_importWindow.HasNode("file_destination")) {
                var fileDest = _importWindow.GetNode<Window>("Container/file_destination");
                fileDest.Visible = false;
            }
            if (_importWindow.HasNode("warning_dialog")) {
                var warningDialog = _importWindow.GetNode<AcceptDialog>("Container/warning_dialog");
                if (_warningDialog != null) {
                    _warningDialog.Exclusive = false;
                    _warningDialog.Visible = false;
                }
            }

            GD.Print("COA Importer: Dialog instantiated successfully");
            _importWindow.Confirmed += CreateImportedScene;

            // Get references to UI elements in the dialog - verify each node exists
            _jsonInfo = _importWindow.GetNodeOrNull<RichTextLabel>("Container/json_info_section/json_info");
            if (_jsonInfo == null) GD.PrintErr("COA Importer: Could not find node 'json_info_section/json_info'");

            _checkMerge = _importWindow.GetNodeOrNull<CheckBox>("Container/check_merge_scenes");
            if (_checkMerge == null) GD.PrintErr("COA Importer: Could not find node 'check_merge_scenes'");

            _labelDstScene = _importWindow.GetNodeOrNull<Label>("Container/path_destination_section/path_destination_file");
            if (_labelDstScene == null) GD.PrintErr("COA Importer: Could not find node 'path_destination_section/path_destination_file'");

            _labelSrcScene = _importWindow.GetNodeOrNull<Label>("Container/path_source_section/path_source_file");
            if (_labelSrcScene == null) GD.PrintErr("COA Importer: Could not find node 'path_source_section/path_source_file'");

            // Create and setup source file dialog
            _srcDialog = new EditorFileDialog {
                Access = EditorFileDialog.AccessEnum.Filesystem,
                FileMode = EditorFileDialog.FileModeEnum.OpenFile
            };
            _srcDialog.AddFilter("*.json");
            _srcDialog.FileSelected += SrcDialogConfirm;
            EditorInterface.Singleton.GetBaseControl().AddChild(_srcDialog);

            // Create and setup destination file dialog
            _dstDialog = new EditorFileDialog {
                Access = EditorFileDialog.AccessEnum.Resources,
                FileMode = EditorFileDialog.FileModeEnum.SaveFile
            };
            _dstDialog.AddFilter("*.tscn");
            _dstDialog.AddFilter("*.scn");
            _dstDialog.FileSelected += DstDialogConfirm;
            EditorInterface.Singleton.GetBaseControl().AddChild(_dstDialog);

            // Add import window to the editor
            EditorInterface.Singleton.GetBaseControl().AddChild(_importWindow);
            _importWindow.GetOkButton().Text = "Import";
            _importWindow.Visible = false;

            // Connect UI buttons
            _btnLoadJson = _importWindow.GetNode<Button>("Container/button_source");
            _btnLoadJson.Pressed += OpenSrcDialog;

            _btnDstFile = _importWindow.GetNode<Button>("Container/button_destination");
            _btnDstFile.Pressed += OpenDstDialog;

            // Create and add the "Import COA File" button to the editor
            _openImporter = new Button {
                Text = "Import COA File"
            };
            _openImporter.Pressed += OpenImporter;
            AddControlToContainer(CustomControlContainer.CanvasEditorMenu, _openImporter);


        }
        catch (Exception e) {
            GD.PrintErr($"COA Importer: Exception during scene loading: {e.Message}");
            GD.PrintErr(e.StackTrace);
        }
    }

    // Method declarations for button callbacks
    private void OpenImporter() {
        // Hide any potential active dialogs first
        if (_srcDialog != null && _srcDialog.Visible)
            _srcDialog.Hide();
        if (_dstDialog != null && _dstDialog.Visible)
            _dstDialog.Hide();

        // Position and show the main dialog
        Vector2I windowSize = DisplayServer.WindowGetSize(0);
        Vector2I dialogSize = _importWindow!.Size;
        Vector2I position = windowSize / 2 - dialogSize / 2;
        _importWindow.Position = position;

        _jsonInfo!.Clear();

        // Update dialog content if needed
        if (!string.IsNullOrEmpty(_jsonPath))
            SrcDialogConfirm(_jsonPath);
        if (!string.IsNullOrEmpty(_fileDstPath))
            DstDialogConfirm(_fileDstPath);

        // Finally, show the dialog
        _importWindow.PopupCentered();
    }

    private void OpenSrcDialog() {
        _jsonInfo!.MouseFilter = Control.MouseFilterEnum.Ignore;
        _srcDialog!.PopupCentered();
        _srcScene = null;
    }

    private void OpenDstDialog() {
        _jsonInfo!.MouseFilter = Control.MouseFilterEnum.Ignore;
        _dstDialog!.PopupCentered();
        _dstScene = null;
    }

    // Dialog confirmation handlers - these will be implemented in later steps
    private void SrcDialogConfirm(string path) {
        _jsonInfo!.Clear();
        _jsonInfo.MouseFilter = Control.MouseFilterEnum.Stop;
        _jsonPath = path;

        if (Godot.FileAccess.FileExists(_jsonPath)) {
            // Read and parse JSON file
            var json = Godot.FileAccess.Open(_jsonPath, Godot.FileAccess.ModeFlags.Read);
            var content = json.GetAsText();

            // Convert from generic JsonElement to our custom types
            _ = new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true,
                ReadCommentHandling = JsonCommentHandling.Skip
            };

            try {
                // Parse the JSON document using System.Text.Json
                var jsonDoc = JsonDocument.Parse(content);
                string name = jsonDoc.RootElement.GetProperty("name").GetString() ?? "unnamed";

                // Create a new empty scene
                _dir = DirAccess.Open("res://");

                _srcScene?.Free();

                _srcScene = new Node2D {
                    Name = name
                };

                // Convert the JSON data to our custom data model
                _jsonData = new Dictionary<string, object>();
                _jsonData["name"] = name;

                if (jsonDoc.RootElement.TryGetProperty("nodes", out var nodesElement))
                    _jsonData["nodes"] = ConvertJsonArrayToDictionary(nodesElement);

                if (jsonDoc.RootElement.TryGetProperty("animations", out var animationsElement))
                    _jsonData["animations"] = ConvertJsonArrayToDictionary(animationsElement);

                if (jsonDoc.RootElement.TryGetProperty("changelog", out var changelogElement))
                    _jsonData["changelog"] = ConvertJsonArrayToDictionary(changelogElement);

                // Display the JSON info in the UI
                WriteLog(_jsonInfo, "Json import File Information");
                _jsonInfo.Newline();

                // Display changelog if available
                if (_jsonData.TryGetValue("changelog", out object? value)) {
                    WriteLog(_jsonInfo, "#### Changelog ####");
                    var changelog = value as Dictionary<string, object>;

                    foreach (var log in changelog!.Values)
                        WriteLog(_jsonInfo, log.ToString() ?? string.Empty);

                    _jsonInfo.Newline();
                }

                // Display node information
                WriteLog(_jsonInfo, "#### Node Information ####");
                WriteLog(_jsonInfo, $"Name: {name}");

                // Create a preview of the nodes (without copying images)
                _spriteCount = 0;
                _boneCount = 0;

                Dictionary<string, object> nodes = _jsonData["nodes"] as Dictionary<string, object> ?? new Dictionary<string, object>();
                CreateNodes(nodes, _srcScene, _srcScene, false);

                WriteLog(_jsonInfo, $"Sprite Count: {_spriteCount}", 0);
                WriteLog(_jsonInfo, $"Bone Count:   {_boneCount}", 0);

                // Preview animations
                if (_jsonData.ContainsKey("animations")) {
                    Dictionary<string, object> animations = _jsonData["animations"] as Dictionary<string, object> ?? new Dictionary<string, object>();
                    ImportAnimations(animations, _srcScene);
                }

                _labelSrcScene!.Text = _jsonPath;
            }
            catch (Exception e) {
                ShowWarningDialog("Error", $"Failed to parse JSON file: {e.Message}");
            }
        }
    }

    private Dictionary<string, object> ConvertJsonArrayToDictionary(JsonElement element) {
        Dictionary<string, object> result = [];

        if (element.ValueKind == JsonValueKind.Array) {
            int index = 0;
            foreach (var item in element.EnumerateArray()) {
                result[index.ToString()] = ConvertJsonElementToObject(item);
                index++;
            }
        }
        else if (element.ValueKind == JsonValueKind.Object) {
            foreach (var property in element.EnumerateObject()) {
                result[property.Name] = ConvertJsonElementToObject(property.Value);
            }
        }

        return result;
    }

    private object ConvertJsonElementToObject(JsonElement element) {
        switch (element.ValueKind) {
            case JsonValueKind.Object:
                return ConvertJsonArrayToDictionary(element);
            case JsonValueKind.Array:
                Dictionary<string, object> arrayDict = [];
                int index = 0;
                foreach (var item in element.EnumerateArray()) {
                    arrayDict[index.ToString()] = ConvertJsonElementToObject(item);
                    index++;
                }
                return arrayDict;
            case JsonValueKind.String:
                return element.GetString() ?? string.Empty;
            case JsonValueKind.Number:
                if (element.TryGetInt32(out int intValue))
                    return intValue;
                return element.GetDouble();
            case JsonValueKind.True:
                return true;
            case JsonValueKind.False:
                return false;
            case JsonValueKind.Null:
                return null!;
            default:
                return string.Empty;
        }
    }

    private static void WriteLog(RichTextLabel textField, string msg, int indent = 0, bool lineBreak = false) {
        textField.PushIndent(indent);

        if (lineBreak)
            textField.Newline();

        textField.AddText(msg);
    }

    // Stub for methods that will be implemented later
    private void CreateNodes(Dictionary<string, object> nodesDict, Node parent, Node subparent, bool copyImages = true, int depth = 0) {
        DirAccess? dir2 = DirAccess.Open("res://");

        foreach (var nodeObj in nodesDict.Values) {
            if (nodeObj is not Dictionary<string, object> node) continue;

            Node2D? newNode = null;
            Vector2 offset = Vector2.Zero;

            // Get node offset if available
            if (node.TryGetValue("offset", out object? offsetObj) && offsetObj is Dictionary<string, object> offsetDict) {
                float x = GetFloatValue(offsetDict, "0", 0);
                float y = GetFloatValue(offsetDict, "1", 0);
                offset = new Vector2(x, y);
            }

            // Check node type and create appropriate node
            string type = node.TryGetValue("type", out object? typeObj) ? typeObj.ToString() ?? string.Empty : string.Empty;

            if (type == "BONE") {
                _boneCount++;
                newNode = new Node2D();
                newNode.SetMeta("imported_from_blender", true);
                newNode.Name = node.TryGetValue("name", out object? nameObj) ? nameObj.ToString() ?? "Bone" : "Bone";

                // Set position
                if (node.TryGetValue("position", out object? posObj) && posObj is Dictionary<string, object> posDict) {
                    float x = GetFloatValue(posDict, "0", 0);
                    float y = GetFloatValue(posDict, "1", 0);
                    newNode.Position = new Vector2(x, y);
                }

                // Set rotation
                if (node.TryGetValue("rotation", out object? rotObj)) {
                    newNode.Rotation = Convert.ToSingle(rotObj);
                }

                // Set scale
                if (node.TryGetValue("scale", out object? scaleObj) && scaleObj is Dictionary<string, object> scaleDict) {
                    float x = GetFloatValue(scaleDict, "0", 1);
                    float y = GetFloatValue(scaleDict, "1", 1);
                    newNode.Scale = new Vector2(x, y);
                }

                // Set z-index
                if (node.TryGetValue("z", out object? zObj)) {
                    newNode.ZIndex = Convert.ToInt32(zObj);
                }

                // Add to parent
                subparent.AddChild(newNode);
                newNode.Owner = parent;

                // Handle bone connection
                bool boneConnected = node.TryGetValue("bone_connected", out object? boneConnObj) && Convert.ToBoolean(boneConnObj);
                if (newNode.GetParent() != null && boneConnected) {
                    newNode.SetMeta("_edit_bone_", true);
                }

                // Create bone tail node if necessary
                bool drawBone = node.TryGetValue("draw_bone", out object? drawBoneObj) && Convert.ToBoolean(drawBoneObj);
                if (!HasBoneChild(node) || drawBone) {
                    Node2D drawBoneNode = new Node2D();
                    drawBoneNode.SetMeta("_edit_bone_", true);
                    drawBoneNode.Name = $"{newNode.Name}_tail";

                    if (node.TryGetValue("position_tip", out object? tipPosObj) && tipPosObj is Dictionary<string, object> tipPosDict) {
                        float x = GetFloatValue(tipPosDict, "0", 0);
                        float y = GetFloatValue(tipPosDict, "1", 0);
                        drawBoneNode.Position = new Vector2(x, -y); // Note y is negated
                    }

                    drawBoneNode.Hide();
                    newNode.AddChild(drawBoneNode);
                    drawBoneNode.Owner = parent;
                }
            }
            else if (type == "SPRITE") {
                _spriteCount++;
                newNode = new Sprite2D();

                // Handle resource copying if needed
                if (copyImages && !string.IsNullOrEmpty(_jsonPath)) {
                    if (node.TryGetValue("resource_path", out object? resPathObj)) {
                        string resourcePath = resPathObj.ToString() ?? string.Empty;

                        // Copy texture and assign to sprite
                        Texture2D? texture = CopyAndLoadTexture(resourcePath);
                        if (texture != null) {
                            ((Sprite2D)newNode).Texture = texture;
                        }
                        else {
                            // Log the error but continue
                            WriteLog(_jsonInfo!, $"Failed to load texture: {resourcePath}", 0, true);
                        }
                    }
                }

                // Set sprite properties
                newNode.SetMeta("imported_from_blender", true);
                newNode.Name = node.TryGetValue("name", out object? nameObj) ? nameObj.ToString() ?? "Sprite" : "Sprite";

                // Set sprite frame properties
                ((Sprite2D)newNode).Hframes = node.TryGetValue("tiles_x", out object? tilesXObj) ? Convert.ToInt32(tilesXObj) : 1;
                ((Sprite2D)newNode).Vframes = node.TryGetValue("tiles_y", out object? tilesYObj) ? Convert.ToInt32(tilesYObj) : 1;
                ((Sprite2D)newNode).Frame = node.TryGetValue("frame_index", out object? frameObj) ? Convert.ToInt32(frameObj) : 0;
                ((Sprite2D)newNode).Centered = false;

                // Set pivot offset
                if (node.TryGetValue("pivot_offset", out object? pivotObj) && pivotObj is Dictionary<string, object> pivotDict) {
                    float x = GetFloatValue(pivotDict, "0", 0);
                    float y = GetFloatValue(pivotDict, "1", 0);
                    ((Sprite2D)newNode).Offset = new Vector2(x, y);
                }

                // Set position, add offset
                if (node.TryGetValue("position", out object? posObj) && posObj is Dictionary<string, object> posDict) {
                    float x = GetFloatValue(posDict, "0", 0) + offset.X;
                    float y = GetFloatValue(posDict, "1", 0) + offset.Y;
                    newNode.Position = new Vector2(x, y);
                }

                // Set rotation
                if (node.TryGetValue("rotation", out object? rotObj)) {
                    newNode.Rotation = Convert.ToSingle(rotObj);
                }

                // Set scale
                if (node.TryGetValue("scale", out object? scaleObj) && scaleObj is Dictionary<string, object> scaleDict) {
                    float x = GetFloatValue(scaleDict, "0", 1);
                    float y = GetFloatValue(scaleDict, "1", 1);
                    newNode.Scale = new Vector2(x, y);
                }

                // Set z-index
                if (node.TryGetValue("z", out object? zObj)) {
                    newNode.ZIndex = Convert.ToInt32(zObj);
                }

                // Add to parent
                subparent.AddChild(newNode);
                newNode.Owner = parent;
            }

            // Process children recursively
            if (newNode != null && node.TryGetValue("children", out object? childrenObj) &&
                childrenObj is Dictionary<string, object> children && children.Count > 0) {
                CreateNodes(children, parent, newNode, copyImages, depth + 1);
            }
        }
    }

    private static bool HasBoneChild(Dictionary<string, object> node) {
        if (node.TryGetValue("children", out object? childrenObj) && childrenObj is Dictionary<string, object> children) {
            foreach (var itemObj in children.Values) {
                if (itemObj is Dictionary<string, object> item) {
                    if (item.TryGetValue("type", out object? typeObj) &&
                        typeObj.ToString() == "BONE") {
                        return true;
                    }

                    if (HasBoneChild(item)) {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    // Helper to safely extract float values from dictionaries
    private static float GetFloatValue(Dictionary<string, object> dict, string key, float defaultValue) {
        if (dict.TryGetValue(key, out object? value)) {
            try {
                return Convert.ToSingle(value);
            }
            catch {
                return defaultValue;
            }
        }
        return defaultValue;
    }

    private void ImportAnimations(Dictionary<string, object> animations, Node ownerNode) {
        // Create animation player node
        var animPlayer = new AnimationPlayer();
        ownerNode.AddChild(animPlayer);
        animPlayer.Owner = ownerNode;
        animPlayer.Name = "AnimationPlayer";

        // Log animation count
        int count = animations.Count;
        WriteLog(_jsonInfo!, $"Animation Count: {count}");

        if (count > 0)
            WriteLog(_jsonInfo!, "#### Animations ####", 0, true);

        // Create a single animation library for all animations
        var library = new AnimationLibrary();

        // Process each animation
        foreach (var animObj in animations.Values) {
            if (animObj is not Dictionary<string, object> anim)
                continue;

            // Extract animation properties
            string name = anim.TryGetValue("name", out object? nameObj) ? nameObj.ToString() ?? "Animation" : "Animation";
            float length = anim.TryGetValue("length", out object? lengthObj) ? Convert.ToSingle(lengthObj) : 1.0f;
            float fps = anim.TryGetValue("fps", out object? fpsObj) ? Convert.ToSingle(fpsObj) : 30.0f;

            // Log animation info
            WriteLog(_jsonInfo!, $"> {name}:   length - {length}    fps - {fps}");
            GD.Print($"Processing animation: {name}, length: {length}, fps: {fps}");

            // Create animation resource
            var animData = new Animation();
            animData.LoopMode = Animation.LoopModeEnum.Linear;
            animData.Length = length;

            // Process keyframes
            if (anim.TryGetValue("keyframes", out object? keyframesObj) && keyframesObj is Dictionary<string, object> keyframes) {
                foreach (var entry in keyframes) {
                    string key = entry.Key;

                    if (entry.Value is Dictionary<string, object> track) {
                        // In Godot 4, we use the Value track type for all 2D properties
                        int idx = animData.AddTrack(Animation.TrackType.Value);

                        // Set the track path
                        animData.TrackSetPath(idx, key);

                        // Determine the track update mode based on path
                        Animation.UpdateMode updateMode = Animation.UpdateMode.Continuous;
                        Animation.InterpolationType interpolation = Animation.InterpolationType.Linear;

                        if (key.Contains("/frame") || key.Contains(":frame")) {
                            // Frame updates should be discrete
                            updateMode = Animation.UpdateMode.Discrete;
                            interpolation = Animation.InterpolationType.Nearest;
                        }

                        // Apply the determined settings
                        // Change from TrackSetUpdateMode to ValueTrackSetUpdateMode
                        animData.ValueTrackSetUpdateMode(idx, updateMode);
                        animData.TrackSetInterpolationType(idx, interpolation);

                        // Add keyframes to track
                        foreach (var timeEntry in track) {
                            if (!float.TryParse(timeEntry.Key, out float time))
                                continue;

                            if (timeEntry.Value is Dictionary<string, object> keyframe &&
                                keyframe.TryGetValue("value", out object? valueObj)) {

                                // Handle Vector2/Vector3 values
                                if (valueObj is Dictionary<string, object> vectorDict) {
                                    float x = GetFloatValue(vectorDict, "0", 0);
                                    float y = GetFloatValue(vectorDict, "1", 0);

                                    if (key.EndsWith("/pos") || key.EndsWith("/position")) {
                                        animData.TrackInsertKey(idx, time, new Vector2(x, y));
                                    }
                                    else if (key.EndsWith("/scale")) {
                                        animData.TrackInsertKey(idx, time, new Vector2(x, y));
                                    }
                                    else if (key.EndsWith("/rot") || key.EndsWith("/rotation")) {
                                        animData.TrackInsertKey(idx, time, x);
                                    }
                                    else if (valueObj.ToString()!.Contains(",")) {
                                        // Likely a color or vector
                                        animData.TrackInsertKey(idx, time, new Vector2(x, y));
                                    }
                                }
                                // Handle scalar values
                                else if (valueObj is float floatVal || float.TryParse(valueObj.ToString(), out floatVal)) {
                                    animData.TrackInsertKey(idx, time, floatVal);
                                }
                                else if (valueObj is double doubleVal) {
                                    animData.TrackInsertKey(idx, time, (float)doubleVal);
                                }
                                else if (valueObj is bool boolVal) {
                                    animData.TrackInsertKey(idx, time, boolVal ? 1.0f : 0.0f);
                                }
                                else {
                                    // Convert to Variant explicitly using Variant.From
                                    animData.TrackInsertKey(idx, time, Variant.From(valueObj.ToString() ?? ""));
                                }
                            }
                        }
                    }
                }
            }

            // Add animation to the library
            if (!library.HasAnimation(name)) {
                try {
                    library.AddAnimation(name, animData);
                    GD.Print($"Successfully added animation: {name} to library");
                }
                catch (Exception ex) {
                    GD.PrintErr($"Failed to add animation {name}: {ex.Message}");
                }
            }

            // Record animation in metadata
            animPlayer.SetMeta(name, true);
        }

        // Add the library to the animation player
        try {
            animPlayer.AddAnimationLibrary("", library);
            // TODO
            // GD.Print($"Added animation library with {library.GetAnimationList().Length} animations");
            // GD.Print($"Added animation library with {library.GetAnimationList().Length} animations");
        }
        catch (Exception ex) {
            GD.PrintErr($"Failed to add animation library: {ex.Message}");
        }

        animPlayer.ClearCaches();
    }

    /// <summary>
    /// Handles copying texture files from source to destination
    /// </summary>
    private Texture2D? CopyAndLoadTexture(string resourcePath) {
        if (string.IsNullOrEmpty(_jsonPath) || string.IsNullOrEmpty(resourcePath)) {
            return null;
        }

        try {
            string spriteDirPath = _fileDstPath.GetBaseDir();
            string spritesFolder = Path.Combine(spriteDirPath, "sprites");
            string resourceDir = Path.GetDirectoryName(resourcePath) ?? string.Empty;
            string targetResourceDir = Path.Combine(spritesFolder, resourceDir).Replace("\\", "/");

            // Create sprites directory and any subdirectories
            EnsureDirectoryExists(targetResourceDir);

            // Setup source and destination paths
            string srcPath = Path.Combine(_jsonPath.GetBaseDir(), resourcePath).Replace("\\", "/");
            string dstPath = Path.Combine(spriteDirPath, resourcePath).Replace("\\", "/");

            // Copy the sprite file
            if (Godot.FileAccess.FileExists(srcPath)) {
                _dir?.Copy(srcPath, dstPath);

                // Load and return the texture
                return GD.Load<Texture2D>(GetResourcePath(spriteDirPath, resourcePath));
            }
        }
        catch (Exception e) {
            GD.PushError($"Failed to copy texture: {e.Message}");
        }

        return null;
    }

    /// <summary>
    /// Ensures a directory and all its parent directories exist
    /// </summary>
    private void EnsureDirectoryExists(string directory) {
        if (string.IsNullOrEmpty(directory)) return;

        // Convert to project path format
        directory = directory.Replace("\\", "/");

        if (_dir == null) {
            _dir = DirAccess.Open("res://");
        }

        if (!_dir.DirExists(directory)) {
            // Create parent directory first
            string parentDir = Path.GetDirectoryName(directory)?.Replace("\\", "/") ?? string.Empty;
            if (!string.IsNullOrEmpty(parentDir)) {
                EnsureDirectoryExists(parentDir);
            }

            // Create directory
            _dir.MakeDir(directory);
        }
    }

    /// <summary>
    /// Converts an absolute path to a resource path usable with GD.Load
    /// </summary>
    private static string GetResourcePath(string basePath, string relativePath) {
        if (basePath.StartsWith("res://")) {
            return Path.Combine(basePath, relativePath).Replace("\\", "/");
        }

        // Get project directory path
        string projectDir = ProjectSettings.GlobalizePath("res://");

        if (basePath.StartsWith(projectDir)) {
            // Already absolute path in project
            return Path.Combine(basePath, relativePath).Replace("\\", "/");
        }
        else {
            // Convert to resource path
            string fullPath = Path.Combine(basePath, relativePath).Replace("\\", "/");
            if (fullPath.StartsWith(projectDir)) {
                return fullPath.Replace(projectDir, "res://");
            }
        }

        // Fallback - just combine as-is
        return Path.Combine(basePath, relativePath).Replace("\\", "/");
    }

    private void DstDialogConfirm(string path) {
        _jsonInfo!.MouseFilter = Control.MouseFilterEnum.Stop;
        _fileDstPath = path;
        _labelDstScene!.Text = _fileDstPath;

        if (Godot.FileAccess.FileExists(_fileDstPath)) {
            var dstSceneRes = GD.Load<PackedScene>(_fileDstPath);
            _dstScene = dstSceneRes.Instantiate<Node2D>();
        }
    }

    private void CreateImportedScene() {
        if (string.IsNullOrEmpty(_fileDstPath) || string.IsNullOrEmpty(_jsonPath)) {
            ShowWarningDialog("Error", "Please select both source JSON and destination file paths");
            return;
        }

        // Free the source scene if it exists
        if (_srcScene != null) {
            _srcScene.Free();
        }

        // Handle merging with existing scene if needed
        if (_dstScene != null && _checkMerge!.ButtonPressed) {
            _srcScene = new Node2D {
                Name = _dstScene.Name
            };
            // Replace is improperly used here - we'll properly implement MergeScenes later
            // For now, we'll just keep the destination scene's name
        }
        else {
            _srcScene = new Node2D();
        }

        // Set scene name
        if (_jsonData != null && _jsonData.TryGetValue("name", out object? nameObj)) {
            _srcScene.Name = nameObj.ToString() ?? "ImportedScene";
        }

        // Create nodes from JSON data
        if (_jsonData != null && _jsonData.TryGetValue("nodes", out object? nodesObj) &&
            nodesObj is Dictionary<string, object> nodes) {
            CreateNodes(nodes, _srcScene, _srcScene, true);
        }

        // Import animations if available
        if (_jsonData != null && _jsonData.TryGetValue("animations", out object? animsObj) &&
            animsObj is Dictionary<string, object> animations) {
            ImportAnimations(animations, _srcScene);
        }

        // Handle scene merging or direct saving
        if (_dstScene != null && _checkMerge!.ButtonPressed) {
            SavePackedScene(MergeScenes(_srcScene, _dstScene));
            CleanupTemporaryFiles();
            _importWindow!.Hide();
        }
        else {
            SavePackedScene(_srcScene);
            CleanupTemporaryFiles();
            _importWindow!.Hide();
        }

        ShowWarningDialog("Info", "Import complete, please reload scene.");
    }

    // Save scene to file
    private void SavePackedScene(Node scene) {
        // Clear animation caches if there's an animation player
        if (scene.HasNode("AnimationPlayer")) {
            var animPlayer = scene.GetNode<AnimationPlayer>("AnimationPlayer");
            animPlayer.ClearCaches();
        }

        // Pack the scene and save
        var outfile = new PackedScene();
        outfile.Pack(scene);
        ResourceSaver.Save(outfile, _fileDstPath);
    }

    private void CleanupTemporaryFiles() {
        if (string.IsNullOrEmpty(_fileDstPath))
            return;

        // Get the directory of the destination file
        string directory = Path.GetDirectoryName(_fileDstPath) ?? string.Empty;
        if (string.IsNullOrEmpty(directory))
            return;

        string resourceDir = ProjectSettings.GlobalizePath(directory);

        try {
            // Open the directory
            DirAccess dir = DirAccess.Open(resourceDir);
            if (dir == null)
                return;

            // Get all files in the directory
            dir.ListDirBegin();
            string fileName = dir.GetNext();

            while (!string.IsNullOrEmpty(fileName)) {
                // Check if file is a temporary file
                if (!dir.CurrentIsDir() && fileName.EndsWith(".tmp")) {
                    // Delete the temporary file
                    GD.Print($"Cleaning up temporary file: {fileName}");
                    Error err = dir.Remove(fileName);
                    if (err != Error.Ok) {
                        GD.PushError($"Failed to delete temporary file: {fileName}, error: {err}");
                    }
                }
                fileName = dir.GetNext();
            }
            dir.ListDirEnd();
        }
        catch (Exception e) {
            GD.PrintErr($"Error cleaning up temporary files: {e.Message}");
        }
    }

    /// <summary>
    /// Merges two scenes, preserving hierarchy and transferring properties from source to destination
    /// </summary>
    /// <param name="srcScene">Source scene with new data to merge</param>
    /// <param name="dstScene">Destination scene to merge into</param>
    /// <returns>The merged scene</returns>
    private static Node MergeScenes(Node srcScene, Node dstScene) {
        // Preserve the destination scene name
        string originalName = dstScene.Name;

        // Copy scene-level metadata and properties from source to destination
        foreach (var metaKey in srcScene.GetMetaList()) {
            if (!dstScene.HasMeta(metaKey)) {
                dstScene.SetMeta(metaKey, srcScene.GetMeta(metaKey));
            }
        }

        // Process children nodes
        Dictionary<string, Node> dstChildren = new Dictionary<string, Node>();
        foreach (var child in dstScene.GetChildren()) {
            dstChildren[child.Name] = child;
        }

        // Process all source children
        foreach (var srcChild in srcScene.GetChildren()) {
            if (dstChildren.TryGetValue(srcChild.Name, out Node? dstChild)) {
                // Node with same name exists - merge recursively
                if (srcChild is Node2D srcNode2D && dstChild is Node2D dstNode2D) {
                    MergeNode2DProperties(srcNode2D, dstNode2D);

                    // If source has children, merge them too
                    if (srcChild.GetChildCount() > 0) {
                        MergeChildren(srcChild, dstChild, dstScene);
                    }
                }
                else if (srcChild is AnimationPlayer srcAnimPlayer && dstChild is AnimationPlayer dstAnimPlayer) {
                    // Special handling for AnimationPlayer
                    MergeAnimationPlayers(srcAnimPlayer, dstAnimPlayer);
                }
            }
            else {
                // Node doesn't exist in destination - copy it
                Node newNode = srcChild.Duplicate((int)(Node.DuplicateFlags.Scripts | Node.DuplicateFlags.Signals));
                dstScene.AddChild(newNode);
                newNode.Owner = dstScene;

                // Transfer ownership of all children to destination scene
                SetOwnerRecursive(newNode, dstScene);
            }
        }

        // Restore original name
        dstScene.Name = originalName;

        return dstScene;
    }

    /// <summary>
    /// Merges Node2D specific properties
    /// </summary>
    private static void MergeNode2DProperties(Node2D src, Node2D dst) {
        // Transfer basic Node2D properties
        dst.Position = src.Position;
        dst.Rotation = src.Rotation;
        dst.Scale = src.Scale;
        dst.ZIndex = src.ZIndex;

        // Transfer metadata
        foreach (var metaKey in src.GetMetaList()) {
            if (!dst.HasMeta(metaKey)) {
                dst.SetMeta(metaKey, src.GetMeta(metaKey));
            }
        }

        // Special handling for specific node types
        if (src is Sprite2D srcSprite && dst is Sprite2D dstSprite) {
            MergeSpriteProperties(srcSprite, dstSprite);
        }
    }

    /// <summary>
    /// Merges Sprite2D specific properties
    /// </summary>
    private static void MergeSpriteProperties(Sprite2D src, Sprite2D dst) {
        // Only update texture if source has one
        if (src.Texture != null) {
            dst.Texture = src.Texture;
        }

        dst.Hframes = src.Hframes;
        dst.Vframes = src.Vframes;
        dst.Frame = src.Frame;
        dst.Offset = src.Offset;
        dst.Centered = src.Centered;
    }

    /// <summary>
    /// Merges AnimationPlayer contents
    /// </summary>
    private static void MergeAnimationPlayers(AnimationPlayer src, AnimationPlayer dst) {
        // Get all animation libraries and animations from source
        foreach (var libraryName in src.GetAnimationLibraryList()) {
            AnimationLibrary srcLibrary = src.GetAnimationLibrary(libraryName);
            AnimationLibrary? dstLibrary = null;

            // Create or get destination library
            if (!dst.HasAnimationLibrary(libraryName)) {
                dstLibrary = new AnimationLibrary();
                dst.AddAnimationLibrary(libraryName, dstLibrary);
            }
            else {
                dstLibrary = dst.GetAnimationLibrary(libraryName);
            }

            // Add or replace animations in the destination
            foreach (var animName in srcLibrary.GetAnimationList()) {
                Animation srcAnim = srcLibrary.GetAnimation(animName);

                // If animation already exists, decide whether to replace or keep it
                if (dstLibrary.HasAnimation(animName)) {
                    // Option: Keep existing animation if desired
                    // For this implementation we'll replace with new animation
                    dstLibrary.RemoveAnimation(animName);
                }

                // Add the animation from source
                dstLibrary.AddAnimation(animName, srcAnim);

                // Transfer any metadata about this animation
                foreach (var metaKey in src.GetMetaList()) {
                    if (metaKey.ToString() == animName && !dst.HasMeta(metaKey)) {
                        dst.SetMeta(metaKey, src.GetMeta(metaKey));
                    }
                }
            }
        }

        // Clear animation player caches
        dst.ClearCaches();
    }

    /// <summary>
    /// Merges child nodes recursively
    /// </summary>
    private static void MergeChildren(Node srcParent, Node dstParent, Node owner) {
        Dictionary<string, Node> dstChildren = new Dictionary<string, Node>();
        foreach (var child in dstParent.GetChildren()) {
            dstChildren[child.Name] = child;
        }

        // Process source children
        foreach (var srcChild in srcParent.GetChildren()) {
            if (dstChildren.TryGetValue(srcChild.Name, out Node? dstChild)) {
                // Child exists in destination - merge recursively
                if (srcChild is Node2D srcNode2D && dstChild is Node2D dstNode2D) {
                    MergeNode2DProperties(srcNode2D, dstNode2D);

                    if (srcChild.GetChildCount() > 0) {
                        MergeChildren(srcChild, dstChild, owner);
                    }
                }
            }
            else {
                // Child doesn't exist - add it
                Node newNode = srcChild.Duplicate((int)(Node.DuplicateFlags.Scripts | Node.DuplicateFlags.Signals));
                dstParent.AddChild(newNode);
                newNode.Owner = owner; // Set owner to the main scene

                // Set ownership recursively
                SetOwnerRecursive(newNode, owner);
            }
        }
    }

    /// <summary>
    /// Sets the owner of a node and all its children recursively
    /// </summary>
    private static void SetOwnerRecursive(Node node, Node owner) {
        foreach (var child in node.GetChildren()) {
            child.Owner = owner;
            SetOwnerRecursive(child, owner);
        }
    }

    /// <summary>
    /// Shows a warning dialog with a title and message
    /// </summary>
    private void ShowWarningDialog(string title = "", string msg = "") {
        _warningDialog!.PopupCentered();

        if (!string.IsNullOrEmpty(msg))
            _warningDialog.DialogText = msg;

        if (!string.IsNullOrEmpty(title))
            _warningDialog.Title = title;
    }

    /// <summary>
    /// Called when the plugin exits the scene tree.
    /// </summary>
    public override void _ExitTree() {
        // Properly disconnect all signals before freeing nodes
        if (_importWindow != null) {
            _importWindow.Confirmed -= CreateImportedScene;
        }

        if (_srcDialog != null) {
            _srcDialog.FileSelected -= SrcDialogConfirm;
        }

        if (_dstDialog != null) {
            _dstDialog.FileSelected -= DstDialogConfirm;
        }

        if (_btnLoadJson != null) {
            _btnLoadJson.Pressed -= OpenSrcDialog;
        }

        if (_btnDstFile != null) {
            _btnDstFile.Pressed -= OpenDstDialog;
        }

        if (_openImporter != null) {
            _openImporter.Pressed -= OpenImporter;
            RemoveControlFromContainer(CustomControlContainer.CanvasEditorMenu, _openImporter);
            _openImporter.QueueFree();
            _openImporter = null;
        }

        if (_srcDialog != null) {
            _srcDialog.QueueFree();
            _srcDialog = null;
        }

        if (_dstDialog != null) {
            _dstDialog.QueueFree();
            _dstDialog = null;
        }

        if (_importWindow != null) {
            _importWindow.QueueFree();
            _importWindow = null;
        }
    }
}