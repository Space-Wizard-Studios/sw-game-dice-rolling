# <a id="DiceRolling_Grids_IGridCells"></a> Interface IGridCells

Namespace: [DiceRolling.Grids](DiceRolling.Grids.md)  
Assembly: dice\-rolling.dll  

Interface que define as células de uma grid.

```csharp
public interface IGridCells
```

## Properties

### <a id="DiceRolling_Grids_IGridCells_Cells"></a> Cells

Células da grid.

```csharp
Array<int> Cells { get; }
```

#### Property Value

 Array<[int](https://learn.microsoft.com/dotnet/api/system.int32)\>

## Methods

### <a id="DiceRolling_Grids_IGridCells_GetCell_System_Int32_System_Int32_"></a> GetCell\(int, int\)

Obtém o valor de uma célula.

```csharp
int GetCell(int row, int column)
```

#### Parameters

`row` [int](https://learn.microsoft.com/dotnet/api/system.int32)

Linha da célula.

`column` [int](https://learn.microsoft.com/dotnet/api/system.int32)

Coluna da célula.

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

Valor da célula.

### <a id="DiceRolling_Grids_IGridCells_GetCellIndex_System_Int32_System_Int32_"></a> GetCellIndex\(int, int\)

Obtém o índice de uma célula.

```csharp
int GetCellIndex(int row, int column)
```

#### Parameters

`row` [int](https://learn.microsoft.com/dotnet/api/system.int32)

Linha da célula.

`column` [int](https://learn.microsoft.com/dotnet/api/system.int32)

Coluna da célula.

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

Índice da célula.

### <a id="DiceRolling_Grids_IGridCells_SetCell_System_Int32_System_Int32_System_Int32_"></a> SetCell\(int, int, int\)

Define o valor de uma célula.

```csharp
void SetCell(int row, int column, int value)
```

#### Parameters

`row` [int](https://learn.microsoft.com/dotnet/api/system.int32)

Linha da célula.

`column` [int](https://learn.microsoft.com/dotnet/api/system.int32)

Coluna da célula.

`value` [int](https://learn.microsoft.com/dotnet/api/system.int32)

Valor da célula.

