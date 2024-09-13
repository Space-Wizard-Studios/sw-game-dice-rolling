import { CharacterName } from './CharacterName';
import { CharacterRole } from './CharacterRole';
import { CharacterImage } from './CharacterImage';
import { CharacterHealth } from './CharacterHealth';
import { CharacterDice } from './CharacterDice';
import { CharacterAction } from './CharacterAction';
import { cn } from '@helpers/cn';

import type { Component } from 'solid-js';
import type { Character } from '@models/Characters';
import { getRoleBaseHealth } from '@helpers/getRole';

type CharacterSheetProps = {
    character: Character;
    class?: string;
    onClick?: () => void;
}

export const CharacterSheet: Component<CharacterSheetProps> = (props) => {
    const containerStyle = 'flex flex-row w-full items-center p-2 gap-2 rounded-md bg-blue-100 bg-opacity-25 border-2 border-black border-opacity-50'

    return (
        <div class={cn(containerStyle, props.class)} onClick={props.onClick} >
            <CharacterImage src={props.character.role.image} />
            <div class='flex flex-col p-2'>
                <CharacterName name={props.character.name} />
                <CharacterRole role={props.character.role} />
                <CharacterHealth health={props.character.health ?? getRoleBaseHealth(props.character.role)} />
                {props.character.diceSet && <CharacterDice diceSet={props.character.diceSet} />}
                {/* <CharacterAction /> */}
            </div>
        </div>
    );
};