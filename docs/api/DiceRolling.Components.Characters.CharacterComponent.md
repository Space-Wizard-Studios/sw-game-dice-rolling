# <a id="DiceRolling_Components_Characters_CharacterComponent"></a> Class CharacterComponent

Namespace: [DiceRolling.Components.Characters](DiceRolling.Components.Characters.md)  
Assembly: dice\-rolling.dll  

```csharp
[Tool]
[ScriptPath("res://components/CharacterComponent/CharacterComponent.cs")]
public class CharacterComponent : Node3D, IDisposable
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
GodotObject ← 
Node ← 
Node3D ← 
[CharacterComponent](DiceRolling.Components.Characters.CharacterComponent.md)

#### Implements

[IDisposable](https://learn.microsoft.com/dotnet/api/system.idisposable)

#### Inherited Members

Node3D.NotificationTransformChanged, 
Node3D.NotificationEnterWorld, 
Node3D.NotificationExitWorld, 
Node3D.NotificationVisibilityChanged, 
Node3D.NotificationLocalTransformChanged, 
Node3D.GetGlobalTransformInterpolated\(\), 
Node3D.GetParentNode3D\(\), 
Node3D.SetIgnoreTransformNotification\(bool\), 
Node3D.SetDisableScale\(bool\), 
Node3D.IsScaleDisabled\(\), 
Node3D.GetWorld3D\(\), 
Node3D.ForceUpdateTransform\(\), 
Node3D.UpdateGizmos\(\), 
Node3D.AddGizmo\(Node3DGizmo\), 
Node3D.GetGizmos\(\), 
Node3D.ClearGizmos\(\), 
Node3D.SetSubgizmoSelection\(Node3DGizmo, int, Transform3D\), 
Node3D.ClearSubgizmoSelection\(\), 
Node3D.IsVisibleInTree\(\), 
Node3D.Show\(\), 
Node3D.Hide\(\), 
Node3D.SetNotifyLocalTransform\(bool\), 
Node3D.IsLocalTransformNotificationEnabled\(\), 
Node3D.SetNotifyTransform\(bool\), 
Node3D.IsTransformNotificationEnabled\(\), 
Node3D.Rotate\(Vector3, float\), 
Node3D.GlobalRotate\(Vector3, float\), 
Node3D.GlobalScale\(Vector3\), 
Node3D.GlobalTranslate\(Vector3\), 
Node3D.RotateObjectLocal\(Vector3, float\), 
Node3D.ScaleObjectLocal\(Vector3\), 
Node3D.TranslateObjectLocal\(Vector3\), 
Node3D.RotateX\(float\), 
Node3D.RotateY\(float\), 
Node3D.RotateZ\(float\), 
Node3D.Translate\(Vector3\), 
Node3D.Orthonormalize\(\), 
Node3D.SetIdentity\(\), 
Node3D.LookAt\(Vector3, Vector3?, bool\), 
Node3D.LookAtFromPosition\(Vector3, Vector3, Vector3?, bool\), 
Node3D.ToLocal\(Vector3\), 
Node3D.ToGlobal\(Vector3\), 
Node3D.EmitSignalVisibilityChanged\(\), 
Node3D.InvokeGodotClassMethod\(in godot\_string\_name, NativeVariantPtrArgs, out godot\_variant\), 
Node3D.HasGodotClassMethod\(in godot\_string\_name\), 
Node3D.HasGodotClassSignal\(in godot\_string\_name\), 
Node3D.Transform, 
Node3D.GlobalTransform, 
Node3D.Position, 
Node3D.Rotation, 
Node3D.RotationDegrees, 
Node3D.Quaternion, 
Node3D.Basis, 
Node3D.Scale, 
Node3D.RotationEditMode, 
Node3D.RotationOrder, 
Node3D.TopLevel, 
Node3D.GlobalPosition, 
Node3D.GlobalBasis, 
Node3D.GlobalRotation, 
Node3D.GlobalRotationDegrees, 
Node3D.Visible, 
Node3D.VisibilityParent, 
Node3D.VisibilityChanged, 
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

## Properties

### <a id="DiceRolling_Components_Characters_CharacterComponent_AnimatedSpriteNode"></a> AnimatedSpriteNode

```csharp
[ExportGroup("🔘 Nodes", "")]
[Export(PropertyHint.None, "")]
public AnimatedSprite3D? AnimatedSpriteNode { get; set; }
```

#### Property Value

 AnimatedSprite3D?

### <a id="DiceRolling_Components_Characters_CharacterComponent_Character"></a> Character

```csharp
[Export(PropertyHint.None, "")]
public CharacterType? Character { get; set; }
```

#### Property Value

 [CharacterType](DiceRolling.Models.Characters.CharacterType.md)?

### <a id="DiceRolling_Components_Characters_CharacterComponent_HoverSpriteNode"></a> HoverSpriteNode

```csharp
[Export(PropertyHint.None, "")]
public Sprite3D? HoverSpriteNode { get; set; }
```

#### Property Value

 Sprite3D?

### <a id="DiceRolling_Components_Characters_CharacterComponent_InputAreaNode"></a> InputAreaNode

```csharp
[Export(PropertyHint.None, "")]
public Area3D? InputAreaNode { get; set; }
```

#### Property Value

 Area3D?

### <a id="DiceRolling_Components_Characters_CharacterComponent_IsEnemy"></a> IsEnemy

```csharp
[ExportGroup("🏳️ Flags", "")]
[Export(PropertyHint.None, "")]
public bool IsEnemy { get; set; }
```

#### Property Value

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="DiceRolling_Components_Characters_CharacterComponent_IsHovered"></a> IsHovered

```csharp
[Export(PropertyHint.None, "")]
public bool IsHovered { get; set; }
```

#### Property Value

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="DiceRolling_Components_Characters_CharacterComponent_IsSelected"></a> IsSelected

```csharp
[Export(PropertyHint.None, "")]
public bool IsSelected { get; set; }
```

#### Property Value

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="DiceRolling_Components_Characters_CharacterComponent_SelectorSpriteNode"></a> SelectorSpriteNode

```csharp
[Export(PropertyHint.None, "")]
public Sprite3D? SelectorSpriteNode { get; set; }
```

#### Property Value

 Sprite3D?

## Methods

### <a id="DiceRolling_Components_Characters_CharacterComponent_FlipSprite_System_Boolean_"></a> FlipSprite\(bool\)

```csharp
public void FlipSprite(bool flip)
```

#### Parameters

`flip` [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="DiceRolling_Components_Characters_CharacterComponent__Ready"></a> \_Ready\(\)

<p>Called when the node is "ready", i.e. when both the node and its children have entered the scene tree. If the node has children, their <xref href="Godot.Node._Ready" data-throw-if-not-resolved="false"></xref> callbacks get triggered first, and the parent node will receive the ready notification afterwards.</p>
<p>Corresponds to the <xref href="Godot.Node.NotificationReady" data-throw-if-not-resolved="false"></xref> notification in <xref href="Godot.GodotObject._Notification(System.Int32)" data-throw-if-not-resolved="false"></xref>. See also the <code>@onready</code> annotation for variables.</p>
<p>Usually used for initialization. For even earlier initialization, <xref href="Godot.GodotObject.%23ctor" data-throw-if-not-resolved="false"></xref> may be used. See also <xref href="Godot.Node._EnterTree" data-throw-if-not-resolved="false"></xref>.</p>
<p>
  <b>Note:</b> This method may be called only once for each node. After removing a node from the scene tree and adding it again, <xref href="Godot.Node._Ready" data-throw-if-not-resolved="false"></xref> will <b>not</b> be called a second time. This can be bypassed by requesting another call with <xref href="Godot.Node.RequestReady" data-throw-if-not-resolved="false"></xref>, which may be called anywhere before adding the node again.</p>

```csharp
public override void _Ready()
```

