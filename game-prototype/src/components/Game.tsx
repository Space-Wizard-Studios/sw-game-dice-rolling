import type { JSX } from "solid-js";
import { GameProvider } from "@stores/GameContext";
import { SceneRenderer } from "@components/SceneRenderer";
import { TestRenderer } from "./TestRenderer";

interface GameProps {
	test?: boolean;
}

export const Game = ({ test = false }: GameProps): JSX.Element => (
	<GameProvider>
		{test ? <TestRenderer /> : <SceneRenderer />}
	</GameProvider>
);