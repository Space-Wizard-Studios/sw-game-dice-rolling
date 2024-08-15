import type { Component } from 'solid-js';
import { CharacterImage } from './CharacterImage';
import { CharacterHealth } from './CharacterHealth';
import { CharacterDice } from './CharacterDice';
import { CharacterAction } from './CharacterAction';
import type { Character } from 'types/characters';

export const CharacterSheet: Component<{ character: Character }> = (props) => {
    return (
        <div class='flex flex-row items-center p-2 gap-2 rounded-md bg-black bg-opacity-25 border-2 border-black border-opacity-50'>
            <CharacterImage src={props.character.image} />
            <div class='flex flex-col p-2'>
                <h2 class='text-lg'>{props.character.name}</h2>
                <CharacterHealth health={props.character.health} />
                <CharacterDice diceSet={props.character.diceSet ?? []} />
                <CharacterAction />
            </div>
        </div>
    );
};