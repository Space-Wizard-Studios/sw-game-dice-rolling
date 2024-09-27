import { CharacterName } from '@components/Character/CharacterName';
import { CharacterRole } from '@components/Character/CharacterRole';
import { CharacterImage } from '@components/Character/CharacterImage';
import { CharacterHealth } from '@components/Character/CharacterHealth';
import { cn } from '@helpers/cn';

import type { Component } from 'solid-js';
import type { Character } from '@models/Character';
import { getRoleBaseHealth } from '@helpers/getRole';
import { CharacterDiceSet } from '@components/Character/CharacterDiceSet';

type CharacterSheetProps = {
	character: Character;
	class?: string;
}

export const CharacterSheet: Component<CharacterSheetProps> = (props) => {
	const diceSlots = Array.from({ length: props.character.diceCapacity });
	return (
		<div class={cn(
			'flex flex-col md:flex-row w-full items-center rounded-md',
			'bg-blue-100 bg-opacity-25 border-2 border-black border-opacity-50',
			props.class
		)}>
			<CharacterImage src={props.character.role.image} />
			<div class='flex flex-col w-full p-1'>
				<div class='flex flex-row w-full justify-between'>
					<CharacterName name={props.character.name} />
					<CharacterRole role={props.character.role} />
				</div>
				<CharacterHealth health={props.character.health ?? getRoleBaseHealth(props.character.role)} />
				<div class='flex flex-row gap-2'>
					{diceSlots.map((_, index) => (
						<div class='w-10 h-10 border-2 rounded-lg border-dashed border-gray-400 flex items-center justify-center'>
							{props.character.diceIds && props.character.diceIds[index] && (
								<CharacterDiceSet diceIds={[props.character.diceIds[index]]} />
							)}
						</div>
					))}
				</div>
				{/* <CharacterAction /> */}
			</div>
		</div>
	);
};