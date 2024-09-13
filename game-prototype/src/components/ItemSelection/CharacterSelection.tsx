import { render } from 'solid-js/web';
import { createSignal } from 'solid-js';
import { ItemSelection } from '@components/ItemSelection/ItemSelection';
import { CharacterSheet } from '@components/Board/Character/CharacterSheet';

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
			resolve(character);
		};

		render(() => (
			<ItemSelection
				title='Escolha um personagem'
				description='Selecione um personagem para continuar.'
				open={isDialogOpen()}
				items={characters}
				renderItem={renderCharacter}
				onConfirm={handleConfirm}
			/>
		), document.body);
	});
}

export const renderCharacter = (character: Character, selectItem: () => void, isSelected: boolean) => (
	<CharacterSheet character={character} onClick={selectItem}
		class={isSelected ? 'border-2 border-blue-500 bg-blue-200' : ''}
	/>
);