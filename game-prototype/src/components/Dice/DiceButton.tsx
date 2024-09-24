import type { Component } from 'solid-js';
import { createSignal, createEffect } from 'solid-js';

import { Popover, PopoverContent, PopoverDescription, PopoverTitle, PopoverTrigger } from '@components/ui/popover';
import { Button } from '@components/ui/button';
import { TextField, TextFieldRoot } from '@components/ui/textfield';
import type { PopoverTriggerProps } from '@kobalte/core/popover';
import { Tooltip, TooltipContent, TooltipTrigger } from '@components/ui/tooltip';

import { diceStore } from '@stores/DiceStore';

import type { Dice, DiceLocation } from '@models/Dice';
import { getActionList, getActionProbabilities } from '@helpers/getDiceActions';
import { getDiceIcon } from '@assets/diceIcons';
import { getDiceColors } from '@helpers/getDiceColor';

import { cn } from '@helpers/cn';
import { isValidLocation } from '@helpers/diceLocationGuards';
import { transferDice } from '@helpers/diceTransferHandler';
import { playerCharacterStore } from '@stores/CharacterStore';

type DiceButtonProps = {
	dice: Dice;
	class?: string;
	onNameChange?: (diceID: string, newName: string) => void;
}

export const DiceButton: Component<DiceButtonProps> = (props) => {
	const [name, setName] = createSignal(props.dice.name);
	const [location, setLocation] = createSignal(props.dice.location);

	const actionProbabilities = getActionProbabilities(props.dice).sort((a, b) => parseFloat(b.probability) - parseFloat(a.probability));
	const actionList = getActionList(props.dice);

	const diceIcon = getDiceIcon(props.dice.sides);
	const diceColors = getDiceColors(props.dice);

	const diceBackground = (() => {
		if (diceColors.length === 1) {
			return `background-color: ${diceColors[0].bgColor}; color: ${diceColors[0].textColor};`;
		} else if (diceColors.length === 2) {
			return `background: linear-gradient(45deg, ${diceColors[0].bgColor} 50%, ${diceColors[1].bgColor} 50%); color: ${diceColors[0].textColor};`;
		} else {
			const gradientColors = diceColors.map(color => color.bgColor).join(', ');
			return `background: linear-gradient(45deg, ${gradientColors}); color: ${diceColors[0].textColor};`;
		}
	})();

	const handleNameChange = (event: Event) => {
		const newName = (event.target as HTMLInputElement).value;
		setName(newName);

		if (diceStore.getDiceByID(props.dice.id)) {
			diceStore.updateDiceName(props.dice.id, newName);
		}

		if (props.onNameChange) {
			props.onNameChange(props.dice.id, newName);
		}
	};

	const handleLocationChange = (event: Event) => {
		const newLocation = (event.target as HTMLSelectElement).value as DiceLocation;
		setLocation(newLocation);

		if (isValidLocation(newLocation)) {
			transferDice(props.dice.id, props.dice.location, newLocation);
			setLocation(newLocation);
		}
	};

	return (
		<Popover>
			<Tooltip>
				<TooltipTrigger>
					<PopoverTrigger
						as={(triggerProps: PopoverTriggerProps) => (
							<Button {...triggerProps}
								style={diceBackground}
								class={cn(`flex w-8 h-8 p-1 rounded-full overflow-visible items-center justify-center`)}>
								{<div class='w-6 h-6'>{diceIcon}</div>}
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
							{props.dice.location !== null && (
								<div>
									<label for="location-select">Transfer to:</label>
									<select id="location-select" value={location() as string} onChange={handleLocationChange}>
										<option value="inventory" disabled={location() === 'inventory'}>Inventory</option>
										{playerCharacterStore.getAllCharacterIds().map(characterId => (
											<option value={characterId} disabled={location() === characterId}>
												{playerCharacterStore.getCharacterById(characterId).name}
											</option>
										))}
									</select>
								</div>
							)}
							<div>
								<h5 class='font-medium'>Probabilidade:</h5>
								<ul>
									{actionProbabilities.map(({ name, probability }) => (
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
									{actionList.map((actionName, index) => (
										<li>{index} - {actionName}</li>
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