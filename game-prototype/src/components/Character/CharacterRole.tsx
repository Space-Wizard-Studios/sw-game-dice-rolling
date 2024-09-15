import type { Role } from '@models/Role';
import type { Component } from 'solid-js';

type CharacterNameProps = {
	role: Role;
	class?: string;
	onClick?: () => void;
}

export const CharacterRole: Component<CharacterNameProps> = (props) => {
	return (
		<p class='text-sm'>{
			props.role.name
		}</p>
	);
};