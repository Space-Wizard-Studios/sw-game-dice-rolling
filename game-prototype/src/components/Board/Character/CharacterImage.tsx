import type { Component } from 'solid-js';

export const CharacterImage: Component<{ src: string }> = (props) => {
    return (
        <div class='overflow-hidden w-16 h-16'>
            <img src={props.src} class='w-full h-full object-contain' />
        </div>
    );
};