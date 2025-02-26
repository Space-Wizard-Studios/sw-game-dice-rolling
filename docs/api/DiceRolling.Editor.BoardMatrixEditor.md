# <a id="DiceRolling_Editor_BoardMatrixEditor"></a> Class BoardMatrixEditor

Namespace: [DiceRolling.Editor](DiceRolling.Editor.md)  
Assembly: dice\-rolling.dll  

Manages a grid configuration for a target.

```csharp
[Tool]
[ScriptPath("res://addons/@spacewiz/TargetBoardEditorPlugin/BoardMatrixEditor.cs")]
public class BoardMatrixEditor : Control, IDisposable
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
GodotObject ← 
Node ← 
CanvasItem ← 
Control ← 
[BoardMatrixEditor](DiceRolling.Editor.BoardMatrixEditor.md)

#### Implements

[IDisposable](https://learn.microsoft.com/dotnet/api/system.idisposable)

#### Inherited Members

Control.NotificationResized, 
Control.NotificationMouseEnter, 
Control.NotificationMouseExit, 
Control.NotificationMouseEnterSelf, 
Control.NotificationMouseExitSelf, 
Control.NotificationFocusEnter, 
Control.NotificationFocusExit, 
Control.NotificationThemeChanged, 
Control.NotificationScrollBegin, 
Control.NotificationScrollEnd, 
Control.NotificationLayoutDirectionChanged, 
Control.\_CanDropData\(Vector2, Variant\), 
Control.\_DropData\(Vector2, Variant\), 
Control.\_GetDragData\(Vector2\), 
Control.\_GetMinimumSize\(\), 
Control.\_GetTooltip\(Vector2\), 
Control.\_GuiInput\(InputEvent\), 
Control.\_HasPoint\(Vector2\), 
Control.\_MakeCustomTooltip\(string\), 
Control.\_StructuredTextParser\(Array, string\), 
Control.AcceptEvent\(\), 
Control.GetMinimumSize\(\), 
Control.GetCombinedMinimumSize\(\), 
Control.SetAnchorsPreset\(Control.LayoutPreset, bool\), 
Control.SetOffsetsPreset\(Control.LayoutPreset, Control.LayoutPresetMode, int\), 
Control.SetAnchorsAndOffsetsPreset\(Control.LayoutPreset, Control.LayoutPresetMode, int\), 
Control.SetAnchor\(Side, float, bool, bool\), 
Control.SetAnchorAndOffset\(Side, float, float, bool\), 
Control.SetBegin\(Vector2\), 
Control.SetEnd\(Vector2\), 
Control.SetPosition\(Vector2, bool\), 
Control.SetSize\(Vector2, bool\), 
Control.ResetSize\(\), 
Control.SetGlobalPosition\(Vector2, bool\), 
Control.GetBegin\(\), 
Control.GetEnd\(\), 
Control.GetParentAreaSize\(\), 
Control.GetScreenPosition\(\), 
Control.GetRect\(\), 
Control.GetGlobalRect\(\), 
Control.HasFocus\(\), 
Control.GrabFocus\(\), 
Control.ReleaseFocus\(\), 
Control.FindPrevValidFocus\(\), 
Control.FindNextValidFocus\(\), 
Control.FindValidFocusNeighbor\(Side\), 
Control.BeginBulkThemeOverride\(\), 
Control.EndBulkThemeOverride\(\), 
Control.AddThemeIconOverride\(StringName, Texture2D\), 
Control.AddThemeStyleboxOverride\(StringName, StyleBox\), 
Control.AddThemeFontOverride\(StringName, Font\), 
Control.AddThemeFontSizeOverride\(StringName, int\), 
Control.AddThemeColorOverride\(StringName, Color\), 
Control.AddThemeConstantOverride\(StringName, int\), 
Control.RemoveThemeIconOverride\(StringName\), 
Control.RemoveThemeStyleboxOverride\(StringName\), 
Control.RemoveThemeFontOverride\(StringName\), 
Control.RemoveThemeFontSizeOverride\(StringName\), 
Control.RemoveThemeColorOverride\(StringName\), 
Control.RemoveThemeConstantOverride\(StringName\), 
Control.GetThemeIcon\(StringName, StringName\), 
Control.GetThemeStylebox\(StringName, StringName\), 
Control.GetThemeFont\(StringName, StringName\), 
Control.GetThemeFontSize\(StringName, StringName\), 
Control.GetThemeColor\(StringName, StringName\), 
Control.GetThemeConstant\(StringName, StringName\), 
Control.HasThemeIconOverride\(StringName\), 
Control.HasThemeStyleboxOverride\(StringName\), 
Control.HasThemeFontOverride\(StringName\), 
Control.HasThemeFontSizeOverride\(StringName\), 
Control.HasThemeColorOverride\(StringName\), 
Control.HasThemeConstantOverride\(StringName\), 
Control.HasThemeIcon\(StringName, StringName\), 
Control.HasThemeStylebox\(StringName, StringName\), 
Control.HasThemeFont\(StringName, StringName\), 
Control.HasThemeFontSize\(StringName, StringName\), 
Control.HasThemeColor\(StringName, StringName\), 
Control.HasThemeConstant\(StringName, StringName\), 
Control.GetThemeDefaultBaseScale\(\), 
Control.GetThemeDefaultFont\(\), 
Control.GetThemeDefaultFontSize\(\), 
Control.GetParentControl\(\), 
Control.GetTooltip\(Vector2?\), 
Control.GetCursorShape\(Vector2?\), 
Control.ForceDrag\(Variant, Control\), 
Control.GrabClickFocus\(\), 
Control.SetDragForwarding\(Callable, Callable, Callable\), 
Control.SetDragPreview\(Control\), 
Control.IsDragSuccessful\(\), 
Control.WarpMouse\(Vector2\), 
Control.UpdateMinimumSize\(\), 
Control.IsLayoutRtl\(\), 
Control.EmitSignalResized\(\), 
Control.EmitSignalGuiInput\(InputEvent\), 
Control.EmitSignalMouseEntered\(\), 
Control.EmitSignalMouseExited\(\), 
Control.EmitSignalFocusEntered\(\), 
Control.EmitSignalFocusExited\(\), 
Control.EmitSignalSizeFlagsChanged\(\), 
Control.EmitSignalMinimumSizeChanged\(\), 
Control.EmitSignalThemeChanged\(\), 
Control.InvokeGodotClassMethod\(in godot\_string\_name, NativeVariantPtrArgs, out godot\_variant\), 
Control.HasGodotClassMethod\(in godot\_string\_name\), 
Control.HasGodotClassSignal\(in godot\_string\_name\), 
Control.ClipContents, 
Control.CustomMinimumSize, 
Control.LayoutDirection, 
Control.AnchorLeft, 
Control.AnchorTop, 
Control.AnchorRight, 
Control.AnchorBottom, 
Control.OffsetLeft, 
Control.OffsetTop, 
Control.OffsetRight, 
Control.OffsetBottom, 
Control.GrowHorizontal, 
Control.GrowVertical, 
Control.Size, 
Control.Position, 
Control.GlobalPosition, 
Control.Rotation, 
Control.RotationDegrees, 
Control.Scale, 
Control.PivotOffset, 
Control.SizeFlagsHorizontal, 
Control.SizeFlagsVertical, 
Control.SizeFlagsStretchRatio, 
Control.LocalizeNumeralSystem, 
Control.AutoTranslate, 
Control.TooltipText, 
Control.TooltipAutoTranslateMode, 
Control.FocusNeighborLeft, 
Control.FocusNeighborTop, 
Control.FocusNeighborRight, 
Control.FocusNeighborBottom, 
Control.FocusNext, 
Control.FocusPrevious, 
Control.FocusMode, 
Control.MouseFilter, 
Control.MouseForcePassScrollEvents, 
Control.MouseDefaultCursorShape, 
Control.ShortcutContext, 
Control.Theme, 
Control.ThemeTypeVariation, 
Control.Resized, 
Control.GuiInput, 
Control.MouseEntered, 
Control.MouseExited, 
Control.FocusEntered, 
Control.FocusExited, 
Control.SizeFlagsChanged, 
Control.MinimumSizeChanged, 
Control.ThemeChanged, 
CanvasItem.NotificationTransformChanged, 
CanvasItem.NotificationLocalTransformChanged, 
CanvasItem.NotificationDraw, 
CanvasItem.NotificationVisibilityChanged, 
CanvasItem.NotificationEnterCanvas, 
CanvasItem.NotificationExitCanvas, 
CanvasItem.NotificationWorld2DChanged, 
CanvasItem.\_Draw\(\), 
CanvasItem.GetCanvasItem\(\), 
CanvasItem.IsVisibleInTree\(\), 
CanvasItem.Show\(\), 
CanvasItem.Hide\(\), 
CanvasItem.QueueRedraw\(\), 
CanvasItem.MoveToFront\(\), 
CanvasItem.DrawLine\(Vector2, Vector2, Color, float, bool\), 
CanvasItem.DrawDashedLine\(Vector2, Vector2, Color, float, float, bool, bool\), 
CanvasItem.DrawPolyline\(Vector2\[\], Color, float, bool\), 
CanvasItem.DrawPolyline\(ReadOnlySpan<Vector2\>, Color, float, bool\), 
CanvasItem.DrawPolylineColors\(Vector2\[\], Color\[\], float, bool\), 
CanvasItem.DrawPolylineColors\(ReadOnlySpan<Vector2\>, ReadOnlySpan<Color\>, float, bool\), 
CanvasItem.DrawArc\(Vector2, float, float, float, int, Color, float, bool\), 
CanvasItem.DrawMultiline\(Vector2\[\], Color, float, bool\), 
CanvasItem.DrawMultiline\(ReadOnlySpan<Vector2\>, Color, float, bool\), 
CanvasItem.DrawMultilineColors\(Vector2\[\], Color\[\], float, bool\), 
CanvasItem.DrawMultilineColors\(ReadOnlySpan<Vector2\>, ReadOnlySpan<Color\>, float, bool\), 
CanvasItem.DrawRect\(Rect2, Color, bool, float, bool\), 
CanvasItem.DrawCircle\(Vector2, float, Color, bool, float, bool\), 
CanvasItem.DrawTexture\(Texture2D, Vector2, Color?\), 
CanvasItem.DrawTextureRect\(Texture2D, Rect2, bool, Color?, bool\), 
CanvasItem.DrawTextureRectRegion\(Texture2D, Rect2, Rect2, Color?, bool, bool\), 
CanvasItem.DrawMsdfTextureRectRegion\(Texture2D, Rect2, Rect2, Color?, double, double, double\), 
CanvasItem.DrawLcdTextureRectRegion\(Texture2D, Rect2, Rect2, Color?\), 
CanvasItem.DrawStyleBox\(StyleBox, Rect2\), 
CanvasItem.DrawPrimitive\(Vector2\[\], Color\[\], Vector2\[\], Texture2D\), 
CanvasItem.DrawPrimitive\(ReadOnlySpan<Vector2\>, ReadOnlySpan<Color\>, ReadOnlySpan<Vector2\>, Texture2D\), 
CanvasItem.DrawPolygon\(Vector2\[\], Color\[\], Vector2\[\], Texture2D\), 
CanvasItem.DrawPolygon\(ReadOnlySpan<Vector2\>, ReadOnlySpan<Color\>, ReadOnlySpan<Vector2\>, Texture2D\), 
CanvasItem.DrawColoredPolygon\(Vector2\[\], Color, Vector2\[\], Texture2D\), 
CanvasItem.DrawColoredPolygon\(ReadOnlySpan<Vector2\>, Color, ReadOnlySpan<Vector2\>, Texture2D\), 
CanvasItem.DrawString\(Font, Vector2, string, HorizontalAlignment, float, int, Color?, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation\), 
CanvasItem.DrawMultilineString\(Font, Vector2, string, HorizontalAlignment, float, int, int, Color?, TextServer.LineBreakFlag, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation\), 
CanvasItem.DrawStringOutline\(Font, Vector2, string, HorizontalAlignment, float, int, int, Color?, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation\), 
CanvasItem.DrawMultilineStringOutline\(Font, Vector2, string, HorizontalAlignment, float, int, int, int, Color?, TextServer.LineBreakFlag, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation\), 
CanvasItem.DrawChar\(Font, Vector2, string, int, Color?\), 
CanvasItem.DrawCharOutline\(Font, Vector2, string, int, int, Color?\), 
CanvasItem.DrawMesh\(Mesh, Texture2D, Transform2D?, Color?\), 
CanvasItem.DrawMultimesh\(MultiMesh, Texture2D\), 
CanvasItem.DrawSetTransform\(Vector2, float, Vector2?\), 
CanvasItem.DrawSetTransformMatrix\(Transform2D\), 
CanvasItem.DrawAnimationSlice\(double, double, double, double\), 
CanvasItem.DrawEndAnimation\(\), 
CanvasItem.GetTransform\(\), 
CanvasItem.GetGlobalTransform\(\), 
CanvasItem.GetGlobalTransformWithCanvas\(\), 
CanvasItem.GetViewportTransform\(\), 
CanvasItem.GetViewportRect\(\), 
CanvasItem.GetCanvasTransform\(\), 
CanvasItem.GetScreenTransform\(\), 
CanvasItem.GetLocalMousePosition\(\), 
CanvasItem.GetGlobalMousePosition\(\), 
CanvasItem.GetCanvas\(\), 
CanvasItem.GetCanvasLayerNode\(\), 
CanvasItem.GetWorld2D\(\), 
CanvasItem.SetInstanceShaderParameter\(StringName, Variant\), 
CanvasItem.GetInstanceShaderParameter\(StringName\), 
CanvasItem.SetNotifyLocalTransform\(bool\), 
CanvasItem.IsLocalTransformNotificationEnabled\(\), 
CanvasItem.SetNotifyTransform\(bool\), 
CanvasItem.IsTransformNotificationEnabled\(\), 
CanvasItem.ForceUpdateTransform\(\), 
CanvasItem.MakeCanvasPositionLocal\(Vector2\), 
CanvasItem.MakeInputLocal\(InputEvent\), 
CanvasItem.SetVisibilityLayerBit\(uint, bool\), 
CanvasItem.GetVisibilityLayerBit\(uint\), 
CanvasItem.EmitSignalDraw\(\), 
CanvasItem.EmitSignalVisibilityChanged\(\), 
CanvasItem.EmitSignalHidden\(\), 
CanvasItem.EmitSignalItemRectChanged\(\), 
CanvasItem.InvokeGodotClassMethod\(in godot\_string\_name, NativeVariantPtrArgs, out godot\_variant\), 
CanvasItem.HasGodotClassMethod\(in godot\_string\_name\), 
CanvasItem.HasGodotClassSignal\(in godot\_string\_name\), 
CanvasItem.Visible, 
CanvasItem.Modulate, 
CanvasItem.SelfModulate, 
CanvasItem.ShowBehindParent, 
CanvasItem.TopLevel, 
CanvasItem.ClipChildren, 
CanvasItem.LightMask, 
CanvasItem.VisibilityLayer, 
CanvasItem.ZIndex, 
CanvasItem.ZAsRelative, 
CanvasItem.YSortEnabled, 
CanvasItem.TextureFilter, 
CanvasItem.TextureRepeat, 
CanvasItem.Material, 
CanvasItem.UseParentMaterial, 
CanvasItem.Draw, 
CanvasItem.VisibilityChanged, 
CanvasItem.Hidden, 
CanvasItem.ItemRectChanged, 
Node.NotificationEnterTree, 
Node.NotificationExitTree, 
Node.NotificationMovedInParent, 
Node.NotificationReady, 
Node.NotificationPaused, 
Node.NotificationUnpaused, 
Node.NotificationPhysicsProcess, 
Node.NotificationProcess, 
Node.NotificationParented, 
Node.NotificationUnparented, 
Node.NotificationSceneInstantiated, 
Node.NotificationDragBegin, 
Node.NotificationDragEnd, 
Node.NotificationPathRenamed, 
Node.NotificationChildOrderChanged, 
Node.NotificationInternalProcess, 
Node.NotificationInternalPhysicsProcess, 
Node.NotificationPostEnterTree, 
Node.NotificationDisabled, 
Node.NotificationEnabled, 
Node.NotificationResetPhysicsInterpolation, 
Node.NotificationEditorPreSave, 
Node.NotificationEditorPostSave, 
Node.NotificationWMMouseEnter, 
Node.NotificationWMMouseExit, 
Node.NotificationWMWindowFocusIn, 
Node.NotificationWMWindowFocusOut, 
Node.NotificationWMCloseRequest, 
Node.NotificationWMGoBackRequest, 
Node.NotificationWMSizeChanged, 
Node.NotificationWMDpiChange, 
Node.NotificationVpMouseEnter, 
Node.NotificationVpMouseExit, 
Node.NotificationOsMemoryWarning, 
Node.NotificationTranslationChanged, 
Node.NotificationWMAbout, 
Node.NotificationCrash, 
Node.NotificationOsImeUpdate, 
Node.NotificationApplicationResumed, 
Node.NotificationApplicationPaused, 
Node.NotificationApplicationFocusIn, 
Node.NotificationApplicationFocusOut, 
Node.NotificationTextServerChanged, 
Node.GetNode<T\>\(NodePath\), 
Node.GetNodeOrNull<T\>\(NodePath\), 
Node.GetChild<T\>\(int, bool\), 
Node.GetChildOrNull<T\>\(int, bool\), 
Node.GetOwner<T\>\(\), 
Node.GetOwnerOrNull<T\>\(\), 
Node.GetParent<T\>\(\), 
Node.GetParentOrNull<T\>\(\), 
Node.\_EnterTree\(\), 
Node.\_ExitTree\(\), 
Node.\_GetConfigurationWarnings\(\), 
Node.\_Input\(InputEvent\), 
Node.\_PhysicsProcess\(double\), 
Node.\_Process\(double\), 
Node.\_Ready\(\), 
Node.\_ShortcutInput\(InputEvent\), 
Node.\_UnhandledInput\(InputEvent\), 
Node.\_UnhandledKeyInput\(InputEvent\), 
Node.PrintOrphanNodes\(\), 
Node.AddSibling\(Node, bool\), 
Node.AddChild\(Node, bool, Node.InternalMode\), 
Node.RemoveChild\(Node\), 
Node.Reparent\(Node, bool\), 
Node.GetChildCount\(bool\), 
Node.GetChildren\(bool\), 
Node.GetChild\(int, bool\), 
Node.HasNode\(NodePath\), 
Node.GetNode\(NodePath\), 
Node.GetNodeOrNull\(NodePath\), 
Node.GetParent\(\), 
Node.FindChild\(string, bool, bool\), 
Node.FindChildren\(string, string, bool, bool\), 
Node.FindParent\(string\), 
Node.HasNodeAndResource\(NodePath\), 
Node.GetNodeAndResource\(NodePath\), 
Node.IsInsideTree\(\), 
Node.IsPartOfEditedScene\(\), 
Node.IsAncestorOf\(Node\), 
Node.IsGreaterThan\(Node\), 
Node.GetPath\(\), 
Node.GetPathTo\(Node, bool\), 
Node.AddToGroup\(StringName, bool\), 
Node.RemoveFromGroup\(StringName\), 
Node.IsInGroup\(StringName\), 
Node.MoveChild\(Node, int\), 
Node.GetGroups\(\), 
Node.GetIndex\(bool\), 
Node.PrintTree\(\), 
Node.PrintTreePretty\(\), 
Node.GetTreeString\(\), 
Node.GetTreeStringPretty\(\), 
Node.PropagateNotification\(int\), 
Node.PropagateCall\(StringName, Array, bool\), 
Node.SetPhysicsProcess\(bool\), 
Node.GetPhysicsProcessDeltaTime\(\), 
Node.IsPhysicsProcessing\(\), 
Node.GetProcessDeltaTime\(\), 
Node.SetProcess\(bool\), 
Node.IsProcessing\(\), 
Node.SetProcessInput\(bool\), 
Node.IsProcessingInput\(\), 
Node.SetProcessShortcutInput\(bool\), 
Node.IsProcessingShortcutInput\(\), 
Node.SetProcessUnhandledInput\(bool\), 
Node.IsProcessingUnhandledInput\(\), 
Node.SetProcessUnhandledKeyInput\(bool\), 
Node.IsProcessingUnhandledKeyInput\(\), 
Node.CanProcess\(\), 
Node.SetDisplayFolded\(bool\), 
Node.IsDisplayedFolded\(\), 
Node.SetProcessInternal\(bool\), 
Node.IsProcessingInternal\(\), 
Node.SetPhysicsProcessInternal\(bool\), 
Node.IsPhysicsProcessingInternal\(\), 
Node.IsPhysicsInterpolated\(\), 
Node.IsPhysicsInterpolatedAndEnabled\(\), 
Node.ResetPhysicsInterpolation\(\), 
Node.SetTranslationDomainInherited\(\), 
Node.GetWindow\(\), 
Node.GetLastExclusiveWindow\(\), 
Node.GetTree\(\), 
Node.CreateTween\(\), 
Node.Duplicate\(int\), 
Node.ReplaceBy\(Node, bool\), 
Node.SetSceneInstanceLoadPlaceholder\(bool\), 
Node.GetSceneInstanceLoadPlaceholder\(\), 
Node.SetEditableInstance\(Node, bool\), 
Node.IsEditableInstance\(Node\), 
Node.GetViewport\(\), 
Node.QueueFree\(\), 
Node.RequestReady\(\), 
Node.IsNodeReady\(\), 
Node.SetMultiplayerAuthority\(int, bool\), 
Node.GetMultiplayerAuthority\(\), 
Node.IsMultiplayerAuthority\(\), 
Node.RpcConfig\(StringName, Variant\), 
Node.GetRpcConfig\(\), 
Node.Atr\(string, StringName\), 
Node.AtrN\(string, StringName, int, StringName\), 
Node.Rpc\(StringName, params Variant\[\]\), 
Node.Rpc\(StringName, ReadOnlySpan<Variant\>\), 
Node.RpcId\(long, StringName, params Variant\[\]\), 
Node.RpcId\(long, StringName, ReadOnlySpan<Variant\>\), 
Node.UpdateConfigurationWarnings\(\), 
Node.CallDeferredThreadGroup\(StringName, params Variant\[\]\), 
Node.CallDeferredThreadGroup\(StringName, ReadOnlySpan<Variant\>\), 
Node.SetDeferredThreadGroup\(StringName, Variant\), 
Node.NotifyDeferredThreadGroup\(int\), 
Node.CallThreadSafe\(StringName, params Variant\[\]\), 
Node.CallThreadSafe\(StringName, ReadOnlySpan<Variant\>\), 
Node.SetThreadSafe\(StringName, Variant\), 
Node.NotifyThreadSafe\(int\), 
Node.EmitSignalReady\(\), 
Node.EmitSignalRenamed\(\), 
Node.EmitSignalTreeEntered\(\), 
Node.EmitSignalTreeExiting\(\), 
Node.EmitSignalTreeExited\(\), 
Node.EmitSignalChildEnteredTree\(Node\), 
Node.EmitSignalChildExitingTree\(Node\), 
Node.EmitSignalChildOrderChanged\(\), 
Node.EmitSignalReplacingBy\(Node\), 
Node.EmitSignalEditorDescriptionChanged\(Node\), 
Node.EmitSignalEditorStateChanged\(\), 
Node.InvokeGodotClassMethod\(in godot\_string\_name, NativeVariantPtrArgs, out godot\_variant\), 
Node.HasGodotClassMethod\(in godot\_string\_name\), 
Node.HasGodotClassSignal\(in godot\_string\_name\), 
Node.Name, 
Node.UniqueNameInOwner, 
Node.SceneFilePath, 
Node.Owner, 
Node.Multiplayer, 
Node.ProcessMode, 
Node.ProcessPriority, 
Node.ProcessPhysicsPriority, 
Node.ProcessThreadGroup, 
Node.ProcessThreadGroupOrder, 
Node.ProcessThreadMessages, 
Node.PhysicsInterpolationMode, 
Node.AutoTranslateMode, 
Node.EditorDescription, 
Node.Ready, 
Node.Renamed, 
Node.TreeEntered, 
Node.TreeExiting, 
Node.TreeExited, 
Node.ChildEnteredTree, 
Node.ChildExitingTree, 
Node.ChildOrderChanged, 
Node.ReplacingBy, 
Node.EditorDescriptionChanged, 
Node.EditorStateChanged, 
GodotObject.NotificationPostinitialize, 
GodotObject.NotificationPredelete, 
GodotObject.NotificationExtensionReloaded, 
GodotObject.InstanceFromId\(ulong\), 
GodotObject.IsInstanceIdValid\(ulong\), 
GodotObject.IsInstanceValid\(GodotObject?\), 
GodotObject.WeakRef\(GodotObject?\), 
GodotObject.Dispose\(\), 
GodotObject.Dispose\(bool\), 
GodotObject.ToString\(\), 
GodotObject.ToSignal\(GodotObject, StringName\), 
GodotObject.\_Get\(StringName\), 
GodotObject.\_GetPropertyList\(\), 
GodotObject.\_IterGet\(Variant\), 
GodotObject.\_IterInit\(Array\), 
GodotObject.\_IterNext\(Array\), 
GodotObject.\_Notification\(int\), 
GodotObject.\_PropertyCanRevert\(StringName\), 
GodotObject.\_PropertyGetRevert\(StringName\), 
GodotObject.\_Set\(StringName, Variant\), 
GodotObject.\_ValidateProperty\(Dictionary\), 
GodotObject.Free\(\), 
GodotObject.GetClass\(\), 
GodotObject.IsClass\(string\), 
GodotObject.Set\(StringName, Variant\), 
GodotObject.Get\(StringName\), 
GodotObject.SetIndexed\(NodePath, Variant\), 
GodotObject.GetIndexed\(NodePath\), 
GodotObject.GetPropertyList\(\), 
GodotObject.GetMethodList\(\), 
GodotObject.PropertyCanRevert\(StringName\), 
GodotObject.PropertyGetRevert\(StringName\), 
GodotObject.Notification\(int, bool\), 
GodotObject.GetInstanceId\(\), 
GodotObject.SetScript\(Variant\), 
GodotObject.GetScript\(\), 
GodotObject.SetMeta\(StringName, Variant\), 
GodotObject.RemoveMeta\(StringName\), 
GodotObject.GetMeta\(StringName, Variant\), 
GodotObject.HasMeta\(StringName\), 
GodotObject.GetMetaList\(\), 
GodotObject.AddUserSignal\(string, Array\), 
GodotObject.HasUserSignal\(StringName\), 
GodotObject.RemoveUserSignal\(StringName\), 
GodotObject.EmitSignal\(StringName, params Variant\[\]\), 
GodotObject.EmitSignal\(StringName, ReadOnlySpan<Variant\>\), 
GodotObject.Call\(StringName, params Variant\[\]\), 
GodotObject.Call\(StringName, ReadOnlySpan<Variant\>\), 
GodotObject.CallDeferred\(StringName, params Variant\[\]\), 
GodotObject.CallDeferred\(StringName, ReadOnlySpan<Variant\>\), 
GodotObject.SetDeferred\(StringName, Variant\), 
GodotObject.Callv\(StringName, Array\), 
GodotObject.HasMethod\(StringName\), 
GodotObject.GetMethodArgumentCount\(StringName\), 
GodotObject.HasSignal\(StringName\), 
GodotObject.GetSignalList\(\), 
GodotObject.GetSignalConnectionList\(StringName\), 
GodotObject.GetIncomingConnections\(\), 
GodotObject.Connect\(StringName, Callable, uint\), 
GodotObject.Disconnect\(StringName, Callable\), 
GodotObject.IsConnected\(StringName, Callable\), 
GodotObject.HasConnections\(StringName\), 
GodotObject.SetBlockSignals\(bool\), 
GodotObject.IsBlockingSignals\(\), 
GodotObject.NotifyPropertyListChanged\(\), 
GodotObject.SetMessageTranslation\(bool\), 
GodotObject.CanTranslateMessages\(\), 
GodotObject.Tr\(StringName, StringName\), 
GodotObject.TrN\(StringName, StringName, int, StringName\), 
GodotObject.GetTranslationDomain\(\), 
GodotObject.SetTranslationDomain\(StringName\), 
GodotObject.IsQueuedForDeletion\(\), 
GodotObject.CancelFree\(\), 
GodotObject.EmitSignalScriptChanged\(\), 
GodotObject.EmitSignalPropertyListChanged\(\), 
GodotObject.InvokeGodotClassMethod\(in godot\_string\_name, NativeVariantPtrArgs, out godot\_variant\), 
GodotObject.HasGodotClassMethod\(in godot\_string\_name\), 
GodotObject.HasGodotClassSignal\(in godot\_string\_name\), 
GodotObject.NativeInstance, 
GodotObject.ScriptChanged, 
GodotObject.PropertyListChanged, 
[object.Equals\(object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\)), 
[object.Equals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\-system\-object\)), 
[object.GetHashCode\(\)](https://learn.microsoft.com/dotnet/api/system.object.gethashcode), 
[object.GetType\(\)](https://learn.microsoft.com/dotnet/api/system.object.gettype), 
[object.MemberwiseClone\(\)](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone), 
[object.ReferenceEquals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals), 
[object.ToString\(\)](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Constructors

### <a id="DiceRolling_Editor_BoardMatrixEditor__ctor"></a> BoardMatrixEditor\(\)

```csharp
public BoardMatrixEditor()
```

### <a id="DiceRolling_Editor_BoardMatrixEditor__ctor_DiceRolling_Targets_TargetBoardType_"></a> BoardMatrixEditor\(TargetBoardType\)

```csharp
public BoardMatrixEditor(TargetBoardType targetBoard)
```

#### Parameters

`targetBoard` [TargetBoardType](DiceRolling.Targets.TargetBoardType.md)

## Properties

### <a id="DiceRolling_Editor_BoardMatrixEditor_TargetBoard"></a> TargetBoard

```csharp
public TargetBoardType? TargetBoard { get; }
```

#### Property Value

 [TargetBoardType](DiceRolling.Targets.TargetBoardType.md)?

## Methods

### <a id="DiceRolling_Editor_BoardMatrixEditor_AddGrid_DiceRolling_Grids_GridType_"></a> AddGrid\(GridType\)

```csharp
public void AddGrid(GridType grid)
```

#### Parameters

`grid` [GridType](DiceRolling.Grids.GridType.md)

### <a id="DiceRolling_Editor_BoardMatrixEditor_ClearGridInputs"></a> ClearGridInputs\(\)

```csharp
public void ClearGridInputs()
```

### <a id="DiceRolling_Editor_BoardMatrixEditor_ClearGrids"></a> ClearGrids\(\)

```csharp
public void ClearGrids()
```

### <a id="DiceRolling_Editor_BoardMatrixEditor_FlipHorizontally_System_Boolean_"></a> FlipHorizontally\(bool\)

```csharp
public void FlipHorizontally(bool flip)
```

#### Parameters

`flip` [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="DiceRolling_Editor_BoardMatrixEditor__Draw"></a> \_Draw\(\)

<p>Called when <xref href="Godot.CanvasItem" data-throw-if-not-resolved="false"></xref> has been requested to redraw (after <xref href="Godot.CanvasItem.QueueRedraw" data-throw-if-not-resolved="false"></xref> is called, either manually or by the engine).</p>
<p>Corresponds to the <xref href="Godot.CanvasItem.NotificationDraw" data-throw-if-not-resolved="false"></xref> notification in <xref href="Godot.GodotObject._Notification(System.Int32)" data-throw-if-not-resolved="false"></xref>.</p>

```csharp
public override void _Draw()
```

### <a id="DiceRolling_Editor_BoardMatrixEditor__GuiInput_Godot_InputEvent_"></a> \_GuiInput\(InputEvent\)

<p>Virtual method to be implemented by the user. Override this method to handle and accept inputs on UI elements. See also <xref href="Godot.Control.AcceptEvent" data-throw-if-not-resolved="false"></xref>.</p>
<p>
  <b>Example:</b> Click on the control to print a message:</p>
<p>
  <pre><code class="lang-csharp">public override void _GuiInput(InputEvent @event)
  {
      if (@event is InputEventMouseButton mb)
      {
          if (mb.ButtonIndex == MouseButton.Left &amp;&amp; mb.Pressed)
          {
              GD.Print("I've been clicked D:");
          }
      }
  }</code></pre>
</p>
<p>If the <code class="paramref">event</code> inherits <xref href="Godot.InputEventMouse" data-throw-if-not-resolved="false"></xref>, this method will <b>not</b> be called when:</p>
<p>- the control's <xref href="Godot.Control.MouseFilter" data-throw-if-not-resolved="false"></xref> is set to <xref href="Godot.Control.MouseFilterEnum.Ignore" data-throw-if-not-resolved="false"></xref>;</p>
<p>- the control is obstructed by another control on top, that doesn't have <xref href="Godot.Control.MouseFilter" data-throw-if-not-resolved="false"></xref> set to <xref href="Godot.Control.MouseFilterEnum.Ignore" data-throw-if-not-resolved="false"></xref>;</p>
<p>- the control's parent has <xref href="Godot.Control.MouseFilter" data-throw-if-not-resolved="false"></xref> set to <xref href="Godot.Control.MouseFilterEnum.Stop" data-throw-if-not-resolved="false"></xref> or has accepted the event;</p>
<p>- the control's parent has <xref href="Godot.Control.ClipContents" data-throw-if-not-resolved="false"></xref> enabled and the <code class="paramref">event</code>'s position is outside the parent's rectangle;</p>
<p>- the <code class="paramref">event</code>'s position is outside the control (see <xref href="Godot.Control._HasPoint(Godot.Vector2)" data-throw-if-not-resolved="false"></xref>).</p>
<p>
  <b>Note:</b> The <code class="paramref">event</code>'s position is relative to this control's origin.</p>

```csharp
public override void _GuiInput(InputEvent @event)
```

#### Parameters

`event` InputEvent

