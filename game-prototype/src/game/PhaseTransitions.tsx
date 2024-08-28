import { useGameManager } from '@game/GameContext';

import { Presentation } from '@game/phases/Presentation';
import { Preparation } from '@game/phases/Preparation';
import { BattleSetup } from '@game/phases/BattleSetup';
import { BattleStart } from '@game/phases/BattleStart';
import { BattleEnd } from '@game/phases/BattleEnd';

import { GamePhases } from ./types/GamePhases';
import type { GamePhase } from ./types/GamePhases';

export function setGamePhase(phase: GamePhase) {
    const [, setGameState] = useGameManager();
    setGameState('currentPhase', phase);
}

export async function startGame() {
    console.log('Starting game...');
    setGamePhase(GamePhases.Presentation);
    await Presentation();
    await transitionToPreparation();
}

export async function transitionToPreparation() {
    console.log('Transitioning to preparation phase...');
    setGamePhase(GamePhases.Preparation);
    await Preparation();
    await transitionToBattleSetup();
}

export async function transitionToBattleSetup() {
    console.log('Transitioning to battle setup phase...');
    setGamePhase(GamePhases.BattleSetup);
    await BattleSetup();
    await transitionToBattleStart();
}

export async function transitionToBattleStart() {
    console.log('Transitioning to battle start phase...');
    setGamePhase(GamePhases.BattleStart);
    await BattleStart();
    await transitionToBattleEnd();
}

export async function transitionToBattleEnd() {
    console.log('Transitioning to battle end phase...');
    setGamePhase(GamePhases.BattleEnd);
    await BattleEnd();
    // TODO Decide next phase or end game
}