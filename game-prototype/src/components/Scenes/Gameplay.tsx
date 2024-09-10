import { onMount } from "solid-js";

import { Board } from "@components/Board/Board";
import { Dialogue } from "@components/Dialogue/Dialogue";

import { startGameplay } from "@controllers/Gameplay/GameplayController";

export const GameplayScene = () => {
    console.log('Rendering GameplayScene...');
    
    return (
        <section class='h-full w-full'>
            <div class="flex flex-row w-full h-2/3">
                <Board class="bg-slate-900" />
            </div>
            <div class="relative flex flex-col md:flex-row w-full h-1/3 p-2 gap-2 bg-slate-900">
                <Dialogue />
            </div>
        </section>
    );
};