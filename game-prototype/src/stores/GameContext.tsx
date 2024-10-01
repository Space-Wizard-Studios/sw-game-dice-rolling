import { createContext, useContext } from "solid-js";
import type { Component, ParentProps } from 'solid-js';
import { createStore } from "solid-js/store";

import type { GameSceneType } from '@models/scenes/Scenes';
import type { SceneStateType } from '@models/states/States';

export type GameStatusType = 'paused' | 'running';
export type UserActionType = 'continue' | 'rollDice';


export type GameManager = {
	currentSceneState: {
		scene: GameSceneType;
		state: SceneStateType;
	};
	status: GameStatusType;
	requiredAction?: UserActionType;
};

export const [gameState, setGameState] = createStore<GameManager>({
	currentSceneState: {
		scene: "mainMenuScene",
		state: "mainMenuPlaceholder",
	},
	status: 'running',
});

export function waitUserAction(action: UserActionType): Promise<void> {
	setGameState('status', 'paused');
	setGameState('requiredAction', action);
	return resumeOnAction();
}

export function resumeOnAction(): Promise<void> {
	return new Promise<void>((resolve) => {
		const interval = setInterval(() => {
			if (gameState.status === 'running') {
				clearInterval(interval);
				setGameState('requiredAction', undefined);
				resolve();
			}
		}, 100);
	});
}

const GameContext = createContext<[GameManager, typeof setGameState]>([gameState, setGameState]);

export const GameProvider: Component<ParentProps> = (props) => {
	return (
		<GameContext.Provider value={[gameState, setGameState]}>
			{props.children}
		</GameContext.Provider>
	);
};

export function useGameManager(): [GameManager, typeof setGameState] {
	return useContext(GameContext);
}