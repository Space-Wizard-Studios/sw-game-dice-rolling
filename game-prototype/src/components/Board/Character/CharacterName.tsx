import type { Component } from 'solid-js';

type CharacterNameProps = {
	name: string;
	class?: string;
	onClick?: () => void;
}

export const CharacterName: Component<CharacterNameProps> = (props) => {
	return (
		<p class='text-sm'>{props.name}</p>
	);
};