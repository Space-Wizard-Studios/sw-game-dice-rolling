import type { GameState } from "@models/GameStates";

export type GameoverStateType = 'gameOverPlaceholder';

export const GameoverStates: Record<GameoverStateType, GameState> = {
    gameOverPlaceholder: {
        name: "Gameover Placeholder",
        icon: "placeholder-icon",
        bg: "placeholder-bg",
        iconBg: "placeholder-icon-bg"
    },
} as const;
