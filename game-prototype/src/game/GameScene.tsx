import { onMount } from "solid-js";

import { Board } from "@components/Board/Board";
import { Dialogue } from "@components/Dialogue/Dialogue";
import { InteractivePanel } from "@components/InteractivePanel/Input";

import { startGameplay } from "@game/scenes/Gameplay/GameplayTransitions";
import { GameProvider } from "@game/GameContext";

const GameScreen = () => {
    onMount(() => {
        startGameplay();
    });

    return (
        <GameProvider>
            <main class="relative h-dvh w-dvh text-white">
                <div class="flex flex-row w-full h-2/3">
                    <Board class="bg-slate-900" />
                </div>
                <div class="relative flex flex-col md:flex-row w-full h-1/3 p-2 gap-2 bg-slate-900">
                    <Dialogue />
                    <InteractivePanel />
                </div>
            </main>
        </GameProvider>
    );
};

export default GameScreen;