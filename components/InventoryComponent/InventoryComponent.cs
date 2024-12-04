using Godot;
using System;

[Tool]
public partial class InventoryComponent : ScrollContainer {
	[Export] public int ItemSize { get; set; } = 64;
	[Export] public int ItemCount { get; set; } = 6;
	[Export] public Texture2D? SlotTexture { get; set; }
	[Export] public Texture2D? ItemTexture { get; set; }
	[Export] public NodePath? GridItemTemplatePath { get; set; }
	[Export] public NodePath? InventoryGridPath { get; set; }
	[Export] public int MaxSlots = 100;

	private TextureRect? _gridItemTemplate;
	private Control? _inventoryGrid;

	public override void _Ready() {
		_gridItemTemplate = GetNode<TextureRect>(GridItemTemplatePath);
		_inventoryGrid = GetNode<Control>(InventoryGridPath);
		Connect("resized", Callable.From(OnResized));

		// Check if the parent is a TabContainer and connect the tab_changed signal
		if (GetParent() is TabContainer tabContainer) {
			tabContainer.Connect("tab_changed", Callable.From<int>(OnTabChanged));
		}

		CallDeferred(nameof(UpdateGrid));
	}

	private void OnTabChanged(int tabIndex) {
		CallDeferred(nameof(UpdateGrid));
	}

	private void OnResized() {
		UpdateGrid();
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
		int rows = GetRowCount();
		int columns = GetColumnCount();

		for (int slotIndex = 0; slotIndex < MaxSlots; slotIndex++) {
			if (_inventoryGrid != null && _inventoryGrid.GetChildCount() - 1 < slotIndex) {
				if (_gridItemTemplate == null) {
					GD.PrintErr("Grid item template is null, cannot duplicate.");
					return;
				}
				var newGridItem = (TextureRect)_gridItemTemplate.Duplicate();
				newGridItem.Position = IndexToPos(slotIndex) * ItemSize;
				newGridItem.Texture = SlotTexture;
				_inventoryGrid.AddChild(newGridItem);
			}

			var gridItem = _inventoryGrid?.GetChild(slotIndex) as TextureRect;
			if (gridItem == null) {
				GD.PrintErr("Grid item is null, cannot update slot.");
				continue;
			}
			gridItem.Texture = ItemCount > slotIndex ? ItemTexture : SlotTexture;
		}
	}

	private void UpdateGrid() {
		ResizeGrid();
		UpdateSlots();
	}

	public override void _Input(InputEvent @event) {
		if (@event.IsActionPressed("give_item", true)) {
			ItemCount += 1;
			UpdateSlots();
		}
		else if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed) {
			var mousePos = MakeInputLocal(mouseEvent);
			int itemColumn = (int)(mousePos.X / ItemSize);
			if (itemColumn >= GetColumnCount()) {
				return;
			}

			int itemRow = (int)(mousePos.Y / ItemSize);
			if (itemRow >= GetRowCount()) {
				return;
			}
		}
	}

	private Vector2 MakeInputLocal(InputEventMouseButton mouseEvent) {
		return mouseEvent.Position - GlobalPosition;
	}
}