import { createStore } from 'solid-js/store';
import type { Character } from '@models/Character';
import { transferDice } from '@helpers/diceTransferHandler';

export type CharacterStore = {
	characters: Character[];
};

function createCharacterStore() {
	const [store, setStore] = createStore<CharacterStore>({ characters: [] });

	function addCharacter(character: Character): void {
		setStore('characters', (characters) => [...characters, character]);
	}

	function addMultipleCharacters(charactersToAdd: Character[]): void {
		setStore('characters', (characters) => [...characters, ...charactersToAdd]);
	}

	function removeCharacter(characterID: string): void {
		setStore('characters', (characters) =>
			characters.filter(c => c.id !== characterID)
		);
	}

	function getAllCharacterIds(): string[] {
		return store.characters.map(c => c.id);
	}

	function getCharacterById(characterID: string): Character {
		const character = store.characters.find(c => c.id === characterID);
		if (!character) {
			throw new Error(`Character with ID ${characterID} not found`);
		}
		return character;
	}

	function updateCharacter(characterID: string, updatedFields: Partial<Character>): void {
		setStore('characters', (characters) =>
			characters.map(c => c.id === characterID ? { ...c, ...updatedFields } : c)
		);
	}

	function addDiceToCharacter(characterID: string, diceID: string): void {
		const character = getCharacterById(characterID);
		const diceIds = character.diceIds ?? [];
		if (diceIds.length >= character.diceCapacity) {
			throw new Error(`Character with ID ${characterID} cannot have more than ${character.diceCapacity} dice`);
		}
		updateCharacter(characterID, { diceIds: [...diceIds, diceID] });
	}

	function removeDiceFromCharacter(characterID: string, diceID: string): void {
		const character = getCharacterById(characterID);
		const diceIds = character.diceIds ?? [];
		updateCharacter(characterID, { diceIds: diceIds.filter(id => id !== diceID) });
	}

	return {
		store,
		addCharacter,
		addMultipleCharacters,
		removeCharacter,
		getAllCharacterIds,
		getCharacterById,
		updateCharacter,
		addDiceToCharacter,
		removeDiceFromCharacter,
		transferDice,
	};
}
export const playerCharacterStore = createCharacterStore();
export const enemyCharacterStore = createCharacterStore();