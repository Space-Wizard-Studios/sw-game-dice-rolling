import { GameProvider } from "@stores/GameContext";
import { SceneRenderer } from "@components/SceneRenderer";

export const Game = () => (
	<GameProvider>
		<SceneRenderer />
	</GameProvider>
);