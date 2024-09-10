import type { GameState } from "@models/states/States";

export type GameplayStateType =
    | 'gameplayPresentation'
    | 'gameplayPreparation'
    | 'gameplaySetup'
    | 'gameplayBattle'
    | 'gameplayBattleResult';

export const GameplayStates: Record<GameplayStateType, GameState> = {
    gameplayPresentation: {
        name: "GameplayPresentation",
        icon: "gameplayPresentation-icon",
        bg: "gameplayPresentation-bg",
        iconBg: "gameplayPresentation-icon-bg"
    },
    gameplayPreparation: {
        name: "GameplayPreparation",
        icon: "gameplayPreparation-icon",
        bg: "gameplayPreparation-bg",
        iconBg: "gameplayPreparation-icon-bg"
    },
    gameplaySetup: {
        name: "Battle Setup",
        icon: "battle-setup-icon",
        bg: "battle-setup-bg",
        iconBg: "battle-setup-icon-bg"
    },
    gameplayBattle: {
        name: "Battle Start",
        icon: "battle-start-icon",
        bg: "battle-start-bg",
        iconBg: "battle-start-icon-bg",
    },
    gameplayBattleResult: {
        name: "Battle End",
        icon: "battle-end-icon",
        bg: "battle-end-bg",
        iconBg: "battle-end-icon-bg",
    }
} as const;
