# <a id="DiceRolling_Actions_IAction_2"></a> Interface IAction<TContext, TResult\>

Namespace: [DiceRolling.Actions](DiceRolling.Actions.md)  
Assembly: dice\-rolling.dll  

Interface que define uma ação completa no jogo.

```csharp
public interface IAction<TContext, TResult> : IActionInformation, IActionAssets, IActionBehavior<TContext, TResult>
```

#### Type Parameters

`TContext` 

`TResult` 

#### Implements

[IActionInformation](DiceRolling.Actions.IActionInformation.md), 
[IActionAssets](DiceRolling.Actions.IActionAssets.md), 
[IActionBehavior<TContext, TResult\>](DiceRolling.Actions.IActionBehavior\-2.md)

