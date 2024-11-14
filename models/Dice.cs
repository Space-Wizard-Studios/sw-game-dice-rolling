using System;
using Godot;
using System.Collections.Generic;

public class Dice<[MustBeVariant] T> where T : DiceSide {
	public string Id { get; set; }
	public string Name { get; set; }
	public Godot.Collections.Array<T> Actions { get; set; }
	public int Sides => Actions.Count;
	public DiceLocation Location { get; set; }

	public Dice(string id, string name, Godot.Collections.Array<T> actions, DiceLocation location) {
		Id = id;
		Name = name;
		Actions = actions;
		Location = location;
	}
}

public enum DiceLocation {
	Inventory,
	Character,
	None
}

public static class DiceFactory {
	public static Dice<DiceSide> CreateD4() => CreateDice(4);
	public static Dice<DiceSide> CreateD6() => CreateDice(6);
	public static Dice<DiceSide> CreateD8() => CreateDice(8);
	public static Dice<DiceSide> CreateD10() => CreateDice(10);
	public static Dice<DiceSide> CreateD12() => CreateDice(12);
	public static Dice<DiceSide> CreateD20() => CreateDice(20);
	public static Dice<DiceSide> CreateD100() => CreateDice(100);

	private static Dice<DiceSide> CreateDice(int sides) {
		var actions = new Godot.Collections.Array<DiceSide>();
		for (int i = 0; i < sides; i++) {
			actions.Add(new DiceSide(
				$"Action {i + 1}",
				$"A{i + 1}",
				$"Description for action {i + 1}",
				new Color(1, 1, 1), new Color(0, 0, 0)
			));
		}
		return new Dice<DiceSide>(Guid.NewGuid().ToString(), $"D{sides}", actions, DiceLocation.None);
	}
}