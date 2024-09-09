import { createContext, useContext } from "solid-js";
import type { Component, ParentProps } from 'solid-js';
import { createStore } from "solid-js/store";

import { GameplayStates } from "@models/gameStates/GameplayStates";
import { GameScenes } from "@models/GameScenes";

import type { GameState } from '@models/GameStates';
import type { GameScene } from '@models/GameScenes';

export type GameManager = {
  currentScene: GameScene;
  currentState: GameState;
};

export const [gameState, setGameState] = createStore<GameManager>({
  currentScene: GameScenes.gameplay,
  currentState: GameplayStates.presentation,
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

export const useGameManager = () => useContext(GameContext);