import type { Component } from 'solid-js';
import type { Health } from '@models/Characters';

type CharacterHealthProps = {
	class?: string;
	health: Health;
	onClick?: () => void;
}

export const CharacterHealth: Component<CharacterHealthProps> = (props) => {
	return (
		<div class='flex flex-row text-sm w-full gap-4 justify-between'>
			<p>Health:</p>
			<p class='font-semibold'>{props.health.current}/{props.health.max}</p>
		</div>
	);
};