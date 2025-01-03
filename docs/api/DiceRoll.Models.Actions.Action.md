# <a id="DiceRoll_Models_Actions_Action"></a> Class Action

Namespace: [DiceRoll.Models.Actions](DiceRoll.Models.Actions.md)  
Assembly: dice\-roll.dll  

```csharp
[Tool]
[GlobalClass]
[ScriptPath("res://models/Action/Action.cs")]
public class Action : Resource, IDisposable, IAction<IActionContext, bool>
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
GodotObject ← 
RefCounted ← 
Resource ← 
[Action](DiceRoll.Models.Actions.Action.md)

#### Implements

[IDisposable](https://learn.microsoft.com/dotnet/api/system.idisposable), 
[IAction<IActionContext, bool\>](DiceRoll.Models.Actions.IAction\-2.md)

#### Inherited Members

Resource.\_GetRid\(\), 
Resource.\_ResetState\(\), 
Resource.\_SetPathCache\(string\), 
Resource.\_SetupLocalToScene\(\), 
Resource.TakeOverPath\(string\), 
Resource.SetPathCache\(string\), 
Resource.GetRid\(\), 
Resource.GetLocalScene\(\), 
Resource.SetupLocalToScene\(\), 
Resource.ResetState\(\), 
Resource.SetIdForPath\(string, string\), 
Resource.GetIdForPath\(string\), 
Resource.IsBuiltIn\(\), 
Resource.GenerateSceneUniqueId\(\), 
Resource.EmitChanged\(\), 
Resource.Duplicate\(bool\), 
Resource.EmitSignalChanged\(\), 
Resource.EmitSignalSetupLocalToSceneRequested\(\), 
Resource.InvokeGodotClassMethod\(in godot\_string\_name, NativeVariantPtrArgs, out godot\_variant\), 
Resource.HasGodotClassMethod\(in godot\_string\_name\), 
Resource.HasGodotClassSignal\(in godot\_string\_name\), 
Resource.ResourceLocalToScene, 
Resource.ResourcePath, 
Resource.ResourceName, 
Resource.ResourceSceneUniqueId, 
Resource.Changed, 
Resource.SetupLocalToSceneRequested, 
RefCounted.InitRef\(\), 
RefCounted.Reference\(\), 
RefCounted.Unreference\(\), 
RefCounted.GetReferenceCount\(\), 
RefCounted.InvokeGodotClassMethod\(in godot\_string\_name, NativeVariantPtrArgs, out godot\_variant\), 
RefCounted.HasGodotClassMethod\(in godot\_string\_name\), 
RefCounted.HasGodotClassSignal\(in godot\_string\_name\), 
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

### <a id="DiceRoll_Models_Actions_Action__ctor"></a> Action\(\)

```csharp
public Action()
```

### <a id="DiceRoll_Models_Actions_Action__ctor_DiceRoll_Models_Actions_ActionType_DiceRoll_Models_Actions_ActionSource_Godot_Collections_Array_DiceRoll_Models_DiceMana__Godot_Collections_Array_DiceRoll_Models_Actions_Effects_EffectType__"></a> Action\(ActionType, ActionSource, Array<DiceMana\>, Array<EffectType\>\)

```csharp
public Action(ActionType actionType, ActionSource source, Array<DiceMana> requiredMana, Array<EffectType> effects)
```

#### Parameters

`actionType` [ActionType](DiceRoll.Models.Actions.ActionType.md)

`source` [ActionSource](DiceRoll.Models.Actions.ActionSource.md)

`requiredMana` Array<[DiceMana](DiceRoll.Models.DiceMana.md)\>

`effects` Array<[EffectType](DiceRoll.Models.Actions.Effects.EffectType.md)\>

## Properties

### <a id="DiceRoll_Models_Actions_Action_ActionType"></a> ActionType

```csharp
[Export(PropertyHint.None, "")]
public ActionType? ActionType { get; set; }
```

#### Property Value

 [ActionType](DiceRoll.Models.Actions.ActionType.md)?

### <a id="DiceRoll_Models_Actions_Action_Description"></a> Description

```csharp
[Export(PropertyHint.MultilineText, "")]
public string? Description { get; set; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)?

### <a id="DiceRoll_Models_Actions_Action_Effects"></a> Effects

```csharp
[Export(PropertyHint.None, "")]
public Array<EffectType> Effects { get; set; }
```

#### Property Value

 Array<[EffectType](DiceRoll.Models.Actions.Effects.EffectType.md)\>

### <a id="DiceRoll_Models_Actions_Action_Icon"></a> Icon

```csharp
[Export(PropertyHint.None, "")]
public Texture2D? Icon { get; set; }
```

#### Property Value

 Texture2D?

### <a id="DiceRoll_Models_Actions_Action_IconPath"></a> IconPath

```csharp
public string? IconPath { get; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)?

### <a id="DiceRoll_Models_Actions_Action_Id"></a> Id

```csharp
[Export(PropertyHint.None, "")]
public string Id { get; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)

### <a id="DiceRoll_Models_Actions_Action_Name"></a> Name

```csharp
[Export(PropertyHint.None, "")]
public string? Name { get; set; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)?

### <a id="DiceRoll_Models_Actions_Action_RequiredMana"></a> RequiredMana

```csharp
[Export(PropertyHint.None, "")]
public Array<DiceMana> RequiredMana { get; set; }
```

#### Property Value

 Array<[DiceMana](DiceRoll.Models.DiceMana.md)\>

### <a id="DiceRoll_Models_Actions_Action_Source"></a> Source

```csharp
[Export(PropertyHint.None, "")]
public ActionSource? Source { get; set; }
```

#### Property Value

 [ActionSource](DiceRoll.Models.Actions.ActionSource.md)?

## Methods

### <a id="DiceRoll_Models_Actions_Action_Do_DiceRoll_Models_Actions_IActionContext_"></a> Do\(IActionContext\)

```csharp
public bool Do(IActionContext context)
```

#### Parameters

`context` [IActionContext](DiceRoll.Models.Actions.IActionContext.md)

#### Returns

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

