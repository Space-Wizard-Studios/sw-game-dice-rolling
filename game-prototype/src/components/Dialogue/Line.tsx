import type { Component } from "solid-js";
import type { DialogueLine } from "@stores/DialogueStore";

export const Line: Component<DialogueLine> = (props) => {
	let bg;
	let text;
	let border;
	let margin;
	switch (props.type) {
		case 'info':
			bg = 'bg-blue-400';
			text= 'text-blue-900 font-bold';
			break;
		case 'failure':
			bg = 'bg-red-500';
			text = 'text-red-900 font-bold';
			break;
		case 'success':
			bg = 'bg-green-500';
			text = 'text-green-900 font-bold';
			break;
		case 'warning':
			bg = 'bg-yellow-500';
			text = 'text-yellow-900 font-bold';
			break;
		case 'wip':
			margin = 'my-1';
			bg = 'bg-gray-500';
			text = 'text-gray-900 font-bold';
			border = 'border-2 rounded-lg border-dashed border-gray-400';
			break;
		default:
			bg = 'bg-gray-800';
			text = 'text-gray-200';
			break;
	}

	let alignment;
	switch (props.align) {
		case 'left':
			alignment = 'justify-start';
			break;
		case 'center':
			alignment = 'justify-center';
			break;
		case 'right':
			alignment = 'justify-end';
			break;
		default:
			alignment = 'justify-start';
			break;
	}

	return (
		<p class={`flex flex-row ${margin} ${alignment} p-1 ${text} ${border} ${bg}`}>
			{props.text}
		</p>
	);
};
