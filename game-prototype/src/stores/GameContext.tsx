import { createContext, useContext } from "solid-js";
import type { Component, ParentProps } from 'solid-js';
import { createStore } from "solid-js/store";

import type { GameSceneType } from '@models/scenes/Scenes';
import type { GameStateType } from '@models/states/States';

export type GameManager = {
  currentScene: GameSceneType;
  currentState: GameStateType;
};

export const [gameState, setGameState] = createStore<GameManager>({
  currentScene: "mainMenuScene",
  currentState: "mainMenuPlaceholder",
});

const GameContext = createContext<[GameManager, typeof setGameState]>([gameState, setGameState]);

export const GameProvider: Component<ParentProps> = (props) => {
  console.log('GameProvider mounted');

  return (
    <GameContext.Provider value={[gameState, setGameState]}>
      {props.children}
    </GameContext.Provider>
  );
};

export function useGameManager() {
  return useContext(GameContext);
}