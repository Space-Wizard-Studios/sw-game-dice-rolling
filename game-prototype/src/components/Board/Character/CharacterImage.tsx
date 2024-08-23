import type { Component } from 'solid-js';
import { cn } from '@helpers/cn';

type CharacterImageProps = {
    class?: string;
    src: string;
    onClick?: () => void;
}

export const CharacterImage: Component<CharacterImageProps> = (props) => {
    return (
        <div class={cn(`overflow-hidden w-16 h-16`, props.class)}>
            <img src={props.src} class='w-full h-full object-contain rounded-full' />
        </div>
    );
};