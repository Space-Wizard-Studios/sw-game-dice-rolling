import type { Component } from "solid-js";
import { getGameStateName } from "@helpers/getGameState";
import { Line } from "@components/Chat/Line";
import type { ChatMessage } from '@stores/ChatStore';

export const Message: Component<ChatMessage> = (props) => {
	return (
		<div class='flex flex-col p-1 rounded-md bg-gray-700'>
			<div>
				{props.gameState && <h3 class='font-semibold pb-1'>{getGameStateName(props.gameState)}</h3>}
			</div>
			<div class="flex flex-row gap-2 items-center justify-center">
				<div class={`w-full rounded-lg overflow-hidden`}>
					{props.lines.map(line => (<Line {...line} />))}
				</div>
			</div>
		</div>
	);
};