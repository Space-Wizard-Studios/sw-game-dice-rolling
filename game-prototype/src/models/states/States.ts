import type { GameplayStateType } from "./GameplayStates";
import type { GameoverStateType } from "./GameoverStates";
import type { MainMenuStateType } from "./MainMenuStates";

import { GameoverStates } from "./GameoverStates";
import { MainMenuStates } from "./MainMenuStates";
import { GameplayStates } from "./GameplayStates";

export type GameStateType = GameplayStateType | GameoverStateType | MainMenuStateType;

export type GameState = {
	name: string;
	icon: string;
	bg: string;
	iconBg: string;
};

export const GameStates: Record<GameStateType, GameState> = {
	...GameplayStates,
	...GameoverStates,
	...MainMenuStates,
} as const;