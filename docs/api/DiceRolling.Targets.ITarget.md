# <a id="DiceRolling_Targets_ITarget"></a> Interface ITarget

Namespace: [DiceRolling.Targets](DiceRolling.Targets.md)  
Assembly: dice\-rolling.dll  

Interface que define a configuração de alvo no jogo.

```csharp
public interface ITarget
```

## Properties

### <a id="DiceRolling_Targets_ITarget_Grids"></a> Grids

Coleção de grids associadas ao alvo.

```csharp
Array<GridType> Grids { get; set; }
```

#### Property Value

 Array<[GridType](DiceRolling.Grids.GridType.md)\>

### <a id="DiceRolling_Targets_ITarget_IsSingleTarget"></a> IsSingleTarget

Indica se é um alvo único.

```csharp
bool IsSingleTarget { get; set; }
```

#### Property Value

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

## Methods

### <a id="DiceRolling_Targets_ITarget_AddGrid_System_Int32_System_Int32_"></a> AddGrid\(int, int\)

Adiciona uma nova grid.

```csharp
void AddGrid(int rows, int columns)
```

#### Parameters

`rows` [int](https://learn.microsoft.com/dotnet/api/system.int32)

Número de linhas da grid.

`columns` [int](https://learn.microsoft.com/dotnet/api/system.int32)

Número de colunas da grid.

### <a id="DiceRolling_Targets_ITarget_UpdateGrid_System_Int32_"></a> UpdateGrid\(int\)

Atualiza uma grid existente.

```csharp
void UpdateGrid(int index)
```

#### Parameters

`index` [int](https://learn.microsoft.com/dotnet/api/system.int32)

Índice da grid a ser atualizada.

