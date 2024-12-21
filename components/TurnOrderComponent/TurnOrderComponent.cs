using Godot;
using System;
using System.Linq;
using System.Collections.Generic;
using DiceRoll.Models;

namespace DiceRoll.Components;

[Tool]
public partial class TurnOrderComponent : Control {
    private AttributeType? SpeedAttributeType;
    private AttributeType? HealthAttributeType;

    [ExportGroup("🪵 Resources")]
    private Character[] _characters = Array.Empty<Character>();
    [Export]
    public Character[] Characters {
        get => _characters;
        set {
            _characters = value;
            GD.Print("Characters set. Length: ", _characters.Length);
            if (SpeedAttributeType == null || HealthAttributeType == null) {
                GD.PrintErr("AttributeType resources not loaded.");
                return;
            }
            if (_characters.Length > 0) {
                // Filter out null or uninitialized characters
                var validCharacters = _characters.Where(c => c != null).ToList();
                GD.Print("Valid characters count: ", validCharacters.Count);
                if (validCharacters.Count > 0) {
                    UpdateTurnOrder(validCharacters);
                }
                else {
                    GD.PrintErr("No valid characters found.");
                }
            }
            else {
                GD.PrintErr("Characters array is empty.");
            }
        }
    }

    [ExportGroup("🔘 Nodes")]
    [Export] public HBoxContainer? PortraitsContainerNode { get; set; }

    private PanelContainer? _portraitTemplate;

    [ExportSubgroup("🖼️ Portrait Template")]
    [Export]
    PanelContainer? PortraitTemplateNode {
        get => _portraitTemplate;
        set {
            GD.Print("Setting PortraitTemplate");
            if (value != null) {
                _portraitTemplate = value;
            }
            OnPortraitTemplateChanged();
        }
    }

    [Export] public Panel? PortraitPanelNode;
    public string PortraitPanelName => PortraitPanelNode?.Name ?? "PortraitPanel";

    [Export] public TextureRect? PortraitTextureNode;
    public string PortraitTextureName => PortraitTextureNode?.Name ?? "PortraitTexture";

    [Export] public ColorRect? PortraitDamageColorNode;
    public string PortraitDamageColorName => PortraitDamageColorNode?.Name ?? "PortraitDamageColor";

    public override void _Ready() {
        // Load the Speed attribute type resource
        SpeedAttributeType = GD.Load<AttributeType>("res://models/Attributes/Resources/Speed.tres");
        GD.Print("SpeedAttributeType loaded: ", SpeedAttributeType != null);
        // Load the Health attribute type resource
        HealthAttributeType = GD.Load<AttributeType>("res://models/Attributes/Resources/Health.tres");
        GD.Print("HealthAttributeType loaded: ", HealthAttributeType != null);

        // Update turn order if characters are already set
        if (_characters.Length > 0) {
            var validCharacters = _characters.Where(c => c != null).ToList();
            GD.Print("Initial valid characters count: ", validCharacters.Count);
            if (validCharacters.Count > 0) {
                UpdateTurnOrder(validCharacters);
            }
            else {
                GD.PrintErr("No valid characters found on _Ready.");
            }
        }
        else {
            GD.PrintErr("Characters array is empty on _Ready.");
        }
    }

    private void OnPortraitTemplateChanged() {
        if (_portraitTemplate != null) {
            GD.Print("Theme: ", _portraitTemplate.Theme);
            GD.Print("Theme Type Variation:", _portraitTemplate.ThemeTypeVariation);
        }
    }

    private void SetupPortraitInstance(Character character, PanelContainer portraitInstance) {
        if (PortraitPanelNode == null || PortraitTextureNode == null || PortraitDamageColorNode == null) {
            GD.PrintErr("One or more portrait nodes are not set.");
            return;
        }

        if (PortraitPanelNode == null || PortraitTextureNode == null || PortraitDamageColorNode == null) {
            GD.PrintErr("One or more portrait nodes are not set.");
            return;
        }

        // Get the Panel node from the portrait instance
        var panel = portraitInstance.GetNodeOrNull<Panel>(PortraitPanelName);
        if (panel == null) {
            GD.PrintErr("Panel node not found in portrait instance.");
            return;
        }

        // Get the TextureRect and ColorRect nodes from the Panel node
        var textureRect = panel.GetNodeOrNull<TextureRect>(PortraitTextureName);
        var damageColor = panel.GetNodeOrNull<ColorRect>(PortraitDamageColorName);

        portraitInstance.Visible = true;

        if (textureRect != null && character.Portrait != null) {
            GD.Print("Setting texture for character: ", character.Name);
            textureRect.Texture = character.Portrait;
        }
        else {
            GD.PrintErr("TextureRect or character portrait is null for character: ", character.Name);
        }

        int currentHealth = HealthAttributeType != null ? character.GetAttributeCurrentValue(HealthAttributeType) : 0;
        int maxHealth = HealthAttributeType != null ? character.GetAttributeMaxValue(HealthAttributeType) : 0;

        if (damageColor != null && maxHealth > 0) {
            float healthRatio = (float)currentHealth / maxHealth;
            damageColor.Scale = new Vector2(1, healthRatio);
            GD.Print("Setting damage color scale for character: ", character.Name, " Health ratio: ", healthRatio);
        }
        else {
            GD.PrintErr("DamageColor is null or maxHealth is zero for character: ", character.Name);
        }
    }
    public void UpdateTurnOrder(List<Character> characters) {
        if (PortraitsContainerNode == null || PortraitTemplateNode == null) {
            GD.PrintErr("PortraitsContainerNode or PortraitTemplateNode is null");
            return;
        }
        if (SpeedAttributeType == null || HealthAttributeType == null) {
            GD.PrintErr("AttributeType resources not loaded.");
            return;
        }

        GD.Print("Updating turn order. Characters count: ", characters.Count);

        foreach (Node child in PortraitsContainerNode.GetChildren()) {
            if (child != PortraitTemplateNode) {
                PortraitsContainerNode.RemoveChild(child);
                child.QueueFree();
            }
        }

        var sortedCharacters = characters;
        //     .Where(c => c != null && c.GetAttributeCurrentValue(SpeedAttributeType) != 0)
        //     .OrderByDescending(c => c.GetAttributeCurrentValue(SpeedAttributeType))
        //     .ToList();


        foreach (var character in sortedCharacters) {
            if (character == null) {
                GD.PrintErr("Character is null, skipping...");
                continue;
            }

            GD.Print("Processing character: ", character.Name);

            if (PortraitTemplateNode.Duplicate() is not PanelContainer portraitInstance) {
                GD.PrintErr("Failed to duplicate PortraitTemplateNode for character: ", character.Name);
                continue;
            }

            SetupPortraitInstance(character, portraitInstance);
            PortraitsContainerNode.AddChild(portraitInstance);
            GD.Print("Added portrait for character: ", character.Name);
        }
    }
}