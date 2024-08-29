import { CharacterImage } from './CharacterImage';
import { CharacterHealth } from './CharacterHealth';
import { CharacterDice } from './CharacterDice';
import { CharacterAction } from './CharacterAction';
import { cn } from '@helpers/cn';

import type { Component } from 'solid-js';
import type { Character } from '@models/Characters';

type CharacterSheetProps = {
    character: Character;
    class?: string;
    onClick?: () => void;
    onImageClick?: () => void;
    onHealthClick?: () => void;
    onDiceClick?: () => void;
    onActionClick?: () => void;
}

export const CharacterSheet: Component<CharacterSheetProps> = (props) => {
    return (
        <div
            class={cn(`flex flex-row items-center p-2 gap-2 rounded-md`,
                `bg-blue-100 bg-opacity-25 border-2 border-black border-opacity-50`,
                props.class)
            }
            onClick={props.onClick}
        >
            <CharacterImage
                src={props.character.image}
                onClick={props.onImageClick}
            />
            <div class='flex flex-col p-2'>
                <h2 class='text-lg'>{props.character.name}</h2>
                <CharacterHealth
                    health={props.character.health}
                    onClick={props.onHealthClick}
                />
                <CharacterDice
                    diceSet={props.character.diceSet ?? []}
                    onClick={props.onDiceClick}
                />
                <CharacterAction
                    onClick={props.onActionClick}
                />
            </div>
        </div>
    );
};