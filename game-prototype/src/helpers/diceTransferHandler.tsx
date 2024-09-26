import { diceStore } from '@stores/DiceStore';
import { inventoryStore } from '@stores/InventoryStore';
import { playerCharacterStore } from '@stores/CharacterStore';
import { isCharacterId, isInventory } from '@helpers/diceLocationGuards';
import type { DiceLocation } from '@models/Dice';

export function transferDice(diceId: string, fromLocation: DiceLocation, toLocation: DiceLocation): void {
	if (fromLocation === toLocation) return;

	if (isInventory(fromLocation)) {
		inventoryStore.removeDiceFromInventory(diceId);
	} else if (isCharacterId(fromLocation)) {
		playerCharacterStore.removeDiceFromCharacter(fromLocation, diceId);
	}

	if (isInventory(toLocation)) {
		inventoryStore.addDiceToInventory(diceId);
	} else if (isCharacterId(toLocation)) {
		playerCharacterStore.addDiceToCharacter(toLocation, diceId);
	}

	diceStore.updateDiceLocation(diceId, toLocation);
	console.log('Dice transferred from:', fromLocation, 'to:', toLocation);
}