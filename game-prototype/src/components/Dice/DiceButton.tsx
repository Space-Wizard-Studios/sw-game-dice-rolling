import type { Component } from 'solid-js';
import { Button } from '@components/ui/button';
import {
	Popover,
	PopoverContent,
	PopoverDescription,
	PopoverTitle,
	PopoverTrigger,
} from '@components/ui/popover';

import { getDiceIcon } from '@assets/diceIcons';
import type { PopoverTriggerProps } from '@kobalte/core/popover';

import type { Dice } from '@models/Dice';
import { getActionList, getActionProbabilities, getMostProbableAction } from '@helpers/getDiceActions';

type DiceButtonProps = {
	dice: Dice;
	class?: string;
}

export const DiceButton: Component<DiceButtonProps> = (props) => {

	const actionProbabilities = getActionProbabilities(props.dice);
	const mostProbableAction = getMostProbableAction(props.dice);
	const actionList = getActionList(props.dice);

	return (
		<Popover>
			<PopoverTrigger
				as={(triggerProps: PopoverTriggerProps) => (
					<Button {...triggerProps} class='flex w-8 h-8 p-1 bg-white rounded-full dark:bg-black text-blue-500 overflow-visible items-center justify-center'>
						<div class='w-6 h-6'>
							{getDiceIcon(props.dice.sides)}
						</div>
					</Button>
				)}
			/>
			<PopoverContent class='overflow-auto'>
				<div class='flex flex-col space-y-1'>
					<PopoverTitle>
						<h4 class='font-medium leading-none'>Actions for {props.dice.name}</h4>
					</PopoverTitle>
					<PopoverDescription>
						<div>
							<h5 class='font-medium'>Probability:</h5>
							<ul>
								{actionProbabilities.map(({ name, probability }) => (
									<li>
										{name} - {probability}%
									</li>
								))}
							</ul>
						</div>
						<div>
							<h5 class='font-medium'>Dice:</h5>
							<ul>
								{actionList.map((actionName) => (
									<li>
										{actionName}
									</li>
								))}
							</ul>
						</div>
					</PopoverDescription>
				</div>
			</PopoverContent>
		</Popover>
	);
};