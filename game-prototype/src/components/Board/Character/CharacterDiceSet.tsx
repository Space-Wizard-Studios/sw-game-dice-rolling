import type { Component } from 'solid-js';
import type { DiceType } from '@models/Dice';
import { CharacterDiceButton } from './CharacterDiceButton';

export type CharacterDiceProps = {
	diceSet: DiceType[];
	class?: string;
}

export const CharacterDiceSet: Component<CharacterDiceProps> = (props) => {
	return (
		<div class='flex flex-col md:flex-row gap-1 items-center justify-between'>
			<p class='text-sm'>Dice Set:</p>
			<ul class='flex list-none gap-1'>
				{props.diceSet.map((dice) => { return <li><CharacterDiceButton dice={dice} /></li> })}
			</ul>
		</div>
	);
};