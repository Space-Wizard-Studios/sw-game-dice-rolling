using Godot;
using DiceRolling.Entities;
using DiceRolling.Events;
using DiceRolling.Helpers;

namespace DiceRolling.Components;

[Tool]
[GlobalClass]
[Icon("res://assets/editor/component-3d.svg")]
public partial class SelectableComponent : Node3D {
    private static SelectableComponent? _currentlySelectedComponent;

    public enum CollisionShapeType { Box, Capsule }

    [Export] public CollisionShapeType ShapeType { get; set; } = CollisionShapeType.Box;
    [Export] public Vector3 BoxSize { get; set; } = new Vector3(1.0f, 1.0f, 1.0f);
    [Export] public float CapsuleHeight { get; set; } = 1.0f;
    [Export] public float CapsuleRadius { get; set; } = 0.5f;

    [Export] public Sprite3D? SelectorSprite { get; set; }
    [Export] public Sprite3D? HoverSpriteNode { get; set; }

    private Area3D? _inputArea;
    private Entity3D? _parent;

    private bool _isSelected = false;
    [Export]
    public bool IsSelected {
        get => _isSelected;
        set {
            if (_isSelected != value) {
                _isSelected = value;
                OnIsSelectedSet(value);
            }
        }
    }

    private bool _isHovered = false;
    [Export]
    public bool IsHovered {
        get => _isHovered;
        set {
            if (_isHovered != value) {
                _isHovered = value;
                OnIsHoveredSet(value);
            }
        }
    }

    public override void _Ready() {
        _parent = GetParent<Entity3D>();

        // Create area and collision shape
        CreateInputArea();

        // Initialize visuals
        if (SelectorSprite is not null) {
            SelectorSprite.Visible = false;
        }
        if (HoverSpriteNode is not null) {
            HoverSpriteNode.Visible = false;
        }

        // Connect to entity if available
        if (_parent != null) {
            SignalHelper.ConnectSignal(_parent, nameof(Entity3D.EntityUpdated), this, nameof(OnEntityUpdated));
        }

        EventBus.Instance.Connect(nameof(EventBus.CharacterUnselected), new Callable(this, nameof(OnCharacterUnselected)));
    }

    private void CreateInputArea() {
        // Create area node
        _inputArea = new Area3D {
            Name = "SelectionArea"
        };
        AddChild(_inputArea);

        // Create collision shape
        var collisionShape = new CollisionShape3D {
            Name = "CollisionShape"
        };

        // Set shape based on configuration
        if (ShapeType == CollisionShapeType.Box) {
            var boxShape = new BoxShape3D {
                Size = BoxSize
            };
            collisionShape.Shape = boxShape;
        }
        else { // Capsule
            var capsuleShape = new CapsuleShape3D {
                Height = CapsuleHeight,
                Radius = CapsuleRadius
            };
            collisionShape.Shape = capsuleShape;
        }

        _inputArea.AddChild(collisionShape);
        ConnectSignals();
    }

    public override void _ExitTree() {
        DisconnectSignals();

        if (_parent != null) {
            SignalHelper.DisconnectSignal(_parent, nameof(Entity3D.EntityUpdated), this, nameof(OnEntityUpdated));
        }

        EventBus.Instance.Disconnect(nameof(EventBus.CharacterUnselected), new Callable(this, nameof(OnCharacterUnselected)));
    }

    private void ConnectSignals() {
        if (_inputArea != null) {
            _inputArea.Connect("input_event", new Callable(this, nameof(OnInputEvent)));
            _inputArea.Connect("mouse_entered", new Callable(this, nameof(OnMouseEntered)));
            _inputArea.Connect("mouse_exited", new Callable(this, nameof(OnMouseExited)));
        }
    }

    private void DisconnectSignals() {
        if (_inputArea != null) {
            if (_inputArea.IsConnected("input_event", new Callable(this, nameof(OnInputEvent)))) {
                _inputArea.Disconnect("input_event", new Callable(this, nameof(OnInputEvent)));
            }
            if (_inputArea.IsConnected("mouse_entered", new Callable(this, nameof(OnMouseEntered)))) {
                _inputArea.Disconnect("mouse_entered", new Callable(this, nameof(OnMouseEntered)));
            }
            if (_inputArea.IsConnected("mouse_exited", new Callable(this, nameof(OnMouseExited)))) {
                _inputArea.Disconnect("mouse_exited", new Callable(this, nameof(OnMouseExited)));
            }
        }
    }

    private void OnMouseEntered() {
        IsHovered = true;
    }

    private void OnMouseExited() {
        IsHovered = false;
    }

    private void OnEntityUpdated() {
        // Update selectable state based on entity data if needed
    }

    private void OnInputEvent(Node camera, InputEvent @event, Vector3 clickPosition, Vector3 normal, int shapeIdx) {
        if (@event is InputEventMouseButton { Pressed: true }) {
            HandleSelection(this);
        }
    }

    private static void HandleSelection(SelectableComponent current) {
        if (_currentlySelectedComponent == current) {
            current.IsSelected = false;
            _currentlySelectedComponent = null;
            EventBus.Instance.EmitSignal(nameof(EventBus.CharacterUnselected));
        }
        else {
            if (_currentlySelectedComponent is not null) {
                _currentlySelectedComponent.IsSelected = false;
            }
            current.IsSelected = true;
            _currentlySelectedComponent = current;

            // Pass the parent entity to the selection event if available
            var entity = current.GetParent<Entity3D>();
            if (entity != null) {
                EventBus.Instance.EmitSignal(nameof(EventBus.CharacterSelected), entity);
            }
            else {
                EventBus.Instance.EmitSignal(nameof(EventBus.CharacterSelected), current);
            }
        }
    }

    private void OnCharacterUnselected() {
        IsSelected = false;
    }

    private void OnIsSelectedSet(bool isSelected) {
        if (SelectorSprite is not null) {
            SelectorSprite.Visible = isSelected;
        }
    }

    private void OnIsHoveredSet(bool isHovered) {
        if (HoverSpriteNode is not null) {
            HoverSpriteNode.Visible = isHovered;
        }
    }

    // Called by the inspector to update the collision shape when properties change
    public void UpdateShape() {
        if (_inputArea == null || !IsInstanceValid(_inputArea))
            return;

        var collisionShape = _inputArea.GetChild<CollisionShape3D>(0);
        if (collisionShape == null)
            return;

        if (ShapeType == CollisionShapeType.Box) {
            var boxShape = collisionShape.Shape as BoxShape3D ?? new BoxShape3D();
            boxShape.Size = BoxSize;
            collisionShape.Shape = boxShape;
        }
        else { // Capsule
            var capsuleShape = collisionShape.Shape as CapsuleShape3D ?? new CapsuleShape3D();
            capsuleShape.Height = CapsuleHeight;
            capsuleShape.Radius = CapsuleRadius;
            collisionShape.Shape = capsuleShape;
        }
    }
}