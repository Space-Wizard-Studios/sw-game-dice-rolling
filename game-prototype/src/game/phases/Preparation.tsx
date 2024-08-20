import { render } from 'solid-js/web';
import { createSignal, createEffect, onMount } from 'solid-js';

import { addDialogueLine, addDialogueMessage } from '@stores/DialogueStore';
import { SelectionDialog } from '@components/CharacterSelection/SelectionDialog';
import { generateRandomCharacters } from '@helpers/generateRandomCharacters';
import { renderCharacter } from '@components/CharacterSelection/SelectionDialog';

import type { Character } from 'types/Characters';

export async function Preparation() {
    const [selectedCharacter, setSelectedCharacter] = createSignal<Character>();
    const [isDialogOpen, setDialogOpen] = createSignal(false);

    addDialogueMessage({
        lines: [
            { text: 'This is the build phase.' },
        ]
    });

    const characters = generateRandomCharacters(3);
    console.log(characters);

    onMount(() => {
        setDialogOpen(true);
    });

    const selectCharacter = () => {
        return new Promise<Character>((resolve) => {
            const handleConfirm = (character: Character) => {
                setSelectedCharacter(character);
                setDialogOpen(false);
                console.log('Selected character:', character);
                resolve(character);
            };

            render(() => (
                <SelectionDialog<Character>
                    open={isDialogOpen()}
                    items={characters}
                    renderItem={renderCharacter}
                    onConfirm={handleConfirm}
                />
            ), document.body);
        });
    };


    const character = await selectCharacter();
    addDialogueLine(`Character chosen: ${character.name}`);

    return null;
}

// - Prompt the player to choose one character
// - Generate dices and present them to the player
// - Prompt the player to choose one dice to be added to the player's inventory
// - Prompt the player to choose one dice and assign it to the character's diceSet