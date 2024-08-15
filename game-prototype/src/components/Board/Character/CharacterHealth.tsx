import type { Component } from 'solid-js';
import type { Health } from 'types/Characters';

export const CharacterHealth: Component<{ health: Health }> = (props) => {
    return (
        <p class='text-sm'>
            Health: <span class='font-semibold'>{props.health.current ?? props.health.max}</span>/<span>{props.health.max}</span>
        </p>
    );
};