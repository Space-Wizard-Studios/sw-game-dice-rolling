# Characters

**Characters** são entidades que representam os personagens do jogo.

Para mais detalhes, veja a [Referência de API](../../api/DiceRolling.Characters.md).

## Interfaces

A interface `ICharacter` agrega várias interfaces menores para definir um _Character_ completo no jogo.

```csharp
public interface ICharacter :
    ICharacterInformation,
    ICharacterPlacement,
    ICharacterAssets,
    ICharacterAttributes,
    ICharacterActions { }
```

### Informações

`ICharacterInformation` define as informações básicas de um personagem.

- **Id**: Identificador único do personagem.
- **Name**: Nome do personagem.
- **Category**: Categoria do personagem.
- **Role**: Papel do personagem no jogo.
- **DiceCapacity**: Capacidade de dados do personagem.

### Posicionamento

`ICharacterPlacement` define o posicionamento (local) de um personagem no jogo.

- **Location**: Localização do personagem no jogo.
- **SlotIndex**: Índice do slot onde o personagem está localizado.

### Recursos Visuais

`ICharacterAssets` define os recursos visuais de um personagem.

- **Portrait**: Retrato do personagem.
- **CharacterSprite**: Sprite do personagem.
- **ShadowSprite**: Sprite da sombra do personagem.
- **ShowShadow**: Indica se a sombra do personagem deve ser exibida.
- **SpritePositionX**: Posição X do sprite do personagem.
- **SpritePositionY**: Posição Y do sprite do personagem.

### Atributos

`ICharacterAttributes` define os atributos de um personagem.

- **Attributes**: Coleção de `CharacterAttribute`.
- Métodos para inicializar e gerenciar atributos:
  - `InitializeAttributes`
  - `GetAttributeCurrentValue`
  - `GetAttributeMaxValue`
  - `GetAttributeBaseValue`
  - `UpdateAttributeCurrentValue`

### Ações

`ICharacterActions` define as ações de um personagem.

- **Actions**: Coleção de `CharacterAction`.
- Métodos para inicializar e gerenciar ações:
  - `InitializeActions`
  - `AddAction`
  - `RemoveAction`
