import type { JSX } from "solid-js";
import { GameProvider } from "@stores/GameContext";
import { SceneRenderer } from "@components/SceneRenderer";
import { TestRenderer } from "@components/TestRenderer";

type GameProps = {
	test?: boolean;
}

export const Game = (props:GameProps): JSX.Element => (
	<GameProvider>
		{props.test ? <TestRenderer /> : <SceneRenderer />}
	</GameProvider>
);