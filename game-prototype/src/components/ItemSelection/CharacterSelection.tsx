import { render } from 'solid-js/web';
import { createSignal } from 'solid-js';
import { ItemSelection } from '@components/ItemSelection/ItemSelection';
import { renderCharacter } from '@components/ItemSelection/ItemSelection';
import { playerCharacterStore } from '@stores/Character';
import type { Character } from '@models/Characters';

/**
 * Displays a character selection dialog and returns a promise that resolves with the selected character.
 * 
 * @param {Character[]} characters - An array of characters to choose from.
 * @returns {Promise<Character>} - A promise that resolves with the selected character.
 */
export function CharacterSelection(characters: Character[]): Promise<Character> {
    const [selectedCharacter, setSelectedCharacter] = createSignal<Character>();
    const [isDialogOpen, setDialogOpen] = createSignal(true);

    return new Promise<Character>((resolve) => {
        const handleConfirm = (character: Character) => {
            setSelectedCharacter(character);
            setDialogOpen(false);
            console.log('Selected character:', character);
            playerCharacterStore.addCharacter(character);
            resolve(character);
        };

        render(() => (
            <ItemSelection
                open={isDialogOpen()}
                items={characters}
                renderItem={renderCharacter}
                onConfirm={handleConfirm}
            />
        ), document.body);
    });
}