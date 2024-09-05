import type { GameState } from "@models/GameStates";

export type GameplayStateType = 'presentation' | 'preparation' | 'battleSetup' | 'battleStart' | 'battleEnd';

export const GameplayStates: Record<GameplayStateType, GameState> = {
    presentation: {
        name: "Presentation",
        icon: "presentation-icon",
        bg: "presentation-bg",
        iconBg: "presentation-icon-bg"
    },
    preparation: {
        name: "Preparation",
        icon: "preparation-icon",
        bg: "preparation-bg",
        iconBg: "preparation-icon-bg"
    },
    battleSetup: {
        name: "Battle Setup",
        icon: "battle-setup-icon",
        bg: "battle-setup-bg",
        iconBg: "battle-setup-icon-bg"
    },
    battleStart: {
        name: "Battle Start",
        icon: "battle-start-icon",
        bg: "battle-start-bg",
        iconBg: "battle-start-icon-bg",
    },
    battleEnd: {
        name: "Battle End",
        icon: "battle-end-icon",
        bg: "battle-end-bg",
        iconBg: "battle-end-icon-bg",
    }
} as const;
