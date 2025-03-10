using Godot;
using DiceRolling.Characters;

namespace DiceRolling.Entities;

[Tool]
[GlobalClass]
public partial class CharacterEntity : Entity3D {
    [Export]
    public CharacterType? CharacterData {
        get => GetData<CharacterType>();
        set => Data = value;
    }

    [ExportToolButton("Update Character")]
    public Callable UpdateCharacterData => Callable.From(() => NotifyUpdate());
}