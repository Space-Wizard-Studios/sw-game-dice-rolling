# <a id="DiceRolling_Actions_ActionType"></a> Class ActionType

Namespace: [DiceRolling.Actions](DiceRolling.Actions.md)  
Assembly: dice\-rolling.dll  

```csharp
[Tool]
[GlobalClass]
[ScriptPath("res://features/Action/ActionType.cs")]
public class ActionType : IdentifiableResource, IDisposable, IAction<IActionContext, bool>, IIdentifiable, IActionInformation, IActionAssets, IActionBehavior<IActionContext, bool>
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
GodotObject ← 
RefCounted ← 
Resource ← 
[IdentifiableResource](DiceRolling.Common.IdentifiableResource.md) ← 
[ActionType](DiceRolling.Actions.ActionType.md)

#### Implements

[IDisposable](https://learn.microsoft.com/dotnet/api/system.idisposable), 
[IAction<IActionContext, bool\>](DiceRolling.Actions.IAction\-2.md), 
[IIdentifiable](DiceRolling.Common.IIdentifiable.md), 
[IActionInformation](DiceRolling.Actions.IActionInformation.md), 
[IActionAssets](DiceRolling.Actions.IActionAssets.md), 
[IActionBehavior<IActionContext, bool\>](DiceRolling.Actions.IActionBehavior\-2.md)

#### Inherited Members

[IdentifiableResource.Id](DiceRolling.Common.IdentifiableResource.md\#DiceRolling\_Common\_IdentifiableResource\_Id), 
[IdentifiableResource.GenerateNewIdButton](DiceRolling.Common.IdentifiableResource.md\#DiceRolling\_Common\_IdentifiableResource\_GenerateNewIdButton), 
[IdentifiableResource.GenerateNewId\(\)](DiceRolling.Common.IdentifiableResource.md\#DiceRolling\_Common\_IdentifiableResource\_GenerateNewId), 
[IdentifiableResource.EnsureValidId\(\)](DiceRolling.Common.IdentifiableResource.md\#DiceRolling\_Common\_IdentifiableResource\_EnsureValidId), 
[IdentifiableResource.\_ValidateProperty\(Dictionary\)](DiceRolling.Common.IdentifiableResource.md\#DiceRolling\_Common\_IdentifiableResource\_\_ValidateProperty\_Godot\_Collections\_Dictionary\_), 
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

### <a id="DiceRolling_Actions_ActionType__ctor"></a> ActionType\(\)

```csharp
public ActionType()
```

### <a id="DiceRolling_Actions_ActionType__ctor_DiceRolling_Actions_ActionCategory_Godot_Collections_Array_DiceRolling_Dice_DiceMana__Godot_Collections_Array_DiceRolling_Effects_EffectType__System_String_System_String_Godot_Texture2D_DiceRolling_Targets_TargetConfiguration_"></a> ActionType\(ActionCategory, Array<DiceMana\>, Array<EffectType\>, string?, string?, Texture2D?, TargetConfiguration?\)

```csharp
public ActionType(ActionCategory category, Array<DiceMana> requiredMana, Array<EffectType> effects, string? name = null, string? description = null, Texture2D? icon = null, TargetConfiguration? targetConfiguration = null)
```

#### Parameters

`category` [ActionCategory](DiceRolling.Actions.ActionCategory.md)

`requiredMana` Array<[DiceMana](DiceRolling.Dice.DiceMana.md)\>

`effects` Array<[EffectType](DiceRolling.Effects.EffectType.md)\>

`name` [string](https://learn.microsoft.com/dotnet/api/system.string)?

`description` [string](https://learn.microsoft.com/dotnet/api/system.string)?

`icon` Texture2D?

`targetConfiguration` [TargetConfiguration](DiceRolling.Targets.TargetConfiguration.md)?

## Properties

### <a id="DiceRolling_Actions_ActionType_Category"></a> Category

Categoria da ação.

```csharp
[ExportGroup("📝 Information", "")]
[Export(PropertyHint.None, "")]
public ActionCategory? Category { get; set; }
```

#### Property Value

 [ActionCategory](DiceRolling.Actions.ActionCategory.md)?

### <a id="DiceRolling_Actions_ActionType_Description"></a> Description

Descrição da ação.

```csharp
[Export(PropertyHint.MultilineText, "")]
public string? Description { get; set; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)?

### <a id="DiceRolling_Actions_ActionType_Effects"></a> Effects

Efeitos da ação.

```csharp
[Export(PropertyHint.None, "")]
public Array<EffectType> Effects { get; set; }
```

#### Property Value

 Array<[EffectType](DiceRolling.Effects.EffectType.md)\>

### <a id="DiceRolling_Actions_ActionType_Icon"></a> Icon

Ícone da ação.

```csharp
[Export(PropertyHint.None, "")]
public Texture2D? Icon { get; set; }
```

#### Property Value

 Texture2D?

### <a id="DiceRolling_Actions_ActionType_IconPath"></a> IconPath

Caminho do ícone da ação.

```csharp
public string? IconPath { get; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)?

### <a id="DiceRolling_Actions_ActionType_Name"></a> Name

Nome da ação.

```csharp
[Export(PropertyHint.None, "")]
public string? Name { get; set; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)?

### <a id="DiceRolling_Actions_ActionType_RequiredMana"></a> RequiredMana

Mana necessária para executar a ação.

```csharp
[ExportGroup("🎭 Behavior", "")]
[Export(PropertyHint.None, "")]
public Array<DiceMana> RequiredMana { get; set; }
```

#### Property Value

 Array<[DiceMana](DiceRolling.Dice.DiceMana.md)\>

### <a id="DiceRolling_Actions_ActionType_TargetConfiguration"></a> TargetConfiguration

Configuração de alvo da ação.

```csharp
[Export(PropertyHint.None, "")]
public TargetConfiguration? TargetConfiguration { get; set; }
```

#### Property Value

 [TargetConfiguration](DiceRolling.Targets.TargetConfiguration.md)?

## Methods

### <a id="DiceRolling_Actions_ActionType_AddEffect_DiceRolling_Effects_EffectType_"></a> AddEffect\(EffectType\)

```csharp
public void AddEffect(EffectType effect)
```

#### Parameters

`effect` [EffectType](DiceRolling.Effects.EffectType.md)

### <a id="DiceRolling_Actions_ActionType_Do_DiceRolling_Actions_IActionContext_"></a> Do\(IActionContext\)

Executa a ação com o contexto fornecido.

```csharp
public bool Do(IActionContext context)
```

#### Parameters

`context` [IActionContext](DiceRolling.Actions.IActionContext.md)

O contexto da ação.

#### Returns

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

O resultado da ação.

### <a id="DiceRolling_Actions_ActionType_IsValid"></a> IsValid\(\)

```csharp
public bool IsValid()
```

#### Returns

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="DiceRolling_Actions_ActionType_RemoveEffect_DiceRolling_Effects_EffectType_"></a> RemoveEffect\(EffectType\)

```csharp
public void RemoveEffect(EffectType effect)
```

#### Parameters

`effect` [EffectType](DiceRolling.Effects.EffectType.md)

