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

	function getActionProbabilities(dice: Dice) {
		return getActionProbabilities(dice);
	}

	function getActionList(dice: Dice) {
		return getActionList(dice);
	}

	function getMostProbableActions(dice: Dice) {
		return getMostProbableActions(dice);
	}

	function updateDiceName(diceID: string, newName: string): void {
		setStore('diceSet', (diceSet) =>
			diceSet.map(dice => dice.id === diceID ? { ...dice, name: newName } : dice)
		);
	}

	function removeDice(diceName: string): void {
		setStore('diceSet', (diceSet) => diceSet.filter(d => d.name !== diceName));
	}


	return {
		store,
		addDice,
		addMultipleDice,
		getDiceByID,
		getDiceByName,
		getActionProbabilities,
		getActionList,
		updateDiceName,
		removeDice,
	};
}

export const playerDiceStore = createDiceStore();