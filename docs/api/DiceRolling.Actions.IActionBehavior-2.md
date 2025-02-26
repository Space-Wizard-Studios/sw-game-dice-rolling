# <a id="DiceRolling_Actions_IActionBehavior_2"></a> Interface IActionBehavior<TContext, TResult\>

Namespace: [DiceRolling.Actions](DiceRolling.Actions.md)  
Assembly: dice\-rolling.dll  

Interface que define o comportamento de uma ação no jogo.

```csharp
public interface IActionBehavior<TContext, TResult>
```

#### Type Parameters

`TContext` 

`TResult` 

## Properties

### <a id="DiceRolling_Actions_IActionBehavior_2_Effects"></a> Effects

Efeitos da ação.

```csharp
Array<EffectType> Effects { get; set; }
```

#### Property Value

 Array<[EffectType](DiceRolling.Effects.EffectType.md)\>

### <a id="DiceRolling_Actions_IActionBehavior_2_RequiredEnergy"></a> RequiredEnergy

Energia necessária para executar a ação.

```csharp
Array<DiceEnergy> RequiredEnergy { get; set; }
```

#### Property Value

 Array<[DiceEnergy](DiceRolling.Dice.DiceEnergy.md)\>

### <a id="DiceRolling_Actions_IActionBehavior_2_TargetBoard"></a> TargetBoard

Configuração de alvo da ação.

```csharp
TargetBoardType? TargetBoard { get; set; }
```

#### Property Value

 [TargetBoardType](DiceRolling.Targets.TargetBoardType.md)?

## Methods

### <a id="DiceRolling_Actions_IActionBehavior_2_Do__0_"></a> Do\(TContext\)

Executa a ação com o contexto fornecido.

```csharp
TResult Do(TContext context)
```

#### Parameters

`context` TContext

O contexto da ação.

#### Returns

 TResult

O resultado da ação.

