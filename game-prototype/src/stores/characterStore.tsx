import { createStore } from 'solid-js/store';
import type { Character, CharacterType } from 'types/characters';

export type CharacterStore = {
    characters: Character[];
};

export const [characterStore, setCharacterStore] = createStore<CharacterStore>({
    characters: [],
});

export function addCharacterToStore(character: Character) {
    setCharacterStore('characters', (characters) =>
        [...characters, character]
    );
}

export function removeCharacterFromStore(characterID: string) {
    setCharacterStore('characters', (characters) =>
        characters.filter(c => c.id !== characterID)
    );
}

export function getCharacterById(characterId: string) {
    return characterStore.characters.find(c => c.id === characterId);
}

export function getCharactersByType(type: CharacterType) {
    return characterStore.characters.filter(c => c.type === type);
}