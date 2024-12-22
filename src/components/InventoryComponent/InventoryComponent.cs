using Godot;
using System;

namespace DiceRoll.Components;

[Tool]
public partial class InventoryComponent : ScrollContainer {
    [Export] public int ItemSize { get; set; } = 64;
    [Export] public int ItemCount { get; set; } = 6;
    [Export] public NodePath? InventoryGridPath { get; set; }
    [Export] public NodePath? ItemComponentPath { get; set; }
    [Export] public int MaxSlots = 100;

    private Control? _inventoryGrid;
    private InventoryItemComponent? _itemComponent;
    private bool _tabChangedConnected = false;

    public override void _Ready() {
        if (Engine.IsEditorHint()) {
            return;
        }

        _inventoryGrid = GetNode<Control>(InventoryGridPath);
        _itemComponent = GetNode<InventoryItemComponent>(ItemComponentPath);
        Connect("resized", Callable.From(OnResized));

        // Check if the parent is a TabContainer and connect the tab_changed signal
        if (GetParent() is TabContainer tabContainer) {
            tabContainer.Connect("tab_changed", Callable.From<int>(OnTabChanged));
            _tabChangedConnected = true;
        }

        GD.Print("InventoryComponent Ready: Calling UpdateGrid");
        CallDeferred(nameof(UpdateGrid));
    }

    private void OnTabChanged(int tabIndex) {
        GD.Print("Tab changed: Calling UpdateGrid");
        CallDeferred(nameof(UpdateGrid));
    }

    private void OnResized() {
        GD.Print("Resized: Calling UpdateGrid");
        CallDeferred(nameof(UpdateGrid));
    }

    private int GetRowCount() {
        int columnCount = GetColumnCount();
        return columnCount == 0 ? 1 : MaxSlots / columnCount;
    }

    private int GetColumnCount() {
        int columnCount = (int)Math.Floor(Size.X / ItemSize);
        return columnCount == 0 ? 1 : columnCount;
    }

    private void ResizeGrid() {
        if (_inventoryGrid != null) {
            _inventoryGrid.CustomMinimumSize = new Vector2(GetColumnCount() * ItemSize, GetRowCount() * ItemSize);
        }
    }

    private Vector2 IndexToPos(int index) {
        return new Vector2(index % GetColumnCount(), index / GetColumnCount());
    }

    private void UpdateSlots() {
        GD.Print("Updating slots with ItemCount: ", ItemCount);
        for (int slotIndex = 0; slotIndex < MaxSlots; slotIndex++) {
            if (_inventoryGrid != null && _inventoryGrid.GetChildCount() - 1 < slotIndex) {
                if (_itemComponent == null) {
                    GD.PrintErr("Item component is null, cannot instantiate.");
                    return;
                }
                var newItemComponent = _itemComponent.Duplicate() as InventoryItemComponent;
                if (newItemComponent != null) {
                    newItemComponent.Position = IndexToPos(slotIndex) * ItemSize;
                    _inventoryGrid.AddChild(newItemComponent);
                }
                else {
                    GD.PrintErr("Duplicated item is not of type InventoryItemComponent.");
                    return;
                }
            }

            var existingItemComponent = _inventoryGrid?.GetChild(slotIndex) as InventoryItemComponent;
            if (existingItemComponent == null) {
                GD.PrintErr("Item component is null, cannot update slot.");
                continue;
            }
            existingItemComponent.Visible = ItemCount > slotIndex;
        }
    }

    private void UpdateGrid() {
        GD.Print("Updating grid");
        ResizeGrid();
        UpdateSlots();
    }

    public override void _Input(InputEvent @event) {
        if (@event.IsActionPressed("give_item", true)) {
            ItemCount += 1;
            GD.Print("Item added: New ItemCount is ", ItemCount);
            UpdateSlots();
        }
    }

    private Vector2 MakeInputLocal(InputEventMouseButton mouseEvent) {
        return mouseEvent.Position - GlobalPosition;
    }

    public override void _ExitTree() {
        // Disconnect the tab_changed signal if it was connected
        if (_tabChangedConnected && GetParent() is TabContainer tabContainer) {
            tabContainer.Disconnect("tab_changed", Callable.From<int>(OnTabChanged));
        }
    }
}