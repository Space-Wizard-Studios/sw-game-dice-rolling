import { createStore } from 'solid-js/store';
import { transferDice } from '@helpers/diceTransferHandler';

export type InventoryStore = {
	diceIds: string[];
};

function createInventoryStore() {
	const [store, setStore] = createStore<InventoryStore>({ diceIds: [] });

	function addDiceToInventory(diceId: string): void {
		setStore('diceIds', (diceIds) => [...diceIds, diceId]);
	}

	function removeDiceFromInventory(diceId: string): void {
		setStore('diceIds', (diceIDs) => diceIDs.filter(id => id !== diceId));
	}

	return {
		store,
		addDiceToInventory,
		removeDiceFromInventory,
		transferDice,
	};
}

export const inventoryStore = createInventoryStore();