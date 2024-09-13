import { onMount } from "solid-js";

import { Board } from "@components/Board/Board";
import { Dialogue } from "@components/Dialogue/Dialogue";

import { startGameplay } from "@controllers/Gameplay/GameplayController";

export const GameplayScene = () => {
    console.log('Rendering GameplayScene...');

    return (
        <section class='flex flex-col h-full p-1 gap-1 bg-slate-900 text-white'>
            <Board class='h-2/3 w-full overflow-hidden' />
            <Dialogue class='h-1/3 w-full overflow-hidden' />
        </section>
    );
};