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
    [ExportGroup("📝 Information")]
    [Export] public ActionCategory? Category { get; set; }
    [Export] public string? Name { get; set; }
    [Export(PropertyHint.MultilineText)] public string? Description { get; set; }

    [ExportGroup("🪵 Assets")]
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

    [ExportGroup("🎭 Behavior")]
    [Export] public Godot.Collections.Array<DiceMana> RequiredMana { get; set; } = new Godot.Collections.Array<DiceMana>();
    [Export] public Godot.Collections.Array<EffectType> Effects { get; set; } = new Godot.Collections.Array<EffectType>();
    [Export] public TargetConfiguration? TargetConfiguration { get; set; }

    public ActionType() {
        EnsureValidId();
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
        Category = category;
        RequiredMana = requiredMana;
        Effects = effects;
        Name = name;
        Description = description;
        Icon = icon;
        TargetConfiguration = targetConfiguration;
        EnsureValidId();
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
}