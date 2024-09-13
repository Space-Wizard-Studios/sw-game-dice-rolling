import type { Component } from "solid-js";
import type { DialogueLine } from "@stores/Dialogue";

export const Line: Component<{ line?: DialogueLine }> = (props) => {
	let bg = '';
	switch (props.line?.type) {
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

	return (
		<p class={`p-1 ${bg} bg-opacity-50`}>
			{props.line?.text}
		</p>
	);
};
