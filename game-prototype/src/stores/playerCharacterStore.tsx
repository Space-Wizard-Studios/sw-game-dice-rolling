import { createStore } from 'solid-js/store';
import { Roles } from 'types/roles';
import type { Character, CharacterStore } from 'types/characters';

const playerCharacters: Character[] = [
    {
        id: 'a',
        name: "Fighter",
        role: Roles.Fighter,
        health: {
            max: 100,
        },
        speed: {
            max: 10,
        },
    },
    {
        id: 'b',
        name: "Assassin",
        role: Roles.Assassin,
        health: {
            max: 50,
        },
        speed: {
            max: 10,
        },
    },
    {
        id: 'c',
        name: "Healer",
        role: Roles.Healer,
        health: {
            max: 100,
        },
        speed: {
            max: 10,
        },
    },
];

export const [characterStore, setCharacterStore] = createStore<CharacterStore>({
    characters: playerCharacters,
});

export function addPlayerCharacter(character: Character) {
    setCharacterStore('characters', (characters) => [...characters, character]);
}

export function removePlayerCharacter(characterName: string) {
    setCharacterStore('characters', (characters) => characters.filter(c => c.name !== characterName));
}

export function findCharacterById(characterId: string) {
    return characterStore.characters.find(c => c.id === characterId);
}