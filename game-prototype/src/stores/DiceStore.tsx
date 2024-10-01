import { createStore } from 'solid-js/store';
import { getActionProbabilities, getActionList, getMostProbableActions } from '@helpers/getDiceActions';
import type { Dice, DiceLocation } from '@models/Dice';

export type DiceStore = {
	diceSet: Dice[];
};

function createDiceStore() {
	const [store, setStore] = createStore<DiceStore>({ diceSet: [] });

	function addDice(dice: Dice): void {
		setStore('diceSet', (diceSet) => [...diceSet, dice]);
	}

	function addMultipleDice(diceArray: Dice[]): void {
		setStore('diceSet', (diceSet) => [...diceSet, ...diceArray]);
	}

	function getDiceByID(diceId: string): Dice {
		const dice = store.diceSet.find(d => d.id === diceId);
		if (!dice) {
			throw new Error(`Dice with ID ${diceId} not found`);
		}
		return dice;
	}

	function updateDiceByID(diceId: string, updateFn: (dice: Dice) => Dice): void {
		setStore('diceSet', (diceSet) =>
			diceSet.map(dice => dice.id === diceId ? updateFn(dice) : dice)
		);
	}

	function updateDiceName(diceId: string, newName: string): void {
		updateDiceByID(diceId, dice => ({ ...dice, name: newName }));
	}

	function updateDiceLocation(diceId: string, newLocation: DiceLocation): void {
		setStore('diceSet', (diceSet) =>
			diceSet.map(dice => dice.id === diceId ? { ...dice, location: newLocation } : dice)
		);

	}

	function removeDice(diceID: string): void {
		setStore('diceSet', (diceSet) => diceSet.filter(d => d.id !== diceID));
	}

	return {
		store,
		addDice,
		addMultipleDice,
		getDiceByID,
		getActionProbabilities,
		getActionList,
		getMostProbableActions,
		updateDiceName,
		updateDiceLocation,
		removeDice
	};
}

export const diceStore = createDiceStore();