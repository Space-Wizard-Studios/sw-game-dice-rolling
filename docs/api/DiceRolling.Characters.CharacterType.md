# <a id="DiceRolling_Characters_CharacterType"></a> Class CharacterType

Namespace: [DiceRolling.Characters](DiceRolling.Characters.md)  
Assembly: dice\-rolling.dll  

```csharp
[Tool]
[GlobalClass]
[ScriptPath("res://features/Character/CharacterType.cs")]
public class CharacterType : Resource, IDisposable, ICharacter, ICharacterInformation, ICharacterPlacement, ICharacterAssets, ICharacterAttributes, ICharacterActions
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
GodotObject ← 
RefCounted ← 
Resource ← 
[CharacterType](DiceRolling.Characters.CharacterType.md)

#### Implements

[IDisposable](https://learn.microsoft.com/dotnet/api/system.idisposable), 
[ICharacter](DiceRolling.Characters.ICharacter.md), 
[ICharacterInformation](DiceRolling.Characters.ICharacterInformation.md), 
[ICharacterPlacement](DiceRolling.Characters.ICharacterPlacement.md), 
[ICharacterAssets](DiceRolling.Characters.ICharacterAssets.md), 
[ICharacterAttributes](DiceRolling.Characters.ICharacterAttributes.md), 
[ICharacterActions](DiceRolling.Characters.ICharacterActions.md)

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

## Properties

### <a id="DiceRolling_Characters_CharacterType_Actions"></a> Actions

Lista de ações da personagem.

```csharp
[Export(PropertyHint.None, "")]
public Array<CharacterAction> Actions { get; }
```

#### Property Value

 Array<[CharacterAction](DiceRolling.Characters.CharacterAction.md)\>

### <a id="DiceRolling_Characters_CharacterType_Attributes"></a> Attributes

Lista de atributos da personagem.

```csharp
[Export(PropertyHint.None, "")]
public Array<CharacterAttribute> Attributes { get; }
```

#### Property Value

 Array<[CharacterAttribute](DiceRolling.Characters.CharacterAttribute.md)\>

### <a id="DiceRolling_Characters_CharacterType_Category"></a> Category

Categoria do personagem.

```csharp
[Export(PropertyHint.None, "")]
public CharacterCategory? Category { get; set; }
```

#### Property Value

 [CharacterCategory](DiceRolling.Characters.CharacterCategory.md)?

### <a id="DiceRolling_Characters_CharacterType_CharacterSprite"></a> CharacterSprite

Sprite do personagem.

```csharp
[Export(PropertyHint.None, "")]
public SpriteFrames? CharacterSprite { get; set; }
```

#### Property Value

 SpriteFrames?

### <a id="DiceRolling_Characters_CharacterType_DiceCapacity"></a> DiceCapacity

Capacidade de dados do personagem.

```csharp
[Export(PropertyHint.None, "")]
public int DiceCapacity { get; set; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Characters_CharacterType_Id"></a> Id

Identificador único do personagem.

```csharp
[ExportGroup("🦸 Character", "")]
[Export(PropertyHint.None, "")]
public string Id { get; set; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)

### <a id="DiceRolling_Characters_CharacterType_Location"></a> Location

Localização do personagem no jogo.

```csharp
[ExportGroup("📍 Character Location", "")]
[Export(PropertyHint.None, "")]
public LocationType? Location { get; set; }
```

#### Property Value

 [LocationType](DiceRolling.Locations.LocationType.md)?

### <a id="DiceRolling_Characters_CharacterType_Name"></a> Name

Nome do personagem.

```csharp
[Export(PropertyHint.None, "")]
public string? Name { get; set; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)?

### <a id="DiceRolling_Characters_CharacterType_Portrait"></a> Portrait

Retrato do personagem.

```csharp
[ExportGroup("🪵 Resources", "")]
[Export(PropertyHint.None, "")]
public Texture2D? Portrait { get; set; }
```

#### Property Value

 Texture2D?

### <a id="DiceRolling_Characters_CharacterType_Role"></a> Role

Papel do personagem no jogo.

```csharp
[Export(PropertyHint.None, "")]
public RoleType? Role { get; set; }
```

#### Property Value

 [RoleType](DiceRolling.Roles.RoleType.md)?

### <a id="DiceRolling_Characters_CharacterType_ShadowSprite"></a> ShadowSprite

Sprite da sombra do personagem.

```csharp
[Export(PropertyHint.None, "")]
public SpriteFrames? ShadowSprite { get; set; }
```

#### Property Value

 SpriteFrames?

### <a id="DiceRolling_Characters_CharacterType_ShowShadow"></a> ShowShadow

Indica se a sombra do personagem deve ser exibida.

```csharp
[Export(PropertyHint.None, "")]
public bool ShowShadow { get; set; }
```

#### Property Value

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="DiceRolling_Characters_CharacterType_SlotIndex"></a> SlotIndex

Índice do slot onde o personagem está localizado.

```csharp
[Export(PropertyHint.None, "")]
public int SlotIndex { get; set; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Characters_CharacterType_SpritePositionX"></a> SpritePositionX

Posição X do sprite do personagem.

```csharp
[Export(PropertyHint.None, "")]
public float SpritePositionX { get; set; }
```

#### Property Value

 [float](https://learn.microsoft.com/dotnet/api/system.single)

### <a id="DiceRolling_Characters_CharacterType_SpritePositionY"></a> SpritePositionY

Posição Y do sprite do personagem.

```csharp
[Export(PropertyHint.None, "")]
public float SpritePositionY { get; set; }
```

#### Property Value

 [float](https://learn.microsoft.com/dotnet/api/system.single)

## Methods

### <a id="DiceRolling_Characters_CharacterType_AddAction_DiceRolling_Characters_CharacterAction_"></a> AddAction\(CharacterAction\)

Adiciona uma nova ação à personagem.

```csharp
public void AddAction(CharacterAction action)
```

#### Parameters

`action` [CharacterAction](DiceRolling.Characters.CharacterAction.md)

Ação a ser adicionada.

### <a id="DiceRolling_Characters_CharacterType_EmitSignalAttributeChanged_DiceRolling_Characters_CharacterType_DiceRolling_Attributes_AttributeType_"></a> EmitSignalAttributeChanged\(CharacterType, AttributeType\)

```csharp
protected void EmitSignalAttributeChanged(CharacterType character, AttributeType attributeType)
```

#### Parameters

`character` [CharacterType](DiceRolling.Characters.CharacterType.md)

`attributeType` [AttributeType](DiceRolling.Attributes.AttributeType.md)

### <a id="DiceRolling_Characters_CharacterType_GetAttributeBaseValue_DiceRolling_Attributes_AttributeType_"></a> GetAttributeBaseValue\(AttributeType\)

Obtém o valor base de um atributo.

```csharp
public int GetAttributeBaseValue(AttributeType type)
```

#### Parameters

`type` [AttributeType](DiceRolling.Attributes.AttributeType.md)

Tipo do atributo.

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

Valor base do atributo.

### <a id="DiceRolling_Characters_CharacterType_GetAttributeCurrentValue_DiceRolling_Attributes_AttributeType_"></a> GetAttributeCurrentValue\(AttributeType\)

Obtém o valor atual de um atributo.

```csharp
public int GetAttributeCurrentValue(AttributeType type)
```

#### Parameters

`type` [AttributeType](DiceRolling.Attributes.AttributeType.md)

Tipo do atributo.

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

Valor atual do atributo.

### <a id="DiceRolling_Characters_CharacterType_GetAttributeMaxValue_DiceRolling_Attributes_AttributeType_"></a> GetAttributeMaxValue\(AttributeType\)

Obtém o valor máximo de um atributo.

```csharp
public int GetAttributeMaxValue(AttributeType type)
```

#### Parameters

`type` [AttributeType](DiceRolling.Attributes.AttributeType.md)

Tipo do atributo.

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

Valor máximo do atributo.

### <a id="DiceRolling_Characters_CharacterType_InitializeActions"></a> InitializeActions\(\)

Inicializa as ações da personagem.

```csharp
public void InitializeActions()
```

### <a id="DiceRolling_Characters_CharacterType_InitializeAttributes"></a> InitializeAttributes\(\)

Inicializa os atributos da personagem.

```csharp
public void InitializeAttributes()
```

### <a id="DiceRolling_Characters_CharacterType_RemoveAction_DiceRolling_Characters_CharacterAction_"></a> RemoveAction\(CharacterAction\)

Remove uma ação da personagem.

```csharp
public void RemoveAction(CharacterAction action)
```

#### Parameters

`action` [CharacterAction](DiceRolling.Characters.CharacterAction.md)

Ação a ser removida.

### <a id="DiceRolling_Characters_CharacterType_UpdateAttributeCurrentValue_DiceRolling_Attributes_AttributeType_System_Int32_"></a> UpdateAttributeCurrentValue\(AttributeType, int\)

Atualiza o valor atual de um atributo.

```csharp
public void UpdateAttributeCurrentValue(AttributeType type, int newValue)
```

#### Parameters

`type` [AttributeType](DiceRolling.Attributes.AttributeType.md)

Tipo do atributo.

`newValue` [int](https://learn.microsoft.com/dotnet/api/system.int32)

Novo valor do atributo.

### <a id="DiceRolling_Characters_CharacterType_AttributeChanged"></a> AttributeChanged

```csharp
public event CharacterType.AttributeChangedEventHandler AttributeChanged
```

#### Event Type

 [CharacterType](DiceRolling.Characters.CharacterType.md).[AttributeChangedEventHandler](DiceRolling.Characters.CharacterType.AttributeChangedEventHandler.md)

