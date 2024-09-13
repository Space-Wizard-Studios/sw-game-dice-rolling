import type { Component } from "solid-js";

import { getGameStateName } from "@helpers/getGameState";
import { Line } from "./Line";

import type { DialogueMessage } from '@stores/Dialogue';

export const Message: Component<{ message?: DialogueMessage }> = (props) => {

	return (
		<div class='p-1 rounded-md bg-gray-500 bg-opacity-50'>
			<div>
				{props.message?.gameState && <h3>{getGameStateName(props.message.gameState)}</h3>}
			</div>
			<div class={`rounded-lg overflow-hidden`}>
				{props.message?.lines.map(line => (
					<Line line={line} />
				))}
			</div>
		</div>
	);
};
