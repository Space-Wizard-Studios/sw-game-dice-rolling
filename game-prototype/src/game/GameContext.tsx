import { createContext, useContext } from 'solid-js';
import type { Component, ParentProps } from 'solid-js';
import { createStore } from 'solid-js/store';

import { GamePhases } from '~types/GamePhases';
import type { GamePhase } from '~types/GamePhases';

export type GameManager = {
    currentPhase: GamePhase;
};

export const [gameState, setGameState] = createStore<GameManager>({
    currentPhase: GamePhases.Presentation,
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