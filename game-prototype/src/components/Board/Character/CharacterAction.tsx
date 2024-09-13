import type { Component } from 'solid-js';

type CharacterActionProps = {
	class?: string;
	onClick?: () => void;
}

export const CharacterAction: Component<CharacterActionProps> = () => {
	return (
		<p class='text-sm'>
			Action: <span class='font-semibold'>X</span> on <span class='font-semibold'>Y</span>
		</p>
	);
};