import { CharacterName } from './CharacterName';
import { CharacterRole } from './CharacterRole';
import { CharacterImage } from './CharacterImage';
import { CharacterHealth } from './CharacterHealth';
import { CharacterDice } from './CharacterDice';
import { CharacterAction } from './CharacterAction';
import { cn } from '@helpers/cn';

import type { Component } from 'solid-js';
import type { Character } from '@models/Characters';
import { getRoleBaseHealth } from '@helpers/getRole';

type CharacterSheetProps = {
	character: Character;
	class?: string;
	onClick?: () => void;
}

export const CharacterSheet: Component<CharacterSheetProps> = (props) => {

	return (
		<div class={cn(
			'flex flex-col md:flex-row w-full items-center p-1 gap-1 rounded-md',
			'bg-blue-100 bg-opacity-25 border-2 border-black border-opacity-50',
			props.class
		)} onClick={props.onClick} >
			<CharacterImage src={props.character.role.image} />
			<div class='flex flex-col w-full p-1'>
				<div class='flex flex-row w-full justify-between'>
					<CharacterName name={props.character.name} />
					<CharacterRole role={props.character.role} />
				</div>
				<CharacterHealth health={props.character.health ?? getRoleBaseHealth(props.character.role)} />
				{props.character.diceSet && <CharacterDice diceSet={props.character.diceSet} />}
				{/* <CharacterAction /> */}
			</div>
		</div>
	);
};