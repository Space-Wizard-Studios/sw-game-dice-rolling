import type { Component } from 'solid-js';
import type { Health } from ./types/Characters';

type CharacterHealthProps = {
    class?: string;
    health: Health;
    onClick?: () => void;
}

export const CharacterHealth: Component<CharacterHealthProps> = (props) => {
    return (
        <p class='text-sm'>
            Health: <span class='font-semibold'>{props.health.current ?? props.health.max}</span>/<span>{props.health.max}</span>
        </p>
    );
};