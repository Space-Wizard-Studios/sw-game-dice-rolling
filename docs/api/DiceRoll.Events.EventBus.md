# <a id="DiceRoll_Events_EventBus"></a> Class EventBus

Namespace: [DiceRoll.Events](DiceRoll.Events.md)  
Assembly: dice\-roll.dll  

```csharp
[Tool]
[ScriptPath("res://core/events/EventBus.cs")]
public class EventBus : Node, IDisposable
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
GodotObject ← 
Node ← 
[EventBus](DiceRoll.Events.EventBus.md)

#### Implements

[IDisposable](https://learn.microsoft.com/dotnet/api/system.idisposable)

#### Inherited Members

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

## Properties

### <a id="DiceRoll_Events_EventBus_Instance"></a> Instance

```csharp
public static EventBus Instance { get; }
```

#### Property Value

 [EventBus](DiceRoll.Events.EventBus.md)

## Methods

### <a id="DiceRoll_Events_EventBus_EmitAttributeChanged_DiceRoll_Models_Characters_Character_DiceRoll_Models_Attributes_AttributeType_"></a> EmitAttributeChanged\(Character, AttributeType\)

```csharp
public void EmitAttributeChanged(Character character, AttributeType attributeType)
```

#### Parameters

`character` [Character](DiceRoll.Models.Characters.Character.md)

`attributeType` [AttributeType](DiceRoll.Models.Attributes.AttributeType.md)

### <a id="DiceRoll_Events_EventBus_EmitSignalAttributeChanged"></a> EmitSignalAttributeChanged\(\)

```csharp
protected void EmitSignalAttributeChanged()
```

### <a id="DiceRoll_Events_EventBus_EmitSignalCharacterSelected_DiceRoll_Components_Characters_CharacterComponent_"></a> EmitSignalCharacterSelected\(CharacterComponent\)

```csharp
protected void EmitSignalCharacterSelected(CharacterComponent character)
```

#### Parameters

`character` [CharacterComponent](DiceRoll.Components.Characters.CharacterComponent.md)

### <a id="DiceRoll_Events_EventBus_EmitSignalCharacterUnselected"></a> EmitSignalCharacterUnselected\(\)

```csharp
protected void EmitSignalCharacterUnselected()
```

### <a id="DiceRoll_Events_EventBus_HasGodotClassMethod_Godot_NativeInterop_godot_string_name__"></a> HasGodotClassMethod\(in godot\_string\_name\)

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

### <a id="DiceRoll_Events_EventBus_HasGodotClassSignal_Godot_NativeInterop_godot_string_name__"></a> HasGodotClassSignal\(in godot\_string\_name\)

Check if the type contains a signal with the given name.
This method is used by Godot to check if a signal exists before raising it.
Do not call or override this method.

```csharp
[EditorBrowsable(EditorBrowsableState.Never)]
protected override bool HasGodotClassSignal(in godot_string_name signal)
```

#### Parameters

`signal` godot\_string\_name

Name of the signal to check for.

#### Returns

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="DiceRoll_Events_EventBus_InvokeGodotClassMethod_Godot_NativeInterop_godot_string_name__Godot_NativeInterop_NativeVariantPtrArgs_Godot_NativeInterop_godot_variant__"></a> InvokeGodotClassMethod\(in godot\_string\_name, NativeVariantPtrArgs, out godot\_variant\)

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

### <a id="DiceRoll_Events_EventBus_OnCharacterSelected_DiceRoll_Components_Characters_CharacterComponent_"></a> OnCharacterSelected\(CharacterComponent\)

```csharp
public void OnCharacterSelected(CharacterComponent character)
```

#### Parameters

`character` [CharacterComponent](DiceRoll.Components.Characters.CharacterComponent.md)

### <a id="DiceRoll_Events_EventBus_OnCharacterUnselected"></a> OnCharacterUnselected\(\)

```csharp
public void OnCharacterUnselected()
```

### <a id="DiceRoll_Events_EventBus_RaiseGodotClassSignalCallbacks_Godot_NativeInterop_godot_string_name__Godot_NativeInterop_NativeVariantPtrArgs_"></a> RaiseGodotClassSignalCallbacks\(in godot\_string\_name, NativeVariantPtrArgs\)

Raises the signal with the given name, using the given arguments.
This method is used by Godot to raise signals from the engine side.\n"
Do not call or override this method.

```csharp
[EditorBrowsable(EditorBrowsableState.Never)]
protected override void RaiseGodotClassSignalCallbacks(in godot_string_name signal, NativeVariantPtrArgs args)
```

#### Parameters

`signal` godot\_string\_name

Name of the signal to raise.

`args` NativeVariantPtrArgs

Arguments to use with the raised signal.

### <a id="DiceRoll_Events_EventBus_RestoreGodotObjectData_Godot_Bridge_GodotSerializationInfo_"></a> RestoreGodotObjectData\(GodotSerializationInfo\)

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

### <a id="DiceRoll_Events_EventBus_SaveGodotObjectData_Godot_Bridge_GodotSerializationInfo_"></a> SaveGodotObjectData\(GodotSerializationInfo\)

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

### <a id="DiceRoll_Events_EventBus__Input_Godot_InputEvent_"></a> \_Input\(InputEvent\)

<p>Called when there is an input event. The input event propagates up through the node tree until a node consumes it.</p>
<p>It is only called if input processing is enabled, which is done automatically if this method is overridden, and can be toggled with <xref href="Godot.Node.SetProcessInput(System.Boolean)" data-throw-if-not-resolved="false"></xref>.</p>
<p>To consume the input event and stop it propagating further to other nodes, <xref href="Godot.Viewport.SetInputAsHandled" data-throw-if-not-resolved="false"></xref> can be called.</p>
<p>For gameplay input, <xref href="Godot.Node._UnhandledInput(Godot.InputEvent)" data-throw-if-not-resolved="false"></xref> and <xref href="Godot.Node._UnhandledKeyInput(Godot.InputEvent)" data-throw-if-not-resolved="false"></xref> are usually a better fit as they allow the GUI to intercept the events first.</p>
<p>
  <b>Note:</b> This method is only called if the node is present in the scene tree (i.e. if it's not an orphan).</p>

```csharp
public override void _Input(InputEvent @event)
```

#### Parameters

`event` InputEvent

### <a id="DiceRoll_Events_EventBus__Ready"></a> \_Ready\(\)

<p>Called when the node is "ready", i.e. when both the node and its children have entered the scene tree. If the node has children, their <xref href="Godot.Node._Ready" data-throw-if-not-resolved="false"></xref> callbacks get triggered first, and the parent node will receive the ready notification afterwards.</p>
<p>Corresponds to the <xref href="Godot.Node.NotificationReady" data-throw-if-not-resolved="false"></xref> notification in <xref href="Godot.GodotObject._Notification(System.Int32)" data-throw-if-not-resolved="false"></xref>. See also the <code>@onready</code> annotation for variables.</p>
<p>Usually used for initialization. For even earlier initialization, <xref href="Godot.GodotObject.%23ctor" data-throw-if-not-resolved="false"></xref> may be used. See also <xref href="Godot.Node._EnterTree" data-throw-if-not-resolved="false"></xref>.</p>
<p>
  <b>Note:</b> This method may be called only once for each node. After removing a node from the scene tree and adding it again, <xref href="Godot.Node._Ready" data-throw-if-not-resolved="false"></xref> will <b>not</b> be called a second time. This can be bypassed by requesting another call with <xref href="Godot.Node.RequestReady" data-throw-if-not-resolved="false"></xref>, which may be called anywhere before adding the node again.</p>

```csharp
public override void _Ready()
```

### <a id="DiceRoll_Events_EventBus_AttributeChanged"></a> AttributeChanged

```csharp
public event EventBus.AttributeChangedEventHandler AttributeChanged
```

#### Event Type

 [EventBus](DiceRoll.Events.EventBus.md).[AttributeChangedEventHandler](DiceRoll.Events.EventBus.AttributeChangedEventHandler.md)

### <a id="DiceRoll_Events_EventBus_CharacterSelected"></a> CharacterSelected

```csharp
public event EventBus.CharacterSelectedEventHandler CharacterSelected
```

#### Event Type

 [EventBus](DiceRoll.Events.EventBus.md).[CharacterSelectedEventHandler](DiceRoll.Events.EventBus.CharacterSelectedEventHandler.md)

### <a id="DiceRoll_Events_EventBus_CharacterUnselected"></a> CharacterUnselected

```csharp
public event EventBus.CharacterUnselectedEventHandler CharacterUnselected
```

#### Event Type

 [EventBus](DiceRoll.Events.EventBus.md).[CharacterUnselectedEventHandler](DiceRoll.Events.EventBus.CharacterUnselectedEventHandler.md)

