# <a id="DiceRoll_Editor_TargetConfigurationEditorPlugin"></a> Class TargetConfigurationEditorPlugin

Namespace: [DiceRoll.Editor](DiceRoll.Editor.md)  
Assembly: dice\-roll.dll  

```csharp
[Tool]
[ScriptPath("res://addons/TargetConfigurationEditorPlugin/TargetConfigurationEditorPlugin.cs")]
public class TargetConfigurationEditorPlugin : EditorPlugin, IDisposable
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
GodotObject ← 
Node ← 
EditorPlugin ← 
[TargetConfigurationEditorPlugin](DiceRoll.Editor.TargetConfigurationEditorPlugin.md)

#### Implements

[IDisposable](https://learn.microsoft.com/dotnet/api/system.idisposable)

#### Inherited Members

EditorPlugin.\_ApplyChanges\(\), 
EditorPlugin.\_Build\(\), 
EditorPlugin.\_Clear\(\), 
EditorPlugin.\_DisablePlugin\(\), 
EditorPlugin.\_Edit\(GodotObject\), 
EditorPlugin.\_EnablePlugin\(\), 
EditorPlugin.\_Forward3DDrawOverViewport\(Control\), 
EditorPlugin.\_Forward3DForceDrawOverViewport\(Control\), 
EditorPlugin.\_Forward3DGuiInput\(Camera3D, InputEvent\), 
EditorPlugin.\_ForwardCanvasDrawOverViewport\(Control\), 
EditorPlugin.\_ForwardCanvasForceDrawOverViewport\(Control\), 
EditorPlugin.\_ForwardCanvasGuiInput\(InputEvent\), 
EditorPlugin.\_GetBreakpoints\(\), 
EditorPlugin.\_GetPluginIcon\(\), 
EditorPlugin.\_GetPluginName\(\), 
EditorPlugin.\_GetState\(\), 
EditorPlugin.\_GetUnsavedStatus\(string\), 
EditorPlugin.\_GetWindowLayout\(ConfigFile\), 
EditorPlugin.\_Handles\(GodotObject\), 
EditorPlugin.\_HasMainScreen\(\), 
EditorPlugin.\_MakeVisible\(bool\), 
EditorPlugin.\_SaveExternalData\(\), 
EditorPlugin.\_SetState\(Dictionary\), 
EditorPlugin.\_SetWindowLayout\(ConfigFile\), 
EditorPlugin.AddControlToContainer\(EditorPlugin.CustomControlContainer, Control\), 
EditorPlugin.AddControlToBottomPanel\(Control, string, Shortcut\), 
EditorPlugin.AddControlToDock\(EditorPlugin.DockSlot, Control, Shortcut\), 
EditorPlugin.RemoveControlFromDocks\(Control\), 
EditorPlugin.RemoveControlFromBottomPanel\(Control\), 
EditorPlugin.RemoveControlFromContainer\(EditorPlugin.CustomControlContainer, Control\), 
EditorPlugin.SetDockTabIcon\(Control, Texture2D\), 
EditorPlugin.AddToolMenuItem\(string, Callable\), 
EditorPlugin.AddToolSubmenuItem\(string, PopupMenu\), 
EditorPlugin.RemoveToolMenuItem\(string\), 
EditorPlugin.GetExportAsMenu\(\), 
EditorPlugin.AddCustomType\(string, string, Script, Texture2D\), 
EditorPlugin.RemoveCustomType\(string\), 
EditorPlugin.AddAutoloadSingleton\(string, string\), 
EditorPlugin.RemoveAutoloadSingleton\(string\), 
EditorPlugin.UpdateOverlays\(\), 
EditorPlugin.MakeBottomPanelItemVisible\(Control\), 
EditorPlugin.HideBottomPanel\(\), 
EditorPlugin.GetUndoRedo\(\), 
EditorPlugin.AddUndoRedoInspectorHookCallback\(Callable\), 
EditorPlugin.RemoveUndoRedoInspectorHookCallback\(Callable\), 
EditorPlugin.QueueSaveLayout\(\), 
EditorPlugin.AddTranslationParserPlugin\(EditorTranslationParserPlugin\), 
EditorPlugin.RemoveTranslationParserPlugin\(EditorTranslationParserPlugin\), 
EditorPlugin.AddImportPlugin\(EditorImportPlugin, bool\), 
EditorPlugin.RemoveImportPlugin\(EditorImportPlugin\), 
EditorPlugin.AddSceneFormatImporterPlugin\(EditorSceneFormatImporter, bool\), 
EditorPlugin.RemoveSceneFormatImporterPlugin\(EditorSceneFormatImporter\), 
EditorPlugin.AddScenePostImportPlugin\(EditorScenePostImportPlugin, bool\), 
EditorPlugin.RemoveScenePostImportPlugin\(EditorScenePostImportPlugin\), 
EditorPlugin.AddExportPlugin\(EditorExportPlugin\), 
EditorPlugin.RemoveExportPlugin\(EditorExportPlugin\), 
EditorPlugin.AddExportPlatform\(EditorExportPlatform\), 
EditorPlugin.RemoveExportPlatform\(EditorExportPlatform\), 
EditorPlugin.AddNode3DGizmoPlugin\(EditorNode3DGizmoPlugin\), 
EditorPlugin.RemoveNode3DGizmoPlugin\(EditorNode3DGizmoPlugin\), 
EditorPlugin.AddInspectorPlugin\(EditorInspectorPlugin\), 
EditorPlugin.RemoveInspectorPlugin\(EditorInspectorPlugin\), 
EditorPlugin.AddResourceConversionPlugin\(EditorResourceConversionPlugin\), 
EditorPlugin.RemoveResourceConversionPlugin\(EditorResourceConversionPlugin\), 
EditorPlugin.SetInputEventForwardingAlwaysEnabled\(\), 
EditorPlugin.SetForceDrawOverForwardingEnabled\(\), 
EditorPlugin.AddContextMenuPlugin\(EditorContextMenuPlugin.ContextMenuSlot, EditorContextMenuPlugin\), 
EditorPlugin.RemoveContextMenuPlugin\(EditorContextMenuPlugin\), 
EditorPlugin.GetEditorInterface\(\), 
EditorPlugin.GetScriptCreateDialog\(\), 
EditorPlugin.AddDebuggerPlugin\(EditorDebuggerPlugin\), 
EditorPlugin.RemoveDebuggerPlugin\(EditorDebuggerPlugin\), 
EditorPlugin.GetPluginVersion\(\), 
EditorPlugin.AddControlToDock\(EditorPlugin.DockSlot, Control\), 
EditorPlugin.AddControlToBottomPanel\(Control, string\), 
EditorPlugin.EmitSignalSceneChanged\(Node\), 
EditorPlugin.EmitSignalSceneClosed\(string\), 
EditorPlugin.EmitSignalMainScreenChanged\(string\), 
EditorPlugin.EmitSignalResourceSaved\(Resource\), 
EditorPlugin.EmitSignalSceneSaved\(string\), 
EditorPlugin.EmitSignalProjectSettingsChanged\(\), 
EditorPlugin.InvokeGodotClassMethod\(in godot\_string\_name, NativeVariantPtrArgs, out godot\_variant\), 
EditorPlugin.HasGodotClassMethod\(in godot\_string\_name\), 
EditorPlugin.HasGodotClassSignal\(in godot\_string\_name\), 
EditorPlugin.SceneChanged, 
EditorPlugin.SceneClosed, 
EditorPlugin.MainScreenChanged, 
EditorPlugin.ResourceSaved, 
EditorPlugin.SceneSaved, 
EditorPlugin.ProjectSettingsChanged, 
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
Node.SetName\(string\), 
Node.GetName\(\), 
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
Node.SetOwner\(Node\), 
Node.GetOwner\(\), 
Node.GetIndex\(bool\), 
Node.PrintTree\(\), 
Node.PrintTreePretty\(\), 
Node.GetTreeString\(\), 
Node.GetTreeStringPretty\(\), 
Node.SetSceneFilePath\(string\), 
Node.GetSceneFilePath\(\), 
Node.PropagateNotification\(int\), 
Node.PropagateCall\(StringName, Array, bool\), 
Node.SetPhysicsProcess\(bool\), 
Node.GetPhysicsProcessDeltaTime\(\), 
Node.IsPhysicsProcessing\(\), 
Node.GetProcessDeltaTime\(\), 
Node.SetProcess\(bool\), 
Node.SetProcessPriority\(int\), 
Node.GetProcessPriority\(\), 
Node.SetPhysicsProcessPriority\(int\), 
Node.GetPhysicsProcessPriority\(\), 
Node.IsProcessing\(\), 
Node.SetProcessInput\(bool\), 
Node.IsProcessingInput\(\), 
Node.SetProcessShortcutInput\(bool\), 
Node.IsProcessingShortcutInput\(\), 
Node.SetProcessUnhandledInput\(bool\), 
Node.IsProcessingUnhandledInput\(\), 
Node.SetProcessUnhandledKeyInput\(bool\), 
Node.IsProcessingUnhandledKeyInput\(\), 
Node.SetProcessMode\(Node.ProcessModeEnum\), 
Node.GetProcessMode\(\), 
Node.CanProcess\(\), 
Node.SetProcessThreadGroup\(Node.ProcessThreadGroupEnum\), 
Node.GetProcessThreadGroup\(\), 
Node.SetProcessThreadMessages\(Node.ProcessThreadMessagesEnum\), 
Node.GetProcessThreadMessages\(\), 
Node.SetProcessThreadGroupOrder\(int\), 
Node.GetProcessThreadGroupOrder\(\), 
Node.SetDisplayFolded\(bool\), 
Node.IsDisplayedFolded\(\), 
Node.SetProcessInternal\(bool\), 
Node.IsProcessingInternal\(\), 
Node.SetPhysicsProcessInternal\(bool\), 
Node.IsPhysicsProcessingInternal\(\), 
Node.SetPhysicsInterpolationMode\(Node.PhysicsInterpolationModeEnum\), 
Node.GetPhysicsInterpolationMode\(\), 
Node.IsPhysicsInterpolated\(\), 
Node.IsPhysicsInterpolatedAndEnabled\(\), 
Node.ResetPhysicsInterpolation\(\), 
Node.SetAutoTranslateMode\(Node.AutoTranslateModeEnum\), 
Node.GetAutoTranslateMode\(\), 
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
Node.GetMultiplayer\(\), 
Node.RpcConfig\(StringName, Variant\), 
Node.GetRpcConfig\(\), 
Node.SetEditorDescription\(string\), 
Node.GetEditorDescription\(\), 
Node.SetUniqueNameInOwner\(bool\), 
Node.IsUniqueNameInOwner\(\), 
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
Node.\_ImportPath, 
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
GodotObject.SetGodotClassPropertyValue\(in godot\_string\_name, in godot\_variant\), 
GodotObject.GetGodotClassPropertyValue\(in godot\_string\_name, out godot\_variant\), 
GodotObject.RaiseGodotClassSignalCallbacks\(in godot\_string\_name, NativeVariantPtrArgs\), 
GodotObject.SaveGodotObjectData\(GodotSerializationInfo\), 
GodotObject.RestoreGodotObjectData\(GodotSerializationInfo\), 
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

## Methods

### <a id="DiceRoll_Editor_TargetConfigurationEditorPlugin_GetGodotMethodList"></a> GetGodotMethodList\(\)

Get the method information for all the methods declared in this class.
This method is used by Godot to register the available methods in the editor.
Do not call this method.

```csharp
[EditorBrowsable(EditorBrowsableState.Never)]
internal static List<MethodInfo> GetGodotMethodList()
```

#### Returns

 [List](https://learn.microsoft.com/dotnet/api/system.collections.generic.list\-1)<MethodInfo\>

### <a id="DiceRoll_Editor_TargetConfigurationEditorPlugin_HasGodotClassMethod_Godot_NativeInterop_godot_string_name__"></a> HasGodotClassMethod\(in godot\_string\_name\)

Check if the type contains a method with the given name.
This method is used by Godot to check if a method exists before invoking it.
Do not call or override this method.

```csharp
[EditorBrowsable(EditorBrowsableState.Never)]
protected override bool HasGodotClassMethod(in godot_string_name method)
```

#### Parameters

`method` godot\_string\_name

Name of the method to check for.

#### Returns

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="DiceRoll_Editor_TargetConfigurationEditorPlugin_InvokeGodotClassMethod_Godot_NativeInterop_godot_string_name__Godot_NativeInterop_NativeVariantPtrArgs_Godot_NativeInterop_godot_variant__"></a> InvokeGodotClassMethod\(in godot\_string\_name, NativeVariantPtrArgs, out godot\_variant\)

Invokes the method with the given name, using the given arguments.
This method is used by Godot to invoke methods from the engine side.
Do not call or override this method.

```csharp
[EditorBrowsable(EditorBrowsableState.Never)]
protected override bool InvokeGodotClassMethod(in godot_string_name method, NativeVariantPtrArgs args, out godot_variant ret)
```

#### Parameters

`method` godot\_string\_name

Name of the method to invoke.

`args` NativeVariantPtrArgs

Arguments to use with the invoked method.

`ret` godot\_variant

Value returned by the invoked method.

#### Returns

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="DiceRoll_Editor_TargetConfigurationEditorPlugin_RestoreGodotObjectData_Godot_Bridge_GodotSerializationInfo_"></a> RestoreGodotObjectData\(GodotSerializationInfo\)

Restores this instance's state after reloading assemblies.
Do not call or override this method.
To add data to be saved and restored, implement <xref href="Godot.ISerializationListener" data-throw-if-not-resolved="false"></xref>.

```csharp
[EditorBrowsable(EditorBrowsableState.Never)]
protected override void RestoreGodotObjectData(GodotSerializationInfo info)
```

#### Parameters

`info` GodotSerializationInfo

Object that contains the previously saved data.

### <a id="DiceRoll_Editor_TargetConfigurationEditorPlugin_SaveGodotObjectData_Godot_Bridge_GodotSerializationInfo_"></a> SaveGodotObjectData\(GodotSerializationInfo\)

Saves this instance's state to be restored when reloading assemblies.
Do not call or override this method.
To add data to be saved and restored, implement <xref href="Godot.ISerializationListener" data-throw-if-not-resolved="false"></xref>.

```csharp
[EditorBrowsable(EditorBrowsableState.Never)]
protected override void SaveGodotObjectData(GodotSerializationInfo info)
```

#### Parameters

`info` GodotSerializationInfo

Object used to save the data.

### <a id="DiceRoll_Editor_TargetConfigurationEditorPlugin__EnterTree"></a> \_EnterTree\(\)

<p>Called when the node enters the <xref href="Godot.SceneTree" data-throw-if-not-resolved="false"></xref> (e.g. upon instantiating, scene changing, or after calling <xref href="Godot.Node.AddChild(Godot.Node%2cSystem.Boolean%2cGodot.Node.InternalMode)" data-throw-if-not-resolved="false"></xref> in a script). If the node has children, its <xref href="Godot.Node._EnterTree" data-throw-if-not-resolved="false"></xref> callback will be called first, and then that of the children.</p>
<p>Corresponds to the <xref href="Godot.Node.NotificationEnterTree" data-throw-if-not-resolved="false"></xref> notification in <xref href="Godot.GodotObject._Notification(System.Int32)" data-throw-if-not-resolved="false"></xref>.</p>

```csharp
public override void _EnterTree()
```

### <a id="DiceRoll_Editor_TargetConfigurationEditorPlugin__ExitTree"></a> \_ExitTree\(\)

<p>Called when the node is about to leave the <xref href="Godot.SceneTree" data-throw-if-not-resolved="false"></xref> (e.g. upon freeing, scene changing, or after calling <xref href="Godot.Node.RemoveChild(Godot.Node)" data-throw-if-not-resolved="false"></xref> in a script). If the node has children, its <xref href="Godot.Node._ExitTree" data-throw-if-not-resolved="false"></xref> callback will be called last, after all its children have left the tree.</p>
<p>Corresponds to the <xref href="Godot.Node.NotificationExitTree" data-throw-if-not-resolved="false"></xref> notification in <xref href="Godot.GodotObject._Notification(System.Int32)" data-throw-if-not-resolved="false"></xref> and signal <xref href="Godot.Node.TreeExiting" data-throw-if-not-resolved="false"></xref>. To get notified when the node has already left the active tree, connect to the <xref href="Godot.Node.TreeExited" data-throw-if-not-resolved="false"></xref>.</p>

```csharp
public override void _ExitTree()
```

