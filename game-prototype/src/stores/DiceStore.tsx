import { createStore } from 'solid-js/store';
import { getActionProbabilities, getActionList, getMostProbableActions } from '@helpers/getDiceActions';
import type { Dice } from '@models/Dice';

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

	function getDiceByID(diceID: string): Dice | undefined {
		return store.diceSet.find(d => d.id === diceID);
	}

	function getDiceByName(diceName: string): Dice | undefined {
		return store.diceSet.find(d => d.name === diceName);
	}

	function updateDiceByID(diceID: string, updateFn: (dice: Dice) => Dice): void {
		setStore('diceSet', (diceSet) =>
			diceSet.map(dice => dice.id === diceID ? updateFn(dice) : dice)
		);
	}

	function updateDiceName(diceID: string, newName: string): void {
		updateDiceByID(diceID, dice => ({ ...dice, name: newName }));
	}

	function removeDice(diceID: string): void {
		setStore('diceSet', (diceSet) => diceSet.filter(d => d.id !== diceID));
	}

	return {
		store,
		addDice,
		addMultipleDice,
		getDiceByID,
		getDiceByName,
		getActionProbabilities,
		getActionList,
		getMostProbableActions,
		updateDiceName,
		removeDice,
	};
}

export const diceStore = createDiceStore();