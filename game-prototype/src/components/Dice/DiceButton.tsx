import type { Component } from 'solid-js';
import { Button } from '@components/ui/button';
import {
	Popover,
	PopoverContent,
	PopoverDescription,
	PopoverTitle,
	PopoverTrigger,
} from '@components/ui/popover';

import { diceD4 } from '@assets/icons';

import type { PopoverTriggerProps } from '@kobalte/core/popover';
import type { DiceType } from '@models/Dice';

type DiceButtonProps = {
	dice: DiceType;
	class?: string;
}

const diceIcons = {
	D4: diceD4,
	// D6: diceD6,
	// D8: diceD8,
	// D10: diceD10,
	// D12: diceD12,
	// D20: diceD20,
	// D100: diceD100,
};

export const DiceButton: Component<DiceButtonProps> = (props) => {
	// store the count of each unique action
	const actionCountMap = new Map<string, number>();

	props.dice.actions.forEach(action => {
		actionCountMap.set(action.name, (actionCountMap.get(action.name) || 0) + 1);
	});

	// total number of actions
	const totalActions = props.dice.actions.length;

	// probability for each unique action
	const actionProbabilities = Array.from(actionCountMap.entries()).map(([name, count]) => ({
		name,
		probability: ((count / totalActions) * 100).toFixed(2)
	}));

	return (
		<Popover>
			<PopoverTrigger
				as={(triggerProps: PopoverTriggerProps) => (
					<Button {...triggerProps} class='w-4 h-4 p-4 bg-white rounded-full dark:bg-black text-blue-500'>
						<div class='w-6 h-6'>
							{diceIcons[props.dice.name as keyof typeof diceIcons]}
						</div>
					</Button>
				)}
			/>
			<PopoverContent class='w-80'>
				<div class='grid gap-1'>
					<PopoverTitle class='space-y-1'>
						<h4 class='font-medium leading-none'>Actions for {props.dice.name}</h4>
					</PopoverTitle>
					<PopoverDescription class='grid gap-1'>
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
								{props.dice.actions.map((action) => (
									<li>
										{action.name}
									</li>
								))}
							</ul>
						</div>
					</PopoverDescription>
				</div>
			</PopoverContent>
		</Popover>
	)
}