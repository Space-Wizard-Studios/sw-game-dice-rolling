# <a id="DiceRolling_Grids_GridType"></a> Class GridType

Namespace: [DiceRolling.Grids](DiceRolling.Grids.md)  
Assembly: dice\-rolling.dll  

```csharp
[Tool]
[GlobalClass]
[ScriptPath("res://features/Grid/GridType.cs")]
public class GridType : Resource, IDisposable, IGrid, IGridConfiguration, IGridCells
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
GodotObject ← 
RefCounted ← 
Resource ← 
[GridType](DiceRolling.Grids.GridType.md)

#### Implements

[IDisposable](https://learn.microsoft.com/dotnet/api/system.idisposable), 
[IGrid](DiceRolling.Grids.IGrid.md), 
[IGridConfiguration](DiceRolling.Grids.IGridConfiguration.md), 
[IGridCells](DiceRolling.Grids.IGridCells.md)

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

### <a id="DiceRolling_Grids_GridType__ctor"></a> GridType\(\)

```csharp
public GridType()
```

### <a id="DiceRolling_Grids_GridType__ctor_System_Int32_System_Int32_System_Int32_System_String_"></a> GridType\(int, int, int, string\)

```csharp
public GridType(int rows, int columns, int offset, string prefix)
```

#### Parameters

`rows` [int](https://learn.microsoft.com/dotnet/api/system.int32)

`columns` [int](https://learn.microsoft.com/dotnet/api/system.int32)

`offset` [int](https://learn.microsoft.com/dotnet/api/system.int32)

`prefix` [string](https://learn.microsoft.com/dotnet/api/system.string)

## Properties

### <a id="DiceRolling_Grids_GridType_Cells"></a> Cells

Células da grid.

```csharp
[Export(PropertyHint.None, "")]
public Array<int> Cells { get; set; }
```

#### Property Value

 Array<[int](https://learn.microsoft.com/dotnet/api/system.int32)\>

### <a id="DiceRolling_Grids_GridType_CharacterStore"></a> CharacterStore

```csharp
[Export(PropertyHint.None, "")]
public CharacterStore? CharacterStore { get; set; }
```

#### Property Value

 [CharacterStore](DiceRolling.Characters.CharacterStore.md)?

### <a id="DiceRolling_Grids_GridType_Columns"></a> Columns

Número de colunas da grid.

```csharp
[Export(PropertyHint.None, "")]
public int Columns { get; set; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Grids_GridType_Direction"></a> Direction

Direção da grid.

```csharp
[Export(PropertyHint.Enum, "LeftToRight,RightToLeft")]
public GridDirection Direction { get; set; }
```

#### Property Value

 [GridDirection](DiceRolling.Grids.GridDirection.md)

### <a id="DiceRolling_Grids_GridType_Offset"></a> Offset

Offset da grid.

```csharp
[Export(PropertyHint.None, "")]
public int Offset { get; set; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Grids_GridType_Prefix"></a> Prefix

Prefixo da grid.

```csharp
[Export(PropertyHint.None, "")]
public string Prefix { get; set; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)

### <a id="DiceRolling_Grids_GridType_Rows"></a> Rows

Número de linhas da grid.

```csharp
[Export(PropertyHint.None, "")]
public int Rows { get; set; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

## Methods

### <a id="DiceRolling_Grids_GridType_EmitSignalGridChanged"></a> EmitSignalGridChanged\(\)

```csharp
protected void EmitSignalGridChanged()
```

### <a id="DiceRolling_Grids_GridType_GetCell_System_Int32_System_Int32_"></a> GetCell\(int, int\)

Obtém o valor de uma célula.

```csharp
public int GetCell(int row, int column)
```

#### Parameters

`row` [int](https://learn.microsoft.com/dotnet/api/system.int32)

Linha da célula.

`column` [int](https://learn.microsoft.com/dotnet/api/system.int32)

Coluna da célula.

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

Valor da célula.

### <a id="DiceRolling_Grids_GridType_GetCellIndex_System_Int32_System_Int32_"></a> GetCellIndex\(int, int\)

Obtém o índice de uma célula.

```csharp
public int GetCellIndex(int row, int column)
```

#### Parameters

`row` [int](https://learn.microsoft.com/dotnet/api/system.int32)

Linha da célula.

`column` [int](https://learn.microsoft.com/dotnet/api/system.int32)

Coluna da célula.

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

Índice da célula.

### <a id="DiceRolling_Grids_GridType_SetCell_System_Int32_System_Int32_System_Int32_"></a> SetCell\(int, int, int\)

Define o valor de uma célula.

```csharp
public void SetCell(int row, int column, int value)
```

#### Parameters

`row` [int](https://learn.microsoft.com/dotnet/api/system.int32)

Linha da célula.

`column` [int](https://learn.microsoft.com/dotnet/api/system.int32)

Coluna da célula.

`value` [int](https://learn.microsoft.com/dotnet/api/system.int32)

Valor da célula.

### <a id="DiceRolling_Grids_GridType_ValidateConstructor"></a> ValidateConstructor\(\)

```csharp
public void ValidateConstructor()
```

### <a id="DiceRolling_Grids_GridType_GridChanged"></a> GridChanged

```csharp
public event GridType.GridChangedEventHandler GridChanged
```

#### Event Type

 [GridType](DiceRolling.Grids.GridType.md).[GridChangedEventHandler](DiceRolling.Grids.GridType.GridChangedEventHandler.md)

