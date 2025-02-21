using Godot;
using System;

using DiceRolling.Dice;
using DiceRolling.Targets;
using DiceRolling.Effects;
using DiceRolling.Services;
using DiceRolling.Common;

namespace DiceRolling.Actions;

[Tool]
[GlobalClass]
public partial class ActionType : IdentifiableResource, IAction<IActionContext, bool> {
    private string? _name = "Action";
    private Texture2D? _icon;

    [ExportGroup("📝 Information")]

    [Export]
    public ActionCategory? Category { get; set; }

    [Export]
    public string? Name {
        get => _name;
        set {
            if (ValidationService.ValidateName(value)) {
                _name = value;
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
            }
        }
    }
    public string? IconPath { get; private set; }

    [ExportGroup("🎭 Behavior")]

    [Export]
    public Godot.Collections.Array<DiceMana> RequiredMana { get; set; } = new Godot.Collections.Array<DiceMana>();

    [Export]
    public Godot.Collections.Array<EffectType> Effects { get; set; } = new Godot.Collections.Array<EffectType>();

    [Export]
    public TargetConfiguration? TargetConfiguration { get; set; }

    public ActionType() {
    }

    public ActionType(
        ActionCategory category,
        Godot.Collections.Array<DiceMana> requiredMana,
        Godot.Collections.Array<EffectType> effects,
        string? name = null,
        string? description = null,
        Texture2D? icon = null,
        TargetConfiguration? targetConfiguration = null
    ) {
        ValidateConstructor();

        Category = category;
        RequiredMana = requiredMana;
        Effects = effects;
        Name = name;
        Description = description;
        Icon = icon;
        TargetConfiguration = targetConfiguration;
    }

    public bool Do(IActionContext context) {
        EffectService.ApplyEffects(Effects, context);
        return true;
    }

    // Métodos de utilidade
    public bool IsValid() {
        return !string.IsNullOrEmpty(Id) &&
               Category != null &&
               RequiredMana.Count > 0 &&
               Effects.Count > 0 &&
               TargetConfiguration != null;
    }

    public void AddEffect(EffectType effect) {
        if (!Effects.Contains(effect)) {
            Effects.Add(effect);
        }
    }

    public void RemoveEffect(EffectType effect) {
        Effects.Remove(effect);
    }

    public void ValidateConstructor() {
        if (!ValidationService.ValidateName(Name)) {
            throw new ArgumentException("Name cannot be null or whitespace");
        }
    }
}