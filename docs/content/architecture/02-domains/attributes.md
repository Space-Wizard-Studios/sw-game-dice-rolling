# Attributes

**Attributes** são as características que definem os atributos dos personagens no jogo.

## Interfaces

A interface `IAttribute` agrega várias interfaces menores para definir um _Attribute_ completo no jogo.

```csharp
public interface IAttribute :
    IAttributeInformation,
    IAttributeAssets,
    IAttributeValues { }
```

Para mais detalhes, veja a [Referência de API](../../api/DiceRolling.Interfaces.Attribute.md).

### Informações

`IAttributeInformation` define as informações básicas de um atributo.

- **Id**: Identificador único do atributo.
- **Name**: Nome do atributo.
- **Description**: Descrição do atributo.

### Recursos Visuais

`IAttributeAssets` define os recursos visuais de um atributo.

- **Color**: Cor do atributo.
- **Icon**: Ícone do atributo.
- **IconPath**: Caminho do ícone do atributo.

### Valores

`IAttributeValues` define os valores de um atributo.

- **MinValue**: Valor mínimo do atributo.
- **MaxValue**: Valor máximo do atributo.
