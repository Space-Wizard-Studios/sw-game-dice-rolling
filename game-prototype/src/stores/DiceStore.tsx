import { createStore } from 'solid-js/store';
import { getActionProbabilities, getActionList, getMostProbableAction } from '@helpers/getDiceActions';
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

	function removeDice(diceName: string): void {
		setStore('diceSet', (diceSet) => diceSet.filter(d => d.name !== diceName));
	}

	function getDiceByID(diceID: string): Dice | undefined {
		return store.diceSet.find(d => d.id === diceID);
	}

	function getDiceByName(diceName: string): Dice | undefined {
		return store.diceSet.find(d => d.name === diceName);
	}

	function getActionProbabilities(dice: Dice) {
		return getActionProbabilities(dice);
	}

	function getActionList(dice: Dice) {
		return getActionList(dice);
	}

	function getMostProbableAction(dice: Dice) {
		return getMostProbableAction(dice);
	}

	return {
		store,
		addDice,
		addMultipleDice,
		removeDice,
		getDiceByID,
		getDiceByName,
		getActionProbabilities,
		getActionList,
	};
}

export const playerDiceStore = createDiceStore();