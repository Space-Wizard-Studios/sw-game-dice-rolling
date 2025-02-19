# <a id="DiceRolling_Interfaces_Action_IAction_2"></a> Interface IAction<TContext, TResult\>

Namespace: [DiceRolling.Interfaces.Action](DiceRolling.Interfaces.Action.md)  
Assembly: dice\-rolling.dll  

Interface que define uma ação completa no jogo.

```csharp
public interface IAction<TContext, TResult> : IActionInformation, IActionAssets, IActionBehavior<TContext, TResult>
```

#### Type Parameters

`TContext` 

`TResult` 

#### Implements

[IActionInformation](DiceRolling.Interfaces.Action.IActionInformation.md), 
[IActionAssets](DiceRolling.Interfaces.Action.IActionAssets.md), 
[IActionBehavior<TContext, TResult\>](DiceRolling.Interfaces.Action.IActionBehavior\-2.md)

