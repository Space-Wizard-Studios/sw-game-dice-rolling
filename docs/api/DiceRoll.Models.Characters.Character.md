# <a id="DiceRoll_Models_Characters_Character"></a> Class Character

Namespace: [DiceRoll.Models.Characters](DiceRoll.Models.Characters.md)  
Assembly: dice\-roll.dll  

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
[Character](DiceRoll.Models.Characters.Character.md)

#### Implements

[IDisposable](https://learn.microsoft.com/dotnet/api/system.idisposable)

#### Inherited Members

Resource.\_GetRid\(\), 
Resource.\_ResetState\(\), 
Resource.\_SetPathCache\(string\), 
Resource.\_SetupLocalToScene\(\), 
Resource.SetPath\(string\), 
Resource.TakeOverPath\(string\), 
Resource.GetPath\(\), 
Resource.SetPathCache\(string\), 
Resource.SetName\(string\), 
Resource.GetName\(\), 
Resource.GetRid\(\), 
Resource.SetLocalToScene\(bool\), 
Resource.IsLocalToScene\(\), 
Resource.GetLocalScene\(\), 
Resource.SetupLocalToScene\(\), 
Resource.ResetState\(\), 
Resource.SetIdForPath\(string, string\), 
Resource.GetIdForPath\(string\), 
Resource.IsBuiltIn\(\), 
Resource.GenerateSceneUniqueId\(\), 
Resource.SetSceneUniqueId\(string\), 
Resource.GetSceneUniqueId\(\), 
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

## Constructors

### <a id="DiceRoll_Models_Characters_Character__ctor"></a> Character\(\)

```csharp
public Character()
```

## Properties

### <a id="DiceRoll_Models_Characters_Character_Actions"></a> Actions

```csharp
[Export(PropertyHint.None, "")]
public Array<CharacterAction> Actions { get; }
```

#### Property Value

 Array<[CharacterAction](DiceRoll.Models.Actions.CharacterAction.md)\>

### <a id="DiceRoll_Models_Characters_Character_Attributes"></a> Attributes

```csharp
[Export(PropertyHint.None, "")]
public Array<CharacterAttribute> Attributes { get; }
```

#### Property Value

 Array<[CharacterAttribute](DiceRoll.Models.Attributes.CharacterAttribute.md)\>

### <a id="DiceRoll_Models_Characters_Character_CharacterSprite"></a> CharacterSprite

```csharp
[Export(PropertyHint.None, "")]
public SpriteFrames? CharacterSprite { get; set; }
```

#### Property Value

 SpriteFrames?

### <a id="DiceRoll_Models_Characters_Character_DiceCapacity"></a> DiceCapacity

```csharp
[Export(PropertyHint.None, "")]
public int DiceCapacity { get; set; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRoll_Models_Characters_Character_Id"></a> Id

```csharp
[ExportGroup("🦸 Character", "")]
[Export(PropertyHint.None, "")]
public string Id { get; set; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)

### <a id="DiceRoll_Models_Characters_Character_IsEnemy"></a> IsEnemy

```csharp
[Export(PropertyHint.None, "")]
public bool IsEnemy { get; set; }
```

#### Property Value

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="DiceRoll_Models_Characters_Character_Location"></a> Location

```csharp
[ExportGroup("📍 Character Location", "")]
[Export(PropertyHint.None, "")]
public CharacterLocation? Location { get; set; }
```

#### Property Value

 [CharacterLocation](DiceRoll.Models.Characters.Locations.CharacterLocation.md)?

### <a id="DiceRoll_Models_Characters_Character_Name"></a> Name

```csharp
[Export(PropertyHint.None, "")]
public string? Name { get; set; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)?

### <a id="DiceRoll_Models_Characters_Character_Portrait"></a> Portrait

```csharp
[ExportGroup("🪵 Resources", "")]
[Export(PropertyHint.None, "")]
public Texture2D? Portrait { get; set; }
```

#### Property Value

 Texture2D?

### <a id="DiceRoll_Models_Characters_Character_Role"></a> Role

```csharp
[Export(PropertyHint.None, "")]
public Role? Role { get; set; }
```

#### Property Value

 [Role](DiceRoll.Models.Roles.Role.md)?

### <a id="DiceRoll_Models_Characters_Character_ShadowSprite"></a> ShadowSprite

```csharp
[Export(PropertyHint.None, "")]
public SpriteFrames? ShadowSprite { get; set; }
```

#### Property Value

 SpriteFrames?

### <a id="DiceRoll_Models_Characters_Character_ShowShadow"></a> ShowShadow

```csharp
[Export(PropertyHint.None, "")]
public bool ShowShadow { get; set; }
```

#### Property Value

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="DiceRoll_Models_Characters_Character_SlotIndex"></a> SlotIndex

```csharp
[Export(PropertyHint.None, "")]
public int SlotIndex { get; set; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRoll_Models_Characters_Character_SpritePositionX"></a> SpritePositionX

```csharp
[Export(PropertyHint.None, "")]
public float SpritePositionX { get; set; }
```

#### Property Value

 [float](https://learn.microsoft.com/dotnet/api/system.single)

### <a id="DiceRoll_Models_Characters_Character_SpritePositionY"></a> SpritePositionY

```csharp
[Export(PropertyHint.None, "")]
public float SpritePositionY { get; set; }
```

#### Property Value

 [float](https://learn.microsoft.com/dotnet/api/system.single)

## Methods

### <a id="DiceRoll_Models_Characters_Character_EmitSignalAttributeChanged_DiceRoll_Models_Characters_Character_DiceRoll_Models_Attributes_AttributeType_"></a> EmitSignalAttributeChanged\(Character, AttributeType\)

```csharp
protected void EmitSignalAttributeChanged(Character character, AttributeType attributeType)
```

#### Parameters

`character` [Character](DiceRoll.Models.Characters.Character.md)

`attributeType` [AttributeType](DiceRoll.Models.Attributes.AttributeType.md)

### <a id="DiceRoll_Models_Characters_Character_GetAttributeBaseValue_DiceRoll_Models_Attributes_AttributeType_"></a> GetAttributeBaseValue\(AttributeType\)

```csharp
public int GetAttributeBaseValue(AttributeType type)
```

#### Parameters

`type` [AttributeType](DiceRoll.Models.Attributes.AttributeType.md)

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRoll_Models_Characters_Character_GetAttributeCurrentValue_DiceRoll_Models_Attributes_AttributeType_"></a> GetAttributeCurrentValue\(AttributeType\)

```csharp
public int GetAttributeCurrentValue(AttributeType type)
```

#### Parameters

`type` [AttributeType](DiceRoll.Models.Attributes.AttributeType.md)

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRoll_Models_Characters_Character_GetAttributeMaxValue_DiceRoll_Models_Attributes_AttributeType_"></a> GetAttributeMaxValue\(AttributeType\)

```csharp
public int GetAttributeMaxValue(AttributeType type)
```

#### Parameters

`type` [AttributeType](DiceRoll.Models.Attributes.AttributeType.md)

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRoll_Models_Characters_Character_GetGodotClassPropertyValue_Godot_NativeInterop_godot_string_name__Godot_NativeInterop_godot_variant__"></a> GetGodotClassPropertyValue\(in godot\_string\_name, out godot\_variant\)

Get the value of a property contained in this class.
This method is used by Godot to retrieve property values.
Do not call or override this method.

```csharp
[EditorBrowsable(EditorBrowsableState.Never)]
protected override bool GetGodotClassPropertyValue(in godot_string_name name, out godot_variant value)
```

#### Parameters

`name` godot\_string\_name

Name of the property to get.

`value` godot\_variant

Value of the property if it was found.

#### Returns

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

<a href="https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool">true</a> if a property with the given name was found.

### <a id="DiceRoll_Models_Characters_Character_HasGodotClassMethod_Godot_NativeInterop_godot_string_name__"></a> HasGodotClassMethod\(in godot\_string\_name\)

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

### <a id="DiceRoll_Models_Characters_Character_HasGodotClassSignal_Godot_NativeInterop_godot_string_name__"></a> HasGodotClassSignal\(in godot\_string\_name\)

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

### <a id="DiceRoll_Models_Characters_Character_InitializeActions"></a> InitializeActions\(\)

```csharp
public void InitializeActions()
```

### <a id="DiceRoll_Models_Characters_Character_InitializeAttributes"></a> InitializeAttributes\(\)

```csharp
public void InitializeAttributes()
```

### <a id="DiceRoll_Models_Characters_Character_InvokeGodotClassMethod_Godot_NativeInterop_godot_string_name__Godot_NativeInterop_NativeVariantPtrArgs_Godot_NativeInterop_godot_variant__"></a> InvokeGodotClassMethod\(in godot\_string\_name, NativeVariantPtrArgs, out godot\_variant\)

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

### <a id="DiceRoll_Models_Characters_Character_RaiseGodotClassSignalCallbacks_Godot_NativeInterop_godot_string_name__Godot_NativeInterop_NativeVariantPtrArgs_"></a> RaiseGodotClassSignalCallbacks\(in godot\_string\_name, NativeVariantPtrArgs\)

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

### <a id="DiceRoll_Models_Characters_Character_RestoreGodotObjectData_Godot_Bridge_GodotSerializationInfo_"></a> RestoreGodotObjectData\(GodotSerializationInfo\)

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

### <a id="DiceRoll_Models_Characters_Character_SaveGodotObjectData_Godot_Bridge_GodotSerializationInfo_"></a> SaveGodotObjectData\(GodotSerializationInfo\)

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

### <a id="DiceRoll_Models_Characters_Character_SetGodotClassPropertyValue_Godot_NativeInterop_godot_string_name__Godot_NativeInterop_godot_variant__"></a> SetGodotClassPropertyValue\(in godot\_string\_name, in godot\_variant\)

Set the value of a property contained in this class.
This method is used by Godot to assign property values.
Do not call or override this method.

```csharp
[EditorBrowsable(EditorBrowsableState.Never)]
protected override bool SetGodotClassPropertyValue(in godot_string_name name, in godot_variant value)
```

#### Parameters

`name` godot\_string\_name

Name of the property to set.

`value` godot\_variant

Value to set the property to if it was found.

#### Returns

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

<a href="https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool">true</a> if a property with the given name was found.

### <a id="DiceRoll_Models_Characters_Character_UpdateAttributeCurrentValue_DiceRoll_Models_Attributes_AttributeType_System_Int32_"></a> UpdateAttributeCurrentValue\(AttributeType, int\)

```csharp
public void UpdateAttributeCurrentValue(AttributeType type, int newValue)
```

#### Parameters

`type` [AttributeType](DiceRoll.Models.Attributes.AttributeType.md)

`newValue` [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRoll_Models_Characters_Character_AttributeChanged"></a> AttributeChanged

```csharp
public event Character.AttributeChangedEventHandler AttributeChanged
```

#### Event Type

 [Character](DiceRoll.Models.Characters.Character.md).[AttributeChangedEventHandler](DiceRoll.Models.Characters.Character.AttributeChangedEventHandler.md)

