import type { Component } from 'solid-js';
import { createSignal, createMemo } from 'solid-js';

import { Popover, PopoverContent, PopoverDescription, PopoverTitle, PopoverTrigger } from '@components/ui/popover';
import { Button } from '@components/ui/button';
import { TextField, TextFieldRoot } from '@components/ui/textfield';
import type { PopoverTriggerProps } from '@kobalte/core/popover';

import { playerDiceStore } from '@stores/DiceStore';

import type { Dice } from '@models/Dice';
import { getDiceIcon } from '@components/Dice/diceIcons';
import { getActionList, getActionProbabilities } from '@helpers/getDiceActions';
import { Tooltip, TooltipContent, TooltipTrigger } from '@components/ui/tooltip';
import { getDiceColors } from '@helpers/getDiceColor';
import { cn } from '@helpers/cn';

type DiceButtonProps = {
	dice: Dice;
	class?: string;
	onNameChange?: (diceID: string, newName: string) => void;
}

export const DiceButton: Component<DiceButtonProps> = (props) => {
	const [name, setName] = createSignal(props.dice.name);

	const actionProbabilities = createMemo(() => getActionProbabilities(props.dice).sort((a, b) => parseFloat(b.probability) - parseFloat(a.probability)));
	const actionList = createMemo(() => getActionList(props.dice));

	const diceIcon = createMemo(() => getDiceIcon(props.dice.sides));
	const diceColors = createMemo(() => getDiceColors(props.dice));

	const diceBackground = createMemo(() => {
		if (diceColors().length === 1) {
			return `background-color: ${diceColors()[0].background}; color: ${diceColors()[0].text};`;
		} else if (diceColors().length === 2) {
			return `background: linear-gradient(45deg, ${diceColors()[0].background} 50%, ${diceColors()[1].background} 50%); color: ${diceColors()[0].text};`;
		} else {
			const gradientColors = diceColors().map(color => color.background).join(', ');
			return `background: linear-gradient(45deg, ${gradientColors}); color: ${diceColors()[0].text};`;
		}
	});

	console.log(props.dice)

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
							<Button {...triggerProps}
								style={diceBackground()}
								class={cn(`flex w-8 h-8 p-1 rounded-full overflow-visible items-center justify-center`)}>
								{<div class='w-6 h-6'>{diceIcon()}</div>}
							</Button>
						)}
					/>
				</TooltipTrigger>
				<TooltipContent>
					<p>{props.dice.name}</p>
				</TooltipContent>
			</Tooltip>
			<PopoverContent>
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
					<div class='overflow-auto max-h-40 p-2'>
						<PopoverDescription class='space-y-2'>
							<div>
								<h5 class='font-medium'>Probabilidade:</h5>
								<ul>
									{actionProbabilities().map(({ name, probability }) => (
										<li class="flex flex-row justify-between even:bg-gray-100">
											<span>
												{name}
											</span>
											<span>
												{probability}%
											</span>
										</li>
									))}
								</ul>
							</div>
							<div>
								<h5 class='font-medium'>Ações:</h5>
								<ul>
									{actionList().map((actionName, index) => (
										<li>{(index + 1).toString().padStart(2, '0')} - {actionName}</li>
									))}
								</ul>
							</div>
						</PopoverDescription>
					</div>
				</div>
			</PopoverContent>
		</Popover >
	);
};