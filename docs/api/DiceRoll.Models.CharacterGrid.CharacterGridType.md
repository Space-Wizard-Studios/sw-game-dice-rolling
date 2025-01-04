# <a id="DiceRoll_Models_CharacterGrid_CharacterGridType"></a> Class CharacterGridType

Namespace: [DiceRoll.Models.CharacterGrid](DiceRoll.Models.CharacterGrid.md)  
Assembly: dice\-roll.dll  

```csharp
[Tool]
[GlobalClass]
[ScriptPath("res://models/CharacterGrid/CharacterGridType.cs")]
public class CharacterGridType : Resource, IDisposable
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
GodotObject ← 
RefCounted ← 
Resource ← 
[CharacterGridType](DiceRoll.Models.CharacterGrid.CharacterGridType.md)

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

### <a id="DiceRoll_Models_CharacterGrid_CharacterGridType__ctor"></a> CharacterGridType\(\)

```csharp
public CharacterGridType()
```

### <a id="DiceRoll_Models_CharacterGrid_CharacterGridType__ctor_System_Int32_System_Int32_System_Int32_System_String_"></a> CharacterGridType\(int, int, int, string\)

```csharp
public CharacterGridType(int columns, int rows, int offset, string prefix)
```

#### Parameters

`columns` [int](https://learn.microsoft.com/dotnet/api/system.int32)

`rows` [int](https://learn.microsoft.com/dotnet/api/system.int32)

`offset` [int](https://learn.microsoft.com/dotnet/api/system.int32)

`prefix` [string](https://learn.microsoft.com/dotnet/api/system.string)

## Fields

### <a id="DiceRoll_Models_CharacterGrid_CharacterGridType_backing_Changed"></a> backing\_Changed

```csharp
private CharacterGridType.ChangedEventHandler backing_Changed
```

#### Field Value

 [CharacterGridType](DiceRoll.Models.CharacterGrid.CharacterGridType.md).[ChangedEventHandler](DiceRoll.Models.CharacterGrid.CharacterGridType.ChangedEventHandler.md)

## Properties

### <a id="DiceRoll_Models_CharacterGrid_CharacterGridType_CharacterStore"></a> CharacterStore

```csharp
[Export(PropertyHint.None, "")]
public CharacterStore? CharacterStore { get; set; }
```

#### Property Value

 [CharacterStore](DiceRoll.Stores.CharacterStore.md)?

### <a id="DiceRoll_Models_CharacterGrid_CharacterGridType_Columns"></a> Columns

```csharp
[Export(PropertyHint.Range, "1,10,1,or_greater")]
public int Columns { get; set; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRoll_Models_CharacterGrid_CharacterGridType_Offset"></a> Offset

```csharp
[Export(PropertyHint.None, "")]
public int Offset { get; set; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRoll_Models_CharacterGrid_CharacterGridType_Prefix"></a> Prefix

```csharp
[Export(PropertyHint.None, "")]
public string Prefix { get; set; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)

### <a id="DiceRoll_Models_CharacterGrid_CharacterGridType_Rows"></a> Rows

```csharp
[Export(PropertyHint.Range, "1,10,1,or_greater")]
public int Rows { get; set; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

## Methods

### <a id="DiceRoll_Models_CharacterGrid_CharacterGridType_EmitSignalChanged"></a> EmitSignalChanged\(\)

```csharp
protected void EmitSignalChanged()
```

### <a id="DiceRoll_Models_CharacterGrid_CharacterGridType_GetGodotClassPropertyValue_Godot_NativeInterop_godot_string_name__Godot_NativeInterop_godot_variant__"></a> GetGodotClassPropertyValue\(in godot\_string\_name, out godot\_variant\)

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

### <a id="DiceRoll_Models_CharacterGrid_CharacterGridType_GetGodotPropertyList"></a> GetGodotPropertyList\(\)

Get the property information for all the properties declared in this class.
This method is used by Godot to register the available properties in the editor.
Do not call this method.

```csharp
[EditorBrowsable(EditorBrowsableState.Never)]
internal static List<PropertyInfo> GetGodotPropertyList()
```

#### Returns

 [List](https://learn.microsoft.com/dotnet/api/system.collections.generic.list\-1)<PropertyInfo\>

### <a id="DiceRoll_Models_CharacterGrid_CharacterGridType_GetGodotSignalList"></a> GetGodotSignalList\(\)

Get the signal information for all the signals declared in this class.
This method is used by Godot to register the available signals in the editor.
Do not call this method.

```csharp
[EditorBrowsable(EditorBrowsableState.Never)]
internal static List<MethodInfo> GetGodotSignalList()
```

#### Returns

 [List](https://learn.microsoft.com/dotnet/api/system.collections.generic.list\-1)<MethodInfo\>

### <a id="DiceRoll_Models_CharacterGrid_CharacterGridType_HasGodotClassSignal_Godot_NativeInterop_godot_string_name__"></a> HasGodotClassSignal\(in godot\_string\_name\)

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

### <a id="DiceRoll_Models_CharacterGrid_CharacterGridType_RaiseGodotClassSignalCallbacks_Godot_NativeInterop_godot_string_name__Godot_NativeInterop_NativeVariantPtrArgs_"></a> RaiseGodotClassSignalCallbacks\(in godot\_string\_name, NativeVariantPtrArgs\)

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

### <a id="DiceRoll_Models_CharacterGrid_CharacterGridType_RestoreGodotObjectData_Godot_Bridge_GodotSerializationInfo_"></a> RestoreGodotObjectData\(GodotSerializationInfo\)

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

### <a id="DiceRoll_Models_CharacterGrid_CharacterGridType_SaveGodotObjectData_Godot_Bridge_GodotSerializationInfo_"></a> SaveGodotObjectData\(GodotSerializationInfo\)

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

### <a id="DiceRoll_Models_CharacterGrid_CharacterGridType_SetGodotClassPropertyValue_Godot_NativeInterop_godot_string_name__Godot_NativeInterop_godot_variant__"></a> SetGodotClassPropertyValue\(in godot\_string\_name, in godot\_variant\)

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

### <a id="DiceRoll_Models_CharacterGrid_CharacterGridType_Changed"></a> Changed

```csharp
public event CharacterGridType.ChangedEventHandler Changed
```

#### Event Type

 [CharacterGridType](DiceRoll.Models.CharacterGrid.CharacterGridType.md).[ChangedEventHandler](DiceRoll.Models.CharacterGrid.CharacterGridType.ChangedEventHandler.md)

