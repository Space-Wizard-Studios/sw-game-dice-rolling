# Grids

**Grids** são as estruturas que definem a disposição das células no jogo.

## Interfaces

A interface `IGrid` agrega várias interfaces menores para definir uma _Grid_ completa no jogo.

```csharp
public interface IGrid :
    IGridConfiguration,
    IGridCells { }
```

Para mais detalhes, veja a [Referência de API](../../api/DiceRolling.Interfaces.Grids.IGrid.md).

### Configuração

`IGridConfiguration` define a configuração de uma grid.

- **Rows**: Número de linhas da grid.
- **Columns**: Número de colunas da grid.
- **Prefix**: Prefixo da grid.
- **Offset**: Offset da grid.
- **Direction**: Direção da grid.

### Células

`IGridCells` define as células de uma grid.

- **Cells**: Células da grid.
- **GetCellIndex**: Obtém o índice de uma célula.
- **GetCellPosition**: Obtém a posição de uma célula.
- **GetCell**: Obtém o valor de uma célula.
- **SetCell**: Define o valor de uma célula.
