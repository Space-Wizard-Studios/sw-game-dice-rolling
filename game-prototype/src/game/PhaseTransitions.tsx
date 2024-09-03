import { useGameManager } from '@game/GameContext';

import { Presentation } from '@game/phases/Presentation';
import { Preparation } from '@game/phases/Preparation';
import { BattleSetup } from '@game/phases/BattleSetup';
import { BattleStart } from '@game/phases/BattleStart';
import { BattleEnd } from '@game/phases/BattleEnd';

import { GamePhases } from '@models/GamePhases';
import type { GamePhase } from '@models/GamePhases';

export function setGamePhase(phase: GamePhase) {
    const [, setGameState] = useGameManager();
    setGameState('currentPhase', phase);
}

export async function startGame() {
    console.log('Starting game...');
    setGamePhase(GamePhases.presentation);
    await Presentation();
    await transitionToPreparation();
}

export async function transitionToPreparation() {
    console.log('Transitioning to preparation phase...');
    setGamePhase(GamePhases.preparation);
    await Preparation();
    await transitionToBattleSetup();
}

export async function transitionToBattleSetup() {
    console.log('Transitioning to battle setup phase...');
    setGamePhase(GamePhases.battleSetup);
    await BattleSetup();
    await transitionToBattleStart();
}

export async function transitionToBattleStart() {
    console.log('Transitioning to battle start phase...');
    setGamePhase(GamePhases.battleStart);
    await BattleStart();
    await transitionToBattleEnd();
}

export async function transitionToBattleEnd() {
    console.log('Transitioning to battle end phase...');
    setGamePhase(GamePhases.battleEnd);
    await BattleEnd();
    // TODO Decide next phase or end game
}