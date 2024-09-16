import type { GameState } from "@models/states/States";

export type GameoverStateType = 'gameoverPlaceholder';

export const GameoverStates: Record<GameoverStateType, GameState> = {
	gameoverPlaceholder: {
		name: "Gameover Placeholder",
		icon: "placeholder-icon",
		bg: "placeholder-bg",
		iconBg: "placeholder-icon-bg"
	},
} as const;
