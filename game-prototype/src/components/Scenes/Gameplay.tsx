import { onMount } from "solid-js";

import { Board } from "@components/Board/Board";
import { Dialogue } from "@components/Dialogue/Dialogue";

import { startGameplay } from "@controllers/Gameplay/GameplayController";

export const GameplayScene = () => {
    console.log('Rendering GameplayScene...');

    return (
        <section class='h-full gap-2 bg-slate-900 text-white'>
            <Board class='h-2/3 gap-2 p-2 w-full overflow-hidden' />
            <Dialogue class='h-1/3 gap-2 p-2 w-full overflow-hidden' />
        </section>
    );
};