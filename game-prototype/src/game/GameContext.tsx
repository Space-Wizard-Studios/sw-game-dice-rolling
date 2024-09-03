import { createContext, useContext } from 'solid-js';
import type { Component, ParentProps } from 'solid-js';
import { createStore } from 'solid-js/store';

import { GamePhases } from '@models/GamePhases';
import type { GamePhase } from '@models/GamePhases';

export type GameManager = {
    currentPhase: GamePhase;
};

export const [gameState, setGameState] = createStore<GameManager>({
    currentPhase: GamePhases.presentation,
});

const GameContext = createContext<[GameManager, typeof setGameState]>([gameState, setGameState]);

export const GameProvider: Component<ParentProps> = (props) => {
    return (
        <GameContext.Provider value={[gameState, setGameState]}>
            {props.children}
        </GameContext.Provider>
    );
};

export const useGameManager = () => useContext(GameContext);