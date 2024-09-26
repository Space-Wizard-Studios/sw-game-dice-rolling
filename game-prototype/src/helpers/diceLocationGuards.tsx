import { playerCharacterStore } from '@stores/CharacterStore';
import type { DiceLocation } from '@models/Dice';

export function isInventory(location: DiceLocation): location is 'inventory' {
	return location === 'inventory';
}

export function isCharacterId(location: DiceLocation): location is string {
	return typeof location === 'string' && !!playerCharacterStore.getCharacterById(location);
}

export function isValidLocation(location: DiceLocation): boolean {
	return isInventory(location) || isCharacterId(location);
}