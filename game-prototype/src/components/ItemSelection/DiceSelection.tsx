import { createSignal } from 'solid-js';
import { render } from 'solid-js/web';
import { ItemSelection } from './ItemSelection';
import { generateRandomDiceSet } from '@helpers/generateRandomDiceSet';

import type { DiceType } from '@models/Dice';
import { CharacterDiceButton } from '@components/Board/Character/CharacterDiceButton';

export function DiceSelection(quantity: number, dice: DiceType[]): Promise<DiceType> {
	const [selectedDice, setSelectedDice] = createSignal<DiceType>();
	const [isDialogOpen, setDialogOpen] = createSignal(true);

	const diceOptions = generateRandomDiceSet(quantity, dice.map(d => parseInt(d.name.slice(1))));

	return new Promise<DiceType>((resolve) => {
		const handleConfirm = (dice: DiceType) => {
			setSelectedDice(dice);
			setDialogOpen(false);
			resolve(dice);
		};

		render(() => (
			<ItemSelection
				title='Escolha um dado'
				description='Selecione um dado para continuar.'
				open={isDialogOpen()}
				items={diceOptions}
				renderItem={renderDice}
				onConfirm={handleConfirm}
			/>
		), document.body);
	});
}

const renderDice = (dice: DiceType, selectItem: () => void, isSelected: boolean) => (
	<div onClick={selectItem} class={`p-1 border ${isSelected ? 'border-blue-500 bg-blue-200' : 'border-gray-300'}`}>
		<p>{dice.name}</p>
		<p>{dice.actions.length} sides</p>
		<CharacterDiceButton dice={dice} />
	</div >
);