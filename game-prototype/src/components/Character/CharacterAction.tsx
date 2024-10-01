import type { Component } from 'solid-js';

type CharacterActionProps = {
	class?: string;
	onClick?: () => void;
}

export const CharacterAction: Component<CharacterActionProps> = () => {
	return (
		<div class='flex flex-row flex-1 h-10 gap-2 items-center justify-center'>
			<div class='h-full px-1 border-2 rounded-lg border-dashed border-gray-400 flex items-center justify-center'>
				ACTION
			</div>
			<div class='h-full px-1 border-2 rounded-lg border-dashed border-gray-400 flex items-center justify-center'>
				TARGET
			</div>
			{/* Action: <span class='font-semibold'>X</span> on <span class='font-semibold'>Y</span> */}
		</div>
	);
};