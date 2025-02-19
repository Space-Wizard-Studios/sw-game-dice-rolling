# Target

**Target** representa a configuração de alvos no jogo.

## Interfaces

A interface `ITarget` define as propriedades básicas de uma configuração de alvo no jogo.

```csharp
public interface ITarget {
    [Signal] delegate void ConfigurationChangedEventHandler();
    bool IsSingleTarget { get; set; }
    Godot.Collections.Array<GridType> Grids { get; set; }
    void AddGrid(int rows, int columns);
    void UpdateGrid(int index);
}
```

Para mais detalhes, veja a [Referência da API](../../api/DiceRolling.Interfaces.Target.md).

### Propriedades

`ITarget` define as seguintes propriedades:

- **IsSingleTarget**: Indica se é um alvo único.
- **Grids**: Coleção de grids associadas ao alvo.

### Métodos

`ITarget` define os seguintes métodos:

- **AddGrid**: Adiciona uma nova grid.
- **UpdateGrid**: Atualiza uma grid existente.
