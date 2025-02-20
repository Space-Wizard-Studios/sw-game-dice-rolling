# Effect

**Effect** representa os efeitos que podem ser aplicados no jogo.

Para mais detalhes, veja a [Referência de API](../../api/DiceRolling.Effects.md).

## Interfaces

A interface `IEffect` define as propriedades básicas de um efeito no jogo.

```csharp
public interface IEffect {
    void Apply(IActionContext context);
}
```

### Propriedades

`IEffect` define as seguintes propriedades:

- **Apply**: Aplica o efeito no contexto da ação.
