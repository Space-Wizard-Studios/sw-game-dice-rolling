import type { Component } from "solid-js";

import { Line } from "./Line";

import type { DialogueMessage } from '@stores/DialogueStore';

export const Message: Component<{ message?: DialogueMessage }> = (props) => {
    return (
        <div class='p-2 rounded-md bg-gray-500 bg-opacity-50'>
            <div>
                <h3>{props.message?.phase?.name}</h3>
            </div>
            <div class={`rounded-lg overflow-hidden`}>
                {props.message?.lines.map(line => (
                    <Line line={line} />
                ))}
            </div>
        </div>
    );
};
