import { createStore } from 'solid-js/store';
import { GamePhases } from 'types/GamePhases';

export type GameState = {
    currentPhase: GamePhases;
    // state properties
};

export const [gameState, setGameState] = createStore<GameState>({
    currentPhase: GamePhases.Presentation,
});

export function setGamePhase(phase: GamePhases) {
    setGameState('currentPhase', phase);
}