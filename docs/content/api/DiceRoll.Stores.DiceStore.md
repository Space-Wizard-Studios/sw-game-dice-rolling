---
title: Stores.DiceStore
---

# <a id="DiceRoll_Stores_DiceStore"></a> Class DiceStore

Namespace: [DiceRoll.Stores](DiceRoll.Stores.md)  
Assembly: dice\-roll.dll  

```csharp
[ScriptPath("res://core/stores/DiceStore.cs")]
public class DiceStore : Node, IDisposable
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
GodotObject ← 
Node ← 
[DiceStore](DiceRoll.Stores.DiceStore.md)

#### Implements

[IDisposable](https://learn.microsoft.com/dotnet/api/system.idisposable)

#### Inherited Members

<details>
<summary>Show/Hide Inherited Members</summary>

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
Node.GetNode\<T\>\(NodePath\),   
Node.GetNodeOrNull\<T\>\(NodePath\),   
Node.GetChild\<T\>\(int, bool\),   
Node.GetChildOrNull\<T\>\(int, bool\),   
Node.GetOwner\<T\>\(\),   
Node.GetOwnerOrNull\<T\>\(\),   
Node.GetParent\<T\>\(\),   
Node.GetParentOrNull\<T\>\(\),   
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
Node.Rpc\(StringName, ReadOnlySpan\<Variant\>\),   
Node.RpcId\(long, StringName, params Variant\[\]\),   
Node.RpcId\(long, StringName, ReadOnlySpan\<Variant\>\),   
Node.UpdateConfigurationWarnings\(\),   
Node.CallDeferredThreadGroup\(StringName, params Variant\[\]\),   
Node.CallDeferredThreadGroup\(StringName, ReadOnlySpan\<Variant\>\),   
Node.SetDeferredThreadGroup\(StringName, Variant\),   
Node.NotifyDeferredThreadGroup\(int\),   
Node.CallThreadSafe\(StringName, params Variant\[\]\),   
Node.CallThreadSafe\(StringName, ReadOnlySpan\<Variant\>\),   
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
GodotObject.EmitSignal\(StringName, ReadOnlySpan\<Variant\>\),   
GodotObject.Call\(StringName, params Variant\[\]\),   
GodotObject.Call\(StringName, ReadOnlySpan\<Variant\>\),   
GodotObject.CallDeferred\(StringName, params Variant\[\]\),   
GodotObject.CallDeferred\(StringName, ReadOnlySpan\<Variant\>\),   
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

</details>
## Properties

### <a id="DiceRoll_Stores_DiceStore_DiceSet"></a> DiceSet

```csharp
public List\<Dice<DiceSide>> DiceSet { get; }
```

#### Property Value

 [List](https://learn.microsoft.com/dotnet/api/system.collections.generic.list\-1)\<[Dice](DiceRoll.Models.Dice\-1.md)\<[DiceSide](DiceRoll.Models.DiceSide.md)\>\>

### <a id="DiceRoll_Stores_DiceStore_Instance"></a> Instance

```csharp
public static DiceStore Instance { get; }
```

#### Property Value

 [DiceStore](DiceRoll.Stores.DiceStore.md)

## Methods

### <a id="DiceRoll_Stores_DiceStore_AddDice_DiceRoll_Models_Dice_DiceRoll_Models_DiceSide__"></a> AddDice\(Dice\<DiceSide\>\)

```csharp
public void AddDice(Dice<DiceSide> dice)
```

#### Parameters

`dice` [Dice](DiceRoll.Models.Dice\-1.md)\<[DiceSide](DiceRoll.Models.DiceSide.md)\>

### <a id="DiceRoll_Stores_DiceStore_GetDiceByID_System_String_"></a> GetDiceByID\(string\)

```csharp
public Dice<DiceSide> GetDiceByID(string diceId)
```

#### Parameters

`diceId` [string](https://learn.microsoft.com/dotnet/api/system.string)

#### Returns

 [Dice](DiceRoll.Models.Dice\-1.md)\<[DiceSide](DiceRoll.Models.DiceSide.md)\>

### <a id="DiceRoll_Stores_DiceStore_RemoveDice_System_String_"></a> RemoveDice\(string\)

```csharp
public void RemoveDice(string diceId)
```

#### Parameters

`diceId` [string](https://learn.microsoft.com/dotnet/api/system.string)

### <a id="DiceRoll_Stores_DiceStore_UpdateDiceByID_System_String_System_Action_DiceRoll_Models_Dice_DiceRoll_Models_DiceSide___"></a> UpdateDiceByID\(string, Action\<Dice\<DiceSide\>\>\)

```csharp
public void UpdateDiceByID(string diceId, Action\<Dice<DiceSide>> updateFn)
```

#### Parameters

`diceId` [string](https://learn.microsoft.com/dotnet/api/system.string)

`updateFn` [Action](https://learn.microsoft.com/dotnet/api/system.action\-1)\<[Dice](DiceRoll.Models.Dice\-1.md)\<[DiceSide](DiceRoll.Models.DiceSide.md)\>\>

### <a id="DiceRoll_Stores_DiceStore_UpdateDiceLocation_System_String_DiceRoll_Models_DiceLocation_"></a> UpdateDiceLocation\(string, DiceLocation\)

```csharp
public void UpdateDiceLocation(string diceId, DiceLocation newLocation)
```

#### Parameters

`diceId` [string](https://learn.microsoft.com/dotnet/api/system.string)

`newLocation` [DiceLocation](DiceRoll.Models.DiceLocation.md)

### <a id="DiceRoll_Stores_DiceStore_UpdateDiceName_System_String_System_String_"></a> UpdateDiceName\(string, string\)

```csharp
public void UpdateDiceName(string diceId, string newName)
```

#### Parameters

`diceId` [string](https://learn.microsoft.com/dotnet/api/system.string)

`newName` [string](https://learn.microsoft.com/dotnet/api/system.string)

