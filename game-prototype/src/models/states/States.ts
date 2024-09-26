import type { GameplayStateType } from "@models/states/GameplayStates";
import type { GameoverStateType } from "@models/states/GameoverStates";
import type { MainMenuStateType } from "@models/states/MainMenuStates";

import { GameoverStates } from "@models/states/GameoverStates";
import { MainMenuStates } from "@models/states/MainMenuStates";
import { GameplayStates } from "@models/states/GameplayStates";

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