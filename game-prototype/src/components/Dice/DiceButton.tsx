import type { Component } from 'solid-js';
import { createSignal } from 'solid-js';

import { Popover, PopoverContent, PopoverDescription, PopoverTitle, PopoverTrigger, } from '@components/ui/popover';
import { Button } from '@components/ui/button';
import { TextField, TextFieldRoot } from '@components/ui/textfield';
import type { PopoverTriggerProps } from '@kobalte/core/popover';

import { playerDiceStore } from '@stores/DiceStore';

import type { Dice } from '@models/Dice';
import { getDiceIcon } from '@assets/diceIcons';
import { getActionList, getActionProbabilities } from '@helpers/getDiceActions';
import { Tooltip, TooltipContent, TooltipTrigger } from '@components/ui/tooltip';

type DiceButtonProps = {
	dice: Dice;
	class?: string;
	onNameChange?: (diceID: string, newName: string) => void;
}

export const DiceButton: Component<DiceButtonProps> = (props) => {
	const [name, setName] = createSignal(props.dice.name);
	
	const diceIcon = getDiceIcon(props.dice.sides);
	const actionProbabilities = getActionProbabilities(props.dice);
	const actionList = getActionList(props.dice);

	const handleNameChange = (event: Event) => {
		const newName = (event.target as HTMLInputElement).value;
		setName(newName);

		if (playerDiceStore.getDiceByID(props.dice.id)) {
			playerDiceStore.updateDiceName(props.dice.id, newName);
			console.log('Dice name updated at the store');
		}

		if (props.onNameChange) {
			props.onNameChange(props.dice.id, newName);
			console.log('Dice name updated at the parent component');
		}
	};


	return (
		<Popover>
			<Tooltip>
				<TooltipTrigger>
					<PopoverTrigger
						as={(triggerProps: PopoverTriggerProps) => (
							<Button {...triggerProps} class='flex w-8 h-8 p-1 bg-white rounded-full dark:bg-black text-blue-500 overflow-visible items-center justify-center'>
								{
									diceIcon ??
									<div class='w-6 h-6'>{diceIcon}</div>
								}
							</Button>
						)}
					/>
				</TooltipTrigger>
				<TooltipContent>
					<p>{props.dice.name}</p>
				</TooltipContent>
			</Tooltip>
			<PopoverContent class='overflow-auto'>
				<div class='flex flex-col space-y-1'>
					<PopoverTitle>
						<h4 class='font-medium leading-none'>
							<TextFieldRoot>
								<TextField
									value={name()}
									onBlur={handleNameChange}
									class='w-full'
									maxLength={20}
								/>
							</TextFieldRoot>
						</h4>
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