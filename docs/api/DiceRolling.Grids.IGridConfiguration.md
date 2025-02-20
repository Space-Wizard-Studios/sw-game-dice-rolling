# <a id="DiceRolling_Grids_IGridConfiguration"></a> Interface IGridConfiguration

Namespace: [DiceRolling.Grids](DiceRolling.Grids.md)  
Assembly: dice\-rolling.dll  

Interface que define a configuração de uma grid.

```csharp
public interface IGridConfiguration
```

## Properties

### <a id="DiceRolling_Grids_IGridConfiguration_Columns"></a> Columns

Número de colunas da grid.

```csharp
int Columns { get; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Grids_IGridConfiguration_Direction"></a> Direction

Direção da grid.

```csharp
GridDirection Direction { get; }
```

#### Property Value

 [GridDirection](DiceRolling.Grids.GridDirection.md)

### <a id="DiceRolling_Grids_IGridConfiguration_Offset"></a> Offset

Offset da grid.

```csharp
int Offset { get; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Grids_IGridConfiguration_Prefix"></a> Prefix

Prefixo da grid.

```csharp
string Prefix { get; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)

### <a id="DiceRolling_Grids_IGridConfiguration_Rows"></a> Rows

Número de linhas da grid.

```csharp
int Rows { get; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

