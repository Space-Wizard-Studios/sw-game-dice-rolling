# <a id="DiceRolling_Characters_ICharacterAssets"></a> Interface ICharacterAssets

Namespace: [DiceRolling.Characters](DiceRolling.Characters.md)  
Assembly: dice\-rolling.dll  

Interface que define os recursos visuais de um personagem no jogo.

```csharp
public interface ICharacterAssets
```

## Properties

### <a id="DiceRolling_Characters_ICharacterAssets_CharacterSprite"></a> CharacterSprite

Sprite do personagem.

```csharp
SpriteFrames? CharacterSprite { get; set; }
```

#### Property Value

 SpriteFrames?

### <a id="DiceRolling_Characters_ICharacterAssets_Portrait"></a> Portrait

Retrato do personagem.

```csharp
Texture2D? Portrait { get; set; }
```

#### Property Value

 Texture2D?

### <a id="DiceRolling_Characters_ICharacterAssets_ShadowSprite"></a> ShadowSprite

Sprite da sombra do personagem.

```csharp
SpriteFrames? ShadowSprite { get; set; }
```

#### Property Value

 SpriteFrames?

### <a id="DiceRolling_Characters_ICharacterAssets_ShowShadow"></a> ShowShadow

Indica se a sombra do personagem deve ser exibida.

```csharp
bool ShowShadow { get; set; }
```

#### Property Value

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="DiceRolling_Characters_ICharacterAssets_SpritePositionX"></a> SpritePositionX

Posição X do sprite do personagem.

```csharp
float SpritePositionX { get; set; }
```

#### Property Value

 [float](https://learn.microsoft.com/dotnet/api/system.single)

### <a id="DiceRolling_Characters_ICharacterAssets_SpritePositionY"></a> SpritePositionY

Posição Y do sprite do personagem.

```csharp
float SpritePositionY { get; set; }
```

#### Property Value

 [float](https://learn.microsoft.com/dotnet/api/system.single)

