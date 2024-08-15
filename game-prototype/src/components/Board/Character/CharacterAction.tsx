import type { Component } from 'solid-js';

export const CharacterAction: Component = () => {
    return (
        <p class='text-sm'>
            Action: <span class='font-semibold'>X</span> on <span class='font-semibold'>Y</span>
        </p>
    );
};