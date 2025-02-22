using Godot;
using DiceRolling.Services;

namespace DiceRolling.Common;

[Tool]
public abstract partial class IdentifiableResource : Resource, IIdentifiable {
    [ExportGroup("🆔 Identification")]
    [Export] public string Id { get; private set; }
    [ExportToolButton("Generate Id")] public Callable GenerateNewIdButton => Callable.From(GenerateNewId);

    public IdentifiableResource(string? id = null) {
        Id = id ?? IdService.GenerateNewId();
        if (!ValidationService.ValidateId(Id)) {
            GD.PrintErr("Id inválido. Gerando novo Id.");
            Id = IdService.GenerateNewId();
        }
    }

    public void GenerateNewId() {
        Id = IdService.GenerateNewId();
    }

    public override void _ValidateProperty(Godot.Collections.Dictionary property) {
        if (property["name"].AsStringName() == "Id") {
            var usage = property["usage"].As<PropertyUsageFlags>() | PropertyUsageFlags.ReadOnly;
            property["usage"] = (int)usage;
        }
        base._ValidateProperty(property);
    }
}