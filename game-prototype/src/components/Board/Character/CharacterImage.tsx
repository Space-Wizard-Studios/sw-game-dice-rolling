import type { Component } from 'solid-js';
import { cn } from '@helpers/cn';

type CharacterImageProps = {
    class?: string;
    src: string;
    onClick?: () => void;
}

export const CharacterImage: Component<CharacterImageProps> = (props) => {
    return (
        <div class={cn(`overflow-hidden h-12 md:w-14 md:h-14 rounded-full`, props.class)}>
            <img src={props.src} class='w-full h-full object-cover' />
        </div>
    );
};