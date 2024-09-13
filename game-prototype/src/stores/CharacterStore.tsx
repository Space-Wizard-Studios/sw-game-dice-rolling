import { createStore } from 'solid-js/store';
import type { Character } from '@models/Characters';

export type CharacterStore = {
    characters: Character[];
};

function createCharacterStore() {
    const [store, setStore] = createStore<CharacterStore>({ characters: [] });

    /**
     * Adds a single character to the store.
     * @param {Character} character - The character to add.
     */
    function addCharacter(character: Character): void {
        setStore('characters', (characters) => [...characters, character]);
    }

    /**
     * Adds multiple characters to the store.
     * @param {Character[]} charactersToAdd - The characters to add.
     */
    function addCharacters(charactersToAdd: Character[]): void {
        setStore('characters', (characters) => [...characters, ...charactersToAdd]);
    }

    /**
     * Removes a character from the store by ID.
     * @param {string} characterID - The ID of the character to remove.
     */
    function removeCharacter(characterID: string): void {
        setStore('characters', (characters) =>
            characters.filter(c => c.id !== characterID)
        );
    }

    /**
     * Gets a character by ID.
     * @param {string} characterId - The ID of the character to retrieve.
     * @returns {Character | undefined} - The character if found, otherwise undefined.
     */
    function getCharacterById(characterId: string): Character | undefined {
        return store.characters.find(c => c.id === characterId);
    }

    /**
     * Updates a character's fields by ID.
     * @param {string} characterId - The ID of the character to update.
     * @param {Partial<Character>} updatedFields - The fields to update.
     */
    function updateCharacter(characterId: string, updatedFields: Partial<Character>): void {
        setStore('characters', (characters) =>
            characters.map(c => c.id === characterId ? { ...c, ...updatedFields } : c)
        );
    }

    return {
        store,
        addCharacter,
        addCharacters,
        removeCharacter,
        getCharacterById,
        updateCharacter
    };
}

export const playerCharacterStore = createCharacterStore();
export const enemyCharacterStore = createCharacterStore();