import { CharacterName } from './CharacterName';
import { CharacterRole } from './CharacterRole';
import { CharacterImage } from './CharacterImage';
import { CharacterHealth } from './CharacterHealth';
import { CharacterDiceSet } from './CharacterDiceSet';
import { CharacterAction } from './CharacterAction';
import { cn } from '@helpers/cn';

import type { Component } from 'solid-js';
import type { Character } from '@models/Character';
import { getRoleBaseHealth } from '@helpers/getRole';

type CharacterSheetProps = {
	character: Character;
	class?: string;
}

export const CharacterSheet: Component<CharacterSheetProps> = (props) => {

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
				{/* {props.character.diceIDs && <CharacterDiceSet diceSet={props.character.diceIDs} />} */}
				{/* <CharacterAction /> */}
			</div>
		</div>
	);
};