import type { Component } from "solid-js";
import type { DialogueLine } from "@stores/DialogueStore";

export const Line: Component<DialogueLine> = (props) => {
	let bg;
	switch (props.type) {
		case 'info':
			bg = 'bg-blue-500';
			break;
		case 'failure':
			bg = 'bg-red-500';
			break;
		case 'success':
			bg = 'bg-green-500';
			break;
		case 'warning':
			bg = 'bg-yellow-500';
			break;
		default:
			bg = 'bg-gray-500';
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
		<p class={`flex flex-row ${alignment} p-1 ${bg} bg-opacity-50`}>
			{props.text}
		</p>
	);
};
