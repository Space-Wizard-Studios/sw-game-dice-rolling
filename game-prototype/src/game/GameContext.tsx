import { createContext, useContext } from 'solid-js';
import type { Component, ParentProps } from 'solid-js';

import { setGameStateStore, gameStateStore } from '../stores/GameStateStore';
import type { GameState } from '@models/GameStates';
import type { GameScene } from '@models/GameScenes';

export type GameManager = {
  currentScene: GameScene;
  currentState: GameState;
};

const GameContext = createContext<[GameManager, typeof setGameStateStore]>([gameStateStore, setGameStateStore]);

export const GameProvider: Component<ParentProps> = (props) => {
  return (
    <GameContext.Provider value={[gameStateStore, setGameStateStore]}>
      {props.children}
    </GameContext.Provider>
  );
};

export const useGameManager = () => useContext(GameContext);