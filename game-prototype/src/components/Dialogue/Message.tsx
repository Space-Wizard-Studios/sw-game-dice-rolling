import { createSignal } from "solid-js";
import type { Component } from "solid-js";

import { getGameStateName } from "@helpers/getGameState";
import { Line } from "@components/Dialogue/Line";

import { setDialogueStore, dialogueStore } from '@stores/DialogueStore';
import type { DialogueMessage } from '@stores/DialogueStore';

import { Button } from "@components/ui/button";

export const Message: Component<DialogueMessage> = (props) => {
	const [isContinued, setIsContinued] = createSignal(false);

	const handleContinue = () => {
		setIsContinued(true);
		const messageIndex = dialogueStore.messages.indexOf(props);
		setDialogueStore('messages', messageIndex, 'requiresUserAction', false);
	};

	return (
		<div class='flex flex-col p-1 rounded-md bg-gray-500 bg-opacity-50'>
			<div>
				{props.gameState && <h3 class='font-semibold pb-1'>{getGameStateName(props.gameState)}</h3>}
			</div>
			<div class="flex flex-row gap-2 items-center justify-center">
				<div class={`w-full rounded-lg overflow-hidden`}>
					{props.lines.map(line => (<Line {...line} />))}
				</div>
				{props.requiresUserAction && !isContinued() && (
					<Button onClick={handleContinue} class="">
						{props.buttonText || 'Continuar'}
					</Button>
				)}
			</div>
		</div>
	);
};