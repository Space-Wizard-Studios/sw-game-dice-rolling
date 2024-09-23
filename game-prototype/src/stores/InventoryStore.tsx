import { createStore } from 'solid-js/store';
import { playerCharacterStore } from './CharacterStore';
import type { Dice } from '@models/Dice';

export type InventoryStore = {
	diceIDs: string[];
};

function createInventoryStore() {
	const [store, setStore] = createStore<InventoryStore>({ diceIDs: [] });

	function addDiceToInventory(diceID: string): void {
		setStore('diceIDs', (diceIDs) => [...diceIDs, diceID]);
	}

	function removeDiceFromInventory(diceID: string): void {
		setStore('diceIDs', (diceIDs) => diceIDs.filter(id => id !== diceID));
	}

	function transferDiceToCharacter(characterID: string, diceID: string): void {
		removeDiceFromInventory(diceID);
		playerCharacterStore.addDiceToCharacter(characterID, diceID);
	}

	return {
		store,
		addDiceToInventory,
		removeDiceFromInventory,
		transferDiceToCharacter,
	};
}

export const inventoryStore = createInventoryStore();