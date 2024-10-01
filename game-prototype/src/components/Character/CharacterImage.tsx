import type { Component } from 'solid-js';
import { cn } from '@helpers/cn';

type CharacterImageProps = {
	class?: string;
	src: string;
}

export const CharacterImage: Component<CharacterImageProps> = (props) => {
	return (
		<div class={cn(`p-2 flex h-14 w-14 items-center justify-center object-cover overflow-hidden`, props.class)}>
			<img src={props.src} class='rounded-full' />
		</div>
	);
};