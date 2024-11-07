using System;

public class DiceAction {
	public string Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }

	public DiceAction(string id, string name, string description) {
		Id = id;
		Name = name;
		Description = description;
	}
}