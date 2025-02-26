# <a id="DiceRolling_Actions_IAction_2"></a> Interface IAction<TContext, TResult\>

Namespace: [DiceRolling.Actions](DiceRolling.Actions.md)  
Assembly: dice\-rolling.dll  

Interface que define uma ação que é realizada por personagens do jogo.

```csharp
public interface IAction<TContext, TResult> : IIdentifiable, IActionInformation, IActionAssets, IActionBehavior<TContext, TResult>
```

#### Type Parameters

`TContext` 

`TResult` 

#### Implements

[IIdentifiable](DiceRolling.Common.IIdentifiable.md), 
[IActionInformation](DiceRolling.Actions.IActionInformation.md), 
[IActionAssets](DiceRolling.Actions.IActionAssets.md), 
[IActionBehavior<TContext, TResult\>](DiceRolling.Actions.IActionBehavior\-2.md)

## Methods

### <a id="DiceRolling_Actions_IAction_2_AddEffect_DiceRolling_Effects_EffectType_"></a> AddEffect\(EffectType\)

```csharp
void AddEffect(EffectType effect)
```

#### Parameters

`effect` [EffectType](DiceRolling.Effects.EffectType.md)

### <a id="DiceRolling_Actions_IAction_2_IsValid"></a> IsValid\(\)

```csharp
bool IsValid()
```

#### Returns

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="DiceRolling_Actions_IAction_2_RemoveEffect_DiceRolling_Effects_EffectType_"></a> RemoveEffect\(EffectType\)

```csharp
void RemoveEffect(EffectType effect)
```

#### Parameters

`effect` [EffectType](DiceRolling.Effects.EffectType.md)

### <a id="DiceRolling_Actions_IAction_2_ValidateConstructor"></a> ValidateConstructor\(\)

```csharp
void ValidateConstructor()
```

