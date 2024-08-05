import { Character } from 'types/characters';
import { Roles } from 'types/roles';

export const playableCharacters: Character[] = [
    {
        name: "Fighter",
        role: Roles.Fighter,
        health: {
            max: 100,
        },
        speed: {
            max: 10,
        },
        die: null,
    },
    {
        name: "Assassin",
        role: Roles.Assassin,
        health: {
            max: 100,
        },
        speed: {
            max: 10,
        },
        die: null,
    },
    {
        name: "Healer",
        role: Roles.Healer,
        health: {
            max: 100,
            current: 100,
        },
        speed: {
            max: 10,
        },
        die: null,
    },
];