import { CharacterName } from '@components/Character/CharacterName';
import { CharacterRole } from '@components/Character/CharacterRole';
import { CharacterImage } from '@components/Character/CharacterImage';
import { CharacterHealth } from '@components/Character/CharacterHealth';
import { cn } from '@helpers/cn';

import type { Component } from 'solid-js';
import type { Character } from '@models/Character';
import { getRoleBaseHealth } from '@helpers/getRole';
import { CharacterDiceSet } from '@components/Character/CharacterDiceSet';
import { CharacterAction } from '@components/Character/CharacterAction';

type CharacterSheetProps = {
	character: Character;
	class?: string;
	invertedRow?: boolean;
}

export const CharacterSheet: Component<CharacterSheetProps> = (props) => {
	const diceSlots = Array.from({ length: props.character.diceCapacity });
	const invertedRow = props.invertedRow ?? false;
	return (
		<div class={cn(
			`${invertedRow ? 'flex-col-reverse md:flex-row-reverse' : 'flex-col md:flex-row'}`,
			'flex p-1 gap-1 rounded-md items-center',
			'bg-blue-100 bg-opacity-25 border-2 border-black border-opacity-50',
			props.class
		)}>
			<div class={cn(
				`flex flex-col gap-2 w-full justify-center`,
				`${invertedRow ? 'md:justify-end items-end' : 'md:justify-start'}`,
			)}>
				<CharacterImage src={props.character.role.image} />
				<div class='flex flex-col justify-center'>
					<CharacterName name={props.character.name} />
					<CharacterRole role={props.character.role} />
					<CharacterHealth health={props.character.health ?? getRoleBaseHealth(props.character.role)} />
				</div>
			</div>
			<div class={cn(
				`flex flex-col gap-2 w-full justify-center`,
				`${invertedRow ? 'md:justify-end' : 'md:justify-start'}`,
			)}>
				<div class='flex flex-row flex-wrap gap-1 items-center justify-center'>
					{diceSlots.map((_, index) => (
						<div class='h-10 w-10 border-2 rounded-lg border-dashed border-gray-400 flex items-center justify-center'>
							{props.character.diceIds && props.character.diceIds[index] && (
								<CharacterDiceSet diceIds={[props.character.diceIds[index]]} />
							)}
						</div>
					))}
				</div>
			</div>
			<CharacterAction />
		</div>
	);
};