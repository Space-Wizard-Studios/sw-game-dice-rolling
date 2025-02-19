# Actions

**Actions** são as ações que os personagens podem executar no jogo.

## Interfaces

A interface `IAction` agrega várias interfaces menores para definir uma _Action_ completa no jogo.

```csharp
public interface IAction<TContext, TResult> :
    IActionInformation,
    IActionAssets,
    IActionBehavior<TContext, TResult> { }
```

Para mais detalhes, veja a [Referência de API](../../api/DiceRolling.Interfaces.Action.IAction-2.md).

### Informações

`IActionInformation` define as informações básicas de uma ação.

- **Id**: Identificador único da ação.
- **Name**: Nome da ação.
- **Description**: Descrição da ação.

### Recursos Visuais

`IActionAssets` define os recursos visuais de uma ação.

- **Icon**: Ícone da ação.
- **IconPath**: Caminho do ícone da ação.

### Comportamento

`IActionBehavior` define o comportamento de uma ação.

- **RequiredMana**: Mana necessária para executar a ação.
- **Effects**: Coleção de `EffectType`.
- **TargetConfiguration**: Configuração de alvo da ação.
- **Do**: Executa a ação com o contexto fornecido.
