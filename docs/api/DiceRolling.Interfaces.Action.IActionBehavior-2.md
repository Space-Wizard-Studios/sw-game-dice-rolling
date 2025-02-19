# <a id="DiceRolling_Interfaces_Action_IActionBehavior_2"></a> Interface IActionBehavior<TContext, TResult\>

Namespace: [DiceRolling.Interfaces.Action](DiceRolling.Interfaces.Action.md)  
Assembly: dice\-rolling.dll  

Interface que define o comportamento de uma ação no jogo.

```csharp
public interface IActionBehavior<TContext, TResult>
```

#### Type Parameters

`TContext` 

`TResult` 

## Properties

### <a id="DiceRolling_Interfaces_Action_IActionBehavior_2_Effects"></a> Effects

Efeitos da ação.

```csharp
Array<EffectType> Effects { get; set; }
```

#### Property Value

 Array<[EffectType](DiceRolling.Models.Actions.Effects.EffectType.md)\>

### <a id="DiceRolling_Interfaces_Action_IActionBehavior_2_RequiredMana"></a> RequiredMana

Mana necessária para executar a ação.

```csharp
Array<DiceMana> RequiredMana { get; set; }
```

#### Property Value

 Array<[DiceMana](DiceRolling.Models.DiceMana.md)\>

### <a id="DiceRolling_Interfaces_Action_IActionBehavior_2_TargetConfiguration"></a> TargetConfiguration

Configuração de alvo da ação.

```csharp
TargetConfiguration? TargetConfiguration { get; set; }
```

#### Property Value

 [TargetConfiguration](DiceRolling.Models.Actions.Targets.TargetConfiguration.md)?

## Methods

### <a id="DiceRolling_Interfaces_Action_IActionBehavior_2_Do__0_"></a> Do\(TContext\)

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

