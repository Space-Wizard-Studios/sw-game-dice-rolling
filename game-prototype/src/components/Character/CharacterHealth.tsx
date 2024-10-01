import type { Component } from 'solid-js';
import type { Health } from '@models/Character';

type CharacterHealthProps = {
	class?: string;
	health: Health;
}

export const CharacterHealth: Component<CharacterHealthProps> = (props) => {
	return (
		<div class='flex flex-row text-sm w-full gap-4 justify-between'>
			<p class='font-semibold'>{props.health.current}/{props.health.max}</p>
		</div>
	);
};