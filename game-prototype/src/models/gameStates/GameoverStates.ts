import type { GameState } from "@models/GameStates";

export type GameoverStateType = 'gameoverPlaceholder';

export const GameoverStates: Record<GameoverStateType, GameState> = {
    gameoverPlaceholder: {
        name: "Gameover Placeholder",
        icon: "placeholder-icon",
        bg: "placeholder-bg",
        iconBg: "placeholder-icon-bg"
    },
} as const;
