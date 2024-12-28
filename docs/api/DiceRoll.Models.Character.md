# <a id="DiceRoll_Models_Character"></a> Class Character

Namespace: [DiceRoll.Models](DiceRoll.Models.md)  
Assembly: dice\-roll.dll  

Represents a character in the game with attributes, actions, and other properties.

```csharp
[Tool]
[GlobalClass]
[ScriptPath("res://models/Character/Character.cs")]
public class Character : Resource, IDisposable
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
GodotObject ← 
RefCounted ← 
Resource ← 
[Character](DiceRoll.Models.Character.md)

#### Implements

[IDisposable](https://learn.microsoft.com/dotnet/api/system.idisposable)

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

### <a id="DiceRoll_Models_Character__ctor"></a> Character\(\)

```csharp
public Character()
```

## Properties

### <a id="DiceRoll_Models_Character_Attributes"></a> Attributes

```csharp
[Export(PropertyHint.None, "")]
public Array<CharacterAttribute> Attributes { get; }
```

#### Property Value

 Array<[CharacterAttribute](DiceRoll.Models.CharacterAttribute.md)\>

### <a id="DiceRoll_Models_Character_CharacterActions"></a> CharacterActions

```csharp
[Export(PropertyHint.None, "")]
public Array<CharacterAction> CharacterActions { get; }
```

#### Property Value

 Array<[CharacterAction](DiceRoll.Models.CharacterActions.CharacterAction.md)\>

### <a id="DiceRoll_Models_Character_CharacterSprite"></a> CharacterSprite

```csharp
[Export(PropertyHint.None, "")]
public SpriteFrames? CharacterSprite { get; set; }
```

#### Property Value

 SpriteFrames?

### <a id="DiceRoll_Models_Character_DiceCapacity"></a> DiceCapacity

```csharp
[Export(PropertyHint.None, "")]
public int DiceCapacity { get; set; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRoll_Models_Character_Id"></a> Id

```csharp
[ExportGroup("🦸 Character", "")]
[Export(PropertyHint.None, "")]
public string Id { get; set; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)

### <a id="DiceRoll_Models_Character_IsEnemy"></a> IsEnemy

```csharp
[Export(PropertyHint.None, "")]
public bool IsEnemy { get; set; }
```

#### Property Value

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="DiceRoll_Models_Character_Name"></a> Name

```csharp
[Export(PropertyHint.None, "")]
public string? Name { get; set; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)?

### <a id="DiceRoll_Models_Character_Portrait"></a> Portrait

```csharp
[ExportGroup("🪵 Resources", "")]
[Export(PropertyHint.None, "")]
public Texture2D? Portrait { get; set; }
```

#### Property Value

 Texture2D?

### <a id="DiceRoll_Models_Character_Role"></a> Role

```csharp
[Export(PropertyHint.None, "")]
public Role? Role { get; set; }
```

#### Property Value

 [Role](DiceRoll.Models.Role.md)?

### <a id="DiceRoll_Models_Character_ShadowSprite"></a> ShadowSprite

```csharp
[Export(PropertyHint.None, "")]
public SpriteFrames? ShadowSprite { get; set; }
```

#### Property Value

 SpriteFrames?

### <a id="DiceRoll_Models_Character_ShowShadow"></a> ShowShadow

```csharp
[Export(PropertyHint.None, "")]
public bool ShowShadow { get; set; }
```

#### Property Value

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="DiceRoll_Models_Character_SpritePositionX"></a> SpritePositionX

```csharp
[Export(PropertyHint.None, "")]
public float SpritePositionX { get; set; }
```

#### Property Value

 [float](https://learn.microsoft.com/dotnet/api/system.single)

### <a id="DiceRoll_Models_Character_SpritePositionY"></a> SpritePositionY

```csharp
[Export(PropertyHint.None, "")]
public float SpritePositionY { get; set; }
```

#### Property Value

 [float](https://learn.microsoft.com/dotnet/api/system.single)

## Methods

### <a id="DiceRoll_Models_Character_EmitSignalAttributeChanged_DiceRoll_Models_Character_DiceRoll_Models_AttributeType_"></a> EmitSignalAttributeChanged\(Character, AttributeType\)

```csharp
protected void EmitSignalAttributeChanged(Character character, AttributeType attributeType)
```

#### Parameters

`character` [Character](DiceRoll.Models.Character.md)

`attributeType` [AttributeType](DiceRoll.Models.AttributeType.md)

### <a id="DiceRoll_Models_Character_GetAttributeBaseValue_DiceRoll_Models_AttributeType_"></a> GetAttributeBaseValue\(AttributeType\)

```csharp
public int GetAttributeBaseValue(AttributeType type)
```

#### Parameters

`type` [AttributeType](DiceRoll.Models.AttributeType.md)

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRoll_Models_Character_GetAttributeCurrentValue_DiceRoll_Models_AttributeType_"></a> GetAttributeCurrentValue\(AttributeType\)

```csharp
public int GetAttributeCurrentValue(AttributeType type)
```

#### Parameters

`type` [AttributeType](DiceRoll.Models.AttributeType.md)

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRoll_Models_Character_GetAttributeMaxValue_DiceRoll_Models_AttributeType_"></a> GetAttributeMaxValue\(AttributeType\)

```csharp
public int GetAttributeMaxValue(AttributeType type)
```

#### Parameters

`type` [AttributeType](DiceRoll.Models.AttributeType.md)

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRoll_Models_Character_InitializeActions"></a> InitializeActions\(\)

```csharp
public void InitializeActions()
```

### <a id="DiceRoll_Models_Character_InitializeAttributes"></a> InitializeAttributes\(\)

```csharp
public void InitializeAttributes()
```

### <a id="DiceRoll_Models_Character_UpdateAttributeCurrentValue_DiceRoll_Models_AttributeType_System_Int32_"></a> UpdateAttributeCurrentValue\(AttributeType, int\)

```csharp
public void UpdateAttributeCurrentValue(AttributeType type, int newValue)
```

#### Parameters

`type` [AttributeType](DiceRoll.Models.AttributeType.md)

`newValue` [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRoll_Models_Character_AttributeChanged"></a> AttributeChanged

```csharp
public event Character.AttributeChangedEventHandler AttributeChanged
```

#### Event Type

 [Character](DiceRoll.Models.Character.md).[AttributeChangedEventHandler](DiceRoll.Models.Character.AttributeChangedEventHandler.md)

