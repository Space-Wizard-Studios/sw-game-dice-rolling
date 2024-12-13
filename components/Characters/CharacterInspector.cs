using Godot;
using DiceRoll.Models;

[Tool]
public partial class CharacterInspector : HBoxContainer {
    [Export] private TextureRect? Portrait;
    [Export] private Label? CharacterName;
    [Export] private Label? CharacterRole;
    [Export] private VBoxContainer? AttributesList;
    [Export] private VBoxContainer? AttributeTemplate;

    private Character? _character;

    [Export]
    public Character? Character {
        get => _character;
        set {
            _character = value;
            UpdateCharacterDetails();
        }
    }

    public override void _Ready() {

    }

    private void UpdateCharacterDetails() {
        if (_character == null) {
            GD.PrintErr("Character is null");
            return;
        }

        if (Portrait != null && _character != null) {
            Portrait.Texture = _character.Portrait;
        }

        if (CharacterName != null) {
            CharacterName.Text = _character.Name ?? "Unknown";
        }

        if (CharacterRole != null && _character.Role != null) {
            CharacterRole.Text = _character.Role.Name ?? "Unknown Role";
        }
    }
}