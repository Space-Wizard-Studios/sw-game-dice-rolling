# Effect

**Effect** representa os efeitos que podem ser aplicados no jogo.

## Interfaces

A interface `IEffect` define as propriedades básicas de um efeito no jogo.

```csharp
public interface IEffect {
    void Apply(IActionContext context);
}
```

Para mais detalhes, veja a Referência de API.

### Propriedades

`IEffect` define as seguintes propriedades:

- **Apply**: Aplica o efeito no contexto da ação.
