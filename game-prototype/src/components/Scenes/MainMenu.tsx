import { startGameplay } from "@controllers/Gameplay/GameplayController";
import { updateGameSceneState } from "@helpers/updateGameState";

export const MainMenuScene = () => {
    console.log('Rendering MainMenuScene...');

    return (
        <section class='h-full w-full'>
            <button onClick={startGameplay}>Start</button>
        </section>
    );
};