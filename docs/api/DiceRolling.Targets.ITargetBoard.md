# <a id="DiceRolling_Targets_ITargetBoard"></a> Interface ITargetBoard

Namespace: [DiceRolling.Targets](DiceRolling.Targets.md)  
Assembly: dice\-rolling.dll  

Interface que define a configuração de um tabuleiro de alvos no jogo.

```csharp
public interface ITargetBoard
```

## Properties

### <a id="DiceRolling_Targets_ITargetBoard_Grids"></a> Grids

Coleção de grids associadas ao tabuleiro.

```csharp
Array<GridType> Grids { get; set; }
```

#### Property Value

 Array<[GridType](DiceRolling.Grids.GridType.md)\>

### <a id="DiceRolling_Targets_ITargetBoard_IsSingleTarget"></a> IsSingleTarget

Indica se o tabuleiro é para um único alvo.

```csharp
bool IsSingleTarget { get; set; }
```

#### Property Value

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

## Methods

### <a id="DiceRolling_Targets_ITargetBoard_AddGrid_System_Int32_System_Int32_"></a> AddGrid\(int, int\)

Adiciona uma nova grid ao tabuleiro.

```csharp
void AddGrid(int rows, int columns)
```

#### Parameters

`rows` [int](https://learn.microsoft.com/dotnet/api/system.int32)

Número de linhas da grid.

`columns` [int](https://learn.microsoft.com/dotnet/api/system.int32)

Número de colunas da grid.

### <a id="DiceRolling_Targets_ITargetBoard_UpdateGrid_System_Int32_"></a> UpdateGrid\(int\)

Atualiza uma grid existente no tabuleiro.

```csharp
void UpdateGrid(int index)
```

#### Parameters

`index` [int](https://learn.microsoft.com/dotnet/api/system.int32)

Índice da grid a ser atualizada.

