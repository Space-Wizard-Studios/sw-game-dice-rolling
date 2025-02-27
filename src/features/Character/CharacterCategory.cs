using Godot;
using System;

using DiceRolling.Id;
using DiceRolling.Services;

namespace DiceRolling.Characters;

/// <summary>
/// Representa uma categoria de um personagem.
/// </summary>
[Tool]
[GlobalClass]
public partial class CharacterCategory : IdentifiableResource {
    private string _name = "CharacterCategory_" + Guid.NewGuid().ToString("N");

    private Texture2D? _icon;

    [ExportGroup("📝 Information")]

    [Export]
    public string Name {
        get => _name;
        set {
            if (ValidationService.ValidateName(value)) {
                _name = value;
                EmitChanged();
            }
        }
    }

    [Export(PropertyHint.MultilineText)]
    public string? Description { get; set; }

    [ExportGroup("🪵 Assets")]

    [Export]
    public Texture2D? Icon {
        get => _icon;
        set {
            _icon = value;
            if (_icon is not null) {
                IconPath = _icon.ResourcePath;
                EmitChanged();
            }
        }
    }
    public string? IconPath { get; private set; }

    public CharacterCategory() {
    }

    public CharacterCategory(string name, string description, Texture2D icon) {
        Name = name;
        Description = description;
        Icon = icon;
        ValidateConstructor();
    }

    public void ValidateConstructor() {
        if (!ValidationService.ValidateName(Name)) {
            throw new ArgumentException("Name não pode ser null ou vazio.");
        }
    }

}
