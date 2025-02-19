# <a id="DiceRolling_Interfaces_Grid_IGridConfiguration"></a> Interface IGridConfiguration

Namespace: [DiceRolling.Interfaces.Grid](DiceRolling.Interfaces.Grid.md)  
Assembly: dice\-rolling.dll  

Interface que define a configuração de uma grid.

```csharp
public interface IGridConfiguration
```

## Properties

### <a id="DiceRolling_Interfaces_Grid_IGridConfiguration_Columns"></a> Columns

Número de colunas da grid.

```csharp
int Columns { get; set; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Interfaces_Grid_IGridConfiguration_Direction"></a> Direction

Direção da grid.

```csharp
GridDirection Direction { get; set; }
```

#### Property Value

 [GridDirection](DiceRolling.Interfaces.Grid.GridDirection.md)

### <a id="DiceRolling_Interfaces_Grid_IGridConfiguration_Offset"></a> Offset

Offset da grid.

```csharp
int Offset { get; set; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Interfaces_Grid_IGridConfiguration_Prefix"></a> Prefix

Prefixo da grid.

```csharp
string Prefix { get; set; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)

### <a id="DiceRolling_Interfaces_Grid_IGridConfiguration_Rows"></a> Rows

Número de linhas da grid.

```csharp
int Rows { get; set; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

