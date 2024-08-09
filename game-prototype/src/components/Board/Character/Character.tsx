import { CharacterImage } from './CharacterImage';
import { CharacterHealth } from './CharacterHealth';
import { CharacterDice } from './CharacterDice';
import { CharacterAction } from './CharacterAction';

import type { Component } from 'solid-js';
import type { Character } from 'types/characters';

export const CharacterSheet: Component<Character> = (character) => {
    return (
        <div class="flex flex-row items-center p-2 gap-2 bg-black bg-opacity-25 border-2 border-black border-opacity-50">
            <CharacterImage src="https://via.placeholder.com/150" />
            <div class="flex flex-col p-2 gap-2">
                <p class="text-lg font-bold">{character.name}</p>
                <CharacterHealth health={character.health} />
                <CharacterDice diceSet={character.diceSet ?? []} />
                <CharacterAction />
            </div>
        </div>
    );
};