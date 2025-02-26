# <a id="DiceRolling_Attributes_IAttribute"></a> Interface IAttribute

Namespace: [DiceRolling.Attributes](DiceRolling.Attributes.md)  
Assembly: dice\-rolling.dll  

Interface que define um atributo completo no jogo.

```csharp
public interface IAttribute : IIdentifiable, IAttributeInformation, IAttributeAssets, IAttributeValues
```

#### Implements

[IIdentifiable](DiceRolling.Common.IIdentifiable.md), 
[IAttributeInformation](DiceRolling.Attributes.IAttributeInformation.md), 
[IAttributeAssets](DiceRolling.Attributes.IAttributeAssets.md), 
[IAttributeValues](DiceRolling.Attributes.IAttributeValues.md)

## Methods

### <a id="DiceRolling_Attributes_IAttribute_ValidateConstructor"></a> ValidateConstructor\(\)

Valida os campos do resource.

```csharp
void ValidateConstructor()
```

