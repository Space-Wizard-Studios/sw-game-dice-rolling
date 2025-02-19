# Dice

**Dice** representam os dados utilizados no jogo, cada um com seus lados e manas associadas.

## Interfaces

A interface `IDice` agrega várias interfaces menores para definir um dado completo no jogo.

```csharp
public interface IDice<[MustBeVariant] T> where T : IDiceSide {
    string Id { get; }
    string Name { get; }
    Godot.Collections.Array<T> Sides { get; }
    int SideCount { get; }
    IDiceLocation Location { get; }
}
```

Para mais detalhes, veja a [Referência de API](../../api/DiceRolling.Interfaces.Dice.md).

### Manas

`IDiceMana` define as propriedades de uma mana.

- **Name**: Nome da mana.
- **Description**: Descrição da mana.
- **BackgroundColor**: Cor de fundo da mana.
- **MainColor**: Cor principal da mana.
- **Icon**: Ícone da mana.

### Lados

`IDiceSide` define as propriedades de um lado do dado.

- **Mana**: Tipo de mana associada ao lado.

### Localização

`IDiceLocation` define a localização de um dado.

- **LocationCategory**: Tipo de localização do dado.
- **PlayerId**: ID do jogador, se estiver no inventário.
- **CharacterId**: ID do personagem, se estiver com um personagem.

### Categorias de Localização

`DiceLocationCategory` define as categorias de localização de um dado.

- **Inventory**: No inventário.
- **Character**: Com um personagem.
- **None**: Sem localização específica.
