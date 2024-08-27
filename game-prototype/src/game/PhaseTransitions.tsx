import { useGameManager } from '@game/GameContext';

import { Presentation } from '@game/phases/Presentation';
import { Preparation } from '@game/phases/Preparation';
import { BattleSetup } from '@game/phases/BattleSetup';
import { BattleStart } from '@game/phases/BattleStart';
import { BattleEnd } from '@game/phases/BattleEnd';

import { GamePhases } from '../types/GamePhases';
import type { GamePhase } from '../types/GamePhases';

export function setGamePhase(phase: GamePhase) {
    const [, setGameState] = useGameManager();
    setGameState('currentPhase', phase);
}

export async function startGame() {
    setGamePhase(GamePhases.Presentation);
    await Presentation();
    await transitionToPreparation();
}

export async function transitionToPreparation() {
    setGamePhase(GamePhases.Preparation);
    await Preparation();
    await transitionToBattleSetup();
}

export async function transitionToBattleSetup() {
    setGamePhase(GamePhases.BattleSetup);
    await BattleSetup();
    await transitionToBattleStart();
}

export async function transitionToBattleStart() {
    setGamePhase(GamePhases.BattleStart);
    await BattleStart();
    await transitionToBattleEnd();
}

export async function transitionToBattleEnd() {
    setGamePhase(GamePhases.BattleEnd);
    await BattleEnd();
    // TODO Decide next phase or end game
}