import { createStore } from 'solid-js/store';
import type { Character } from ./types/Characters';

export type CharacterStore = {
    characters: Character[];
};

function createCharacterStore() {
    const [store, setStore] = createStore<CharacterStore>({ characters: [] });

    function addCharacter(character: Character) {
        setStore('characters', (characters) => [...characters, character]);
    }

    function addCharacters(charactersToAdd: Character[]) {
        setStore('characters', (characters) => [...characters, ...charactersToAdd]);
    }

    function removeCharacter(characterID: string) {
        setStore('characters', (characters) =>
            characters.filter(c => c.id !== characterID)
        );
    }

    function getCharacterById(characterId: string) {
        return store.characters.find(c => c.id === characterId);
    }

    return {
        store,
        addCharacter,
        addCharacters,
        removeCharacter,
        getCharacterById,
    };
}

export const playerCharacterStore = createCharacterStore();
export const enemyCharacterStore = createCharacterStore();