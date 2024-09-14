import { createSignal } from 'solid-js';
import { render } from 'solid-js/web';
import { ItemSelection } from './ItemSelection';
import { generateRandomDice } from '@helpers/generateRandomDiceSet';

import type { DiceActionsMap, DiceType } from '@models/Dice';
import { DiceButton } from '@components/Dice/DiceButton';
import { getMostProbableAction } from '@helpers/getDice';

export function DiceSelection(quantity: number, dice: DiceType[]): Promise<DiceType> {
	const [selectedDice, setSelectedDice] = createSignal<DiceType>();
	const [isDialogOpen, setDialogOpen] = createSignal(true);

	const diceSides = dice.map(d => d.sides as keyof DiceActionsMap);
	const diceOptions = generateRandomDice(quantity, diceSides);

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
				renderIcon={renderIcon}
				renderItem={renderDice}
				onConfirm={handleConfirm}
			/>
		), document.body);
	});
}

const renderDice = (dice: DiceType) => (
	<div class='flex justify-between'>
		<p class='text-left'>
			{dice.name}, {getMostProbableAction(dice).name} ({getMostProbableAction(dice).probability}%)
		</p>
		<p>{dice.actions.length} sides</p>
	</div>
);

const renderIcon = (dice: DiceType) => (
	<DiceButton dice={dice} />
);