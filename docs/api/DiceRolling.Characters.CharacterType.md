# <a id="DiceRolling_Characters_CharacterType"></a> Class CharacterType

Namespace: [DiceRolling.Characters](DiceRolling.Characters.md)  
Assembly: dice\-rolling.dll  

Representa um tipo de personagem no jogo e inclui suas informações, atributos, ações, recursos visuais, localização e papel.
Esta classe também fornece métodos para inicializar e gerenciar esses aspectos.

```csharp
[Tool]
[GlobalClass]
[ScriptPath("res://features/Character/CharacterType.cs")]
public class CharacterType : IdentifiableResource, IDisposable, ICharacter, IIdentifiable, ICharacterInformationSheet, ICharacterPlacementSheet, ICharacterAssetSheet, ICharacterRoleSheet, ICharacterAttributeSheet, ICharacterActionSheet
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
GodotObject ← 
RefCounted ← 
Resource ← 
[IdentifiableResource](DiceRolling.Common.IdentifiableResource.md) ← 
[CharacterType](DiceRolling.Characters.CharacterType.md)

#### Implements

[IDisposable](https://learn.microsoft.com/dotnet/api/system.idisposable), 
[ICharacter](DiceRolling.Characters.ICharacter.md), 
[IIdentifiable](DiceRolling.Common.IIdentifiable.md), 
[ICharacterInformationSheet](DiceRolling.Characters.ICharacterInformationSheet.md), 
[ICharacterPlacementSheet](DiceRolling.Characters.ICharacterPlacementSheet.md), 
[ICharacterAssetSheet](DiceRolling.Characters.ICharacterAssetSheet.md), 
[ICharacterRoleSheet](DiceRolling.Characters.ICharacterRoleSheet.md), 
[ICharacterAttributeSheet](DiceRolling.Characters.ICharacterAttributeSheet.md), 
[ICharacterActionSheet](DiceRolling.Characters.ICharacterActionSheet.md)

#### Inherited Members

[IdentifiableResource.Id](DiceRolling.Common.IdentifiableResource.md\#DiceRolling\_Common\_IdentifiableResource\_Id), 
[IdentifiableResource.GenerateNewIdButton](DiceRolling.Common.IdentifiableResource.md\#DiceRolling\_Common\_IdentifiableResource\_GenerateNewIdButton), 
[IdentifiableResource.GenerateNewId\(\)](DiceRolling.Common.IdentifiableResource.md\#DiceRolling\_Common\_IdentifiableResource\_GenerateNewId), 
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

### <a id="DiceRolling_Characters_CharacterType__ctor"></a> CharacterType\(\)

```csharp
public CharacterType()
```

### <a id="DiceRolling_Characters_CharacterType__ctor_System_String_DiceRolling_Roles_RoleType_"></a> CharacterType\(string, RoleType\)

```csharp
public CharacterType(string name, RoleType role)
```

#### Parameters

`name` [string](https://learn.microsoft.com/dotnet/api/system.string)

`role` [RoleType](DiceRolling.Roles.RoleType.md)

## Properties

### <a id="DiceRolling_Characters_CharacterType_Actions"></a> Actions

```csharp
[ExportGroup("🔥 Actions", "")]
[Export(PropertyHint.None, "")]
public Array<CharacterAction> Actions { get; }
```

#### Property Value

 Array<[CharacterAction](DiceRolling.Characters.CharacterAction.md)\>

### <a id="DiceRolling_Characters_CharacterType_Attributes"></a> Attributes

```csharp
[ExportGroup("📊 Attributes", "")]
[Export(PropertyHint.None, "")]
public Array<CharacterAttribute> Attributes { get; }
```

#### Property Value

 Array<[CharacterAttribute](DiceRolling.Characters.CharacterAttribute.md)\>

### <a id="DiceRolling_Characters_CharacterType_Category"></a> Category

```csharp
[Export(PropertyHint.None, "")]
public CharacterCategory? Category { get; set; }
```

#### Property Value

 [CharacterCategory](DiceRolling.Characters.CharacterCategory.md)?

### <a id="DiceRolling_Characters_CharacterType_CharacterSprite"></a> CharacterSprite

```csharp
[Export(PropertyHint.None, "")]
public SpriteFrames? CharacterSprite { get; set; }
```

#### Property Value

 SpriteFrames?

### <a id="DiceRolling_Characters_CharacterType_Location"></a> Location

```csharp
[ExportGroup("📍 Placement", "")]
[Export(PropertyHint.None, "")]
public LocationType? Location { get; set; }
```

#### Property Value

 [LocationType](DiceRolling.Locations.LocationType.md)?

### <a id="DiceRolling_Characters_CharacterType_Name"></a> Name

```csharp
[ExportGroup("📝 Information", "")]
[Export(PropertyHint.None, "")]
public string Name { get; set; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)

### <a id="DiceRolling_Characters_CharacterType_Portrait"></a> Portrait

```csharp
[ExportGroup("🪵 Assets", "")]
[Export(PropertyHint.None, "")]
public Texture2D? Portrait { get; set; }
```

#### Property Value

 Texture2D?

### <a id="DiceRolling_Characters_CharacterType_Role"></a> Role

```csharp
[ExportGroup("🦸‍♂ Role", "")]
[Export(PropertyHint.None, "")]
public RoleType? Role { get; set; }
```

#### Property Value

 [RoleType](DiceRolling.Roles.RoleType.md)?

### <a id="DiceRolling_Characters_CharacterType_ShadowSprite"></a> ShadowSprite

```csharp
[Export(PropertyHint.None, "")]
public SpriteFrames? ShadowSprite { get; set; }
```

#### Property Value

 SpriteFrames?

### <a id="DiceRolling_Characters_CharacterType_ShowShadow"></a> ShowShadow

```csharp
[Export(PropertyHint.None, "")]
public bool ShowShadow { get; set; }
```

#### Property Value

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="DiceRolling_Characters_CharacterType_SlotIndex"></a> SlotIndex

```csharp
[Export(PropertyHint.None, "")]
public int SlotIndex { get; set; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Characters_CharacterType_SpritePositionX"></a> SpritePositionX

```csharp
[Export(PropertyHint.None, "")]
public float SpritePositionX { get; set; }
```

#### Property Value

 [float](https://learn.microsoft.com/dotnet/api/system.single)

### <a id="DiceRolling_Characters_CharacterType_SpritePositionY"></a> SpritePositionY

```csharp
[Export(PropertyHint.None, "")]
public float SpritePositionY { get; set; }
```

#### Property Value

 [float](https://learn.microsoft.com/dotnet/api/system.single)

## Methods

### <a id="DiceRolling_Characters_CharacterType_AddAction_DiceRolling_Characters_CharacterAction_"></a> AddAction\(CharacterAction\)

```csharp
public void AddAction(CharacterAction action)
```

#### Parameters

`action` [CharacterAction](DiceRolling.Characters.CharacterAction.md)

### <a id="DiceRolling_Characters_CharacterType_EmitSignalAttributeChanged_DiceRolling_Characters_CharacterType_DiceRolling_Attributes_AttributeType_"></a> EmitSignalAttributeChanged\(CharacterType, AttributeType\)

```csharp
protected void EmitSignalAttributeChanged(CharacterType character, AttributeType attributeType)
```

#### Parameters

`character` [CharacterType](DiceRolling.Characters.CharacterType.md)

`attributeType` [AttributeType](DiceRolling.Attributes.AttributeType.md)

### <a id="DiceRolling_Characters_CharacterType_GetAttributeBaseValue_DiceRolling_Attributes_AttributeType_"></a> GetAttributeBaseValue\(AttributeType\)

```csharp
public int GetAttributeBaseValue(AttributeType type)
```

#### Parameters

`type` [AttributeType](DiceRolling.Attributes.AttributeType.md)

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Characters_CharacterType_GetAttributeCurrentValue_DiceRolling_Attributes_AttributeType_"></a> GetAttributeCurrentValue\(AttributeType\)

```csharp
public int GetAttributeCurrentValue(AttributeType type)
```

#### Parameters

`type` [AttributeType](DiceRolling.Attributes.AttributeType.md)

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Characters_CharacterType_GetAttributeMaxValue_DiceRolling_Attributes_AttributeType_"></a> GetAttributeMaxValue\(AttributeType\)

```csharp
public int GetAttributeMaxValue(AttributeType type)
```

#### Parameters

`type` [AttributeType](DiceRolling.Attributes.AttributeType.md)

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Characters_CharacterType_InitializeActions"></a> InitializeActions\(\)

```csharp
public void InitializeActions()
```

### <a id="DiceRolling_Characters_CharacterType_InitializeAttributes"></a> InitializeAttributes\(\)

```csharp
public void InitializeAttributes()
```

### <a id="DiceRolling_Characters_CharacterType_RemoveAction_DiceRolling_Characters_CharacterAction_"></a> RemoveAction\(CharacterAction\)

```csharp
public void RemoveAction(CharacterAction action)
```

#### Parameters

`action` [CharacterAction](DiceRolling.Characters.CharacterAction.md)

### <a id="DiceRolling_Characters_CharacterType_UpdateAttributeCurrentValue_DiceRolling_Attributes_AttributeType_System_Int32_"></a> UpdateAttributeCurrentValue\(AttributeType, int\)

```csharp
public void UpdateAttributeCurrentValue(AttributeType type, int newValue)
```

#### Parameters

`type` [AttributeType](DiceRolling.Attributes.AttributeType.md)

`newValue` [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Characters_CharacterType_ValidateConstructor"></a> ValidateConstructor\(\)

Valida os campos do resource.

```csharp
public void ValidateConstructor()
```

### <a id="DiceRolling_Characters_CharacterType_AttributeChanged"></a> AttributeChanged

```csharp
public event CharacterType.AttributeChangedEventHandler AttributeChanged
```

#### Event Type

 [CharacterType](DiceRolling.Characters.CharacterType.md).[AttributeChangedEventHandler](DiceRolling.Characters.CharacterType.AttributeChangedEventHandler.md)

