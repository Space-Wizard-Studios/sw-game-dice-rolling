# Location

**Location** representa as diferentes localizações no jogo, cada uma com suas próprias características e slots.

Para mais detalhes, veja a [Referência da API](../../api/DiceRolling.Locations.md).

## Interfaces

A interface `ILocation` define as propriedades básicas de uma localização no jogo.

```csharp
public interface ILocation {
    string Name { get; }
    string Description { get; }
    int TotalSlots { get; }
}
```

### Propriedades

`ILocation` define as seguintes propriedades:

- **Name**: Nome da localização.
- **Description**: Descrição da localização.
- **TotalSlots**: Número total de slots na localização.

## Modelo

O modelo `LocationType` implementa a interface `ILocation` e define uma localização específica no jogo.

### Configuração do Godot

Para configurar o recurso `LocationType` no Godot:

1. Crie um novo recurso do tipo `LocationType`.
2. Defina as propriedades `Name`, `Description` e `TotalSlots` conforme necessário.

Com essas configurações, você pode criar e gerenciar diferentes localizações no jogo de forma modular e extensível.
