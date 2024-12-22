using Godot;

namespace DiceRoll.Models.CharacterActions;

[Tool]
[GlobalClass]
public partial class ActionType : Resource {
    [Export] public string? Name { get; set; }
    [Export(PropertyHint.MultilineText)] public string? Description { get; set; }
    [Export] public Texture2D? Icon { get; set; }

    public ActionType() { }

    public ActionType(string name, string description, Texture2D icon) {
        Name = name;
        Description = description;
        Icon = icon;
    }
}