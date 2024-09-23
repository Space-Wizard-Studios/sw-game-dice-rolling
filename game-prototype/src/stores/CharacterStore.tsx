import { createStore } from 'solid-js/store';
import type { Character } from '@models/Character';

export type CharacterStore = {
	characters: Character[];
};

function createCharacterStore() {
	const [store, setStore] = createStore<CharacterStore>({ characters: [] });

	function addCharacter(character: Character): void {
		setStore('characters', (characters) => [...characters, character]);
	}

	function addCharacters(charactersToAdd: Character[]): void {
		setStore('characters', (characters) => [...characters, ...charactersToAdd]);
	}

	function removeCharacter(characterID: string): void {
		setStore('characters', (characters) =>
			characters.filter(c => c.id !== characterID)
		);
	}

	function getCharacterById(characterID: string): Character | undefined {
		return store.characters.find(c => c.id === characterID);
	}

	function updateCharacter(characterID: string, updatedFields: Partial<Character>): void {
		setStore('characters', (characters) =>
			characters.map(c => c.id === characterID ? { ...c, ...updatedFields } : c)
		);
	}

	function addDiceToCharacter(characterID: string, diceID: string): void {
		const character = getCharacterById(characterID);
		if (character) {
			updateCharacter(characterID, { diceIDs: [...(character.diceIDs || []), diceID] });
		}
	}

	function removeDiceFromCharacter(characterID: string, diceID: string): void {
		const character = getCharacterById(characterID);
		if (character) {
			updateCharacter(characterID, { diceIDs: (character.diceIDs || []).filter(id => id !== diceID) });
		}
	}

	return {
		store,
		addCharacter,
		addCharacters,
		removeCharacter,
		getCharacterById,
		updateCharacter,
		addDiceToCharacter,
		removeDiceFromCharacter,
	};
}

export const playerCharacterStore = createCharacterStore();
export const enemyCharacterStore = createCharacterStore();