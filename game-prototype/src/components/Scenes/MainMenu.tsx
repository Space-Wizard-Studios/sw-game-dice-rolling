import { startGameplay } from "@controllers/Gameplay/GameplayController";
import { updateGameSceneState } from "@helpers/updateGameState";

export const MainMenuScene = () => {
    console.log('Rendering MainMenuScene...');

    return (
        <section class='flex h-full w-full items-center justify-center'>
            <button onClick={startGameplay}>Start</button>
        </section>
    );
};