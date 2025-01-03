using Godot;
using DiceRoll.Models.Actions.Effects;

namespace DiceRoll.Models.Actions;

[Tool]
[GlobalClass]
public partial class ActionType : Resource {
    [Export] public string? Name { get; set; }
    [Export(PropertyHint.MultilineText)] public string? Description { get; set; }
    private Texture2D? _icon;
    [Export]
    public Texture2D? Icon {
        get => _icon;
        set {
            _icon = value;
            if (_icon is not null) {
                IconPath = _icon.ResourcePath;
            }
        }
    }
    public string? IconPath { get; private set; }
    [Export] public Godot.Collections.Array<DiceMana> DefaultRequiredMana { get; set; } = [];
    [Export] public Godot.Collections.Array<EffectType> DefaultEffects { get; set; } = [];

    public ActionType() { }

    public ActionType(string name, string description, Texture2D icon) {
        Name = name;
        Description = description;
        Icon = icon;
    }
}