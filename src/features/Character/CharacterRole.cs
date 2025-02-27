using DiceRolling.Actions;
using DiceRolling.Roles;
using Godot;

namespace DiceRolling.Characters;

/// <summary>
/// Representa uma ação de um personagem.
/// </summary>
[Tool]
[GlobalClass]
public partial class CharacterRole : Resource {
    private RoleType? _role;

    [Export]
    public RoleType? Type {
        get => _role;
        set {
            _role = value;
            EmitChanged();
        }
    }

    public CharacterRole() { }

    public CharacterRole(RoleType roleType) {
        Type = roleType;
    }
}