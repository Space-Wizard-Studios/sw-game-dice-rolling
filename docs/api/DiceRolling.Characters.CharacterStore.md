# <a id="DiceRolling_Characters_CharacterStore"></a> Class CharacterStore

Namespace: [DiceRolling.Characters](DiceRolling.Characters.md)  
Assembly: dice\-rolling.dll  

```csharp
[Tool]
[GlobalClass]
[ScriptPath("res://features/Character/CharacterStore.cs")]
public class CharacterStore : Resource, IDisposable
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
GodotObject ← 
RefCounted ← 
Resource ← 
[CharacterStore](DiceRolling.Characters.CharacterStore.md)

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

### <a id="DiceRolling_Characters_CharacterStore__ctor"></a> CharacterStore\(\)

```csharp
public CharacterStore()
```

## Properties

### <a id="DiceRolling_Characters_CharacterStore_Characters"></a> Characters

```csharp
[Export(PropertyHint.None, "")]
public Array<CharacterType> Characters { get; }
```

#### Property Value

 Array<[CharacterType](DiceRolling.Characters.CharacterType.md)\>

### <a id="DiceRolling_Characters_CharacterStore_Instance"></a> Instance

```csharp
public static CharacterStore Instance { get; }
```

#### Property Value

 [CharacterStore](DiceRolling.Characters.CharacterStore.md)

## Methods

### <a id="DiceRolling_Characters_CharacterStore_AddCharacter_DiceRolling_Characters_CharacterType_"></a> AddCharacter\(CharacterType\)

```csharp
public void AddCharacter(CharacterType character)
```

#### Parameters

`character` [CharacterType](DiceRolling.Characters.CharacterType.md)

### <a id="DiceRolling_Characters_CharacterStore_GetAllCharacterIds"></a> GetAllCharacterIds\(\)

```csharp
public Array<string> GetAllCharacterIds()
```

#### Returns

 Array<[string](https://learn.microsoft.com/dotnet/api/system.string)\>

### <a id="DiceRolling_Characters_CharacterStore_GetCharacterById_System_String_"></a> GetCharacterById\(string\)

```csharp
public CharacterType GetCharacterById(string characterID)
```

#### Parameters

`characterID` [string](https://learn.microsoft.com/dotnet/api/system.string)

#### Returns

 [CharacterType](DiceRolling.Characters.CharacterType.md)

### <a id="DiceRolling_Characters_CharacterStore_GetLocationType_System_String_"></a> GetLocationType\(string\)

```csharp
public (LocationType? location, int slotIndex) GetLocationType(string characterID)
```

#### Parameters

`characterID` [string](https://learn.microsoft.com/dotnet/api/system.string)

#### Returns

 \([LocationType](DiceRolling.Locations.LocationType.md)? [location](https://learn.microsoft.com/dotnet/api/system.valuetuple\-dicerolling.locations.locationtype,system.int32\-.location), [int](https://learn.microsoft.com/dotnet/api/system.int32) [slotIndex](https://learn.microsoft.com/dotnet/api/system.valuetuple\-dicerolling.locations.locationtype,system.int32\-.slotindex)\)

### <a id="DiceRolling_Characters_CharacterStore_RemoveCharacter_System_String_"></a> RemoveCharacter\(string\)

```csharp
public void RemoveCharacter(string characterID)
```

#### Parameters

`characterID` [string](https://learn.microsoft.com/dotnet/api/system.string)

### <a id="DiceRolling_Characters_CharacterStore_SetLocationType_System_String_DiceRolling_Locations_LocationType_System_Int32_"></a> SetLocationType\(string, LocationType, int\)

```csharp
public void SetLocationType(string characterID, LocationType location, int slotIndex)
```

#### Parameters

`characterID` [string](https://learn.microsoft.com/dotnet/api/system.string)

`location` [LocationType](DiceRolling.Locations.LocationType.md)

`slotIndex` [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Characters_CharacterStore_UpdateCharacter_System_String_Godot_Collections_Dictionary_System_String_Godot_Variant__"></a> UpdateCharacter\(string, Dictionary<string, Variant\>\)

```csharp
public void UpdateCharacter(string characterID, Dictionary<string, Variant> updatedFields)
```

#### Parameters

`characterID` [string](https://learn.microsoft.com/dotnet/api/system.string)

`updatedFields` Dictionary<[string](https://learn.microsoft.com/dotnet/api/system.string), Variant\>

