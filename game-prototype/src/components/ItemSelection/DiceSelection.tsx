import { createSignal } from 'solid-js';
import { render } from 'solid-js/web';
import { ItemSelection } from './ItemSelection';

import type { Dice } from '@models/Dice';
import { DiceButton } from '@components/Dice/DiceButton';
import { getUniqueActionsCount } from '@helpers/getDiceActions';

export function DiceSelection(diceSet: Dice[]): Promise<Dice> {
	const [selectedDice, setSelectedDice] = createSignal<Dice>();
	const [isDialogOpen, setDialogOpen] = createSignal(true);

	return new Promise<Dice>((resolve) => {
		const handleConfirm = (selectedDice: Dice) => {
			setSelectedDice(selectedDice);
			setDialogOpen(false);
			resolve(selectedDice);
		};

		render(() => (
			<ItemSelection
				title='Escolha um dado'
				description='Selecione um dado para continuar.'
				open={isDialogOpen()}
				items={diceSet}
				renderIcon={renderDiceIcon}
				renderItem={renderDiceInfo}
				onConfirm={handleConfirm}
			/>
		), document.body);
	});
}

const renderDiceInfo = (dice: Dice) => (
	<p>
		{dice.name}: {dice.actions.length} lados, {getUniqueActionsCount(dice)} ações diferentes
	</p>
);

const renderDiceIcon = (dice: Dice) => (
	<DiceButton dice={dice} />
);