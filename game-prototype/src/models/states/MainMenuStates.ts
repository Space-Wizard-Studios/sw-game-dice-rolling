import type { SceneState } from "@models/states/States";

export type MainMenuStateType = 'mainMenuPlaceholder';

export const MainMenuStates: Record<MainMenuStateType, SceneState> = {
	mainMenuPlaceholder: {
		name: "Placeholder",
		icon: "placeholder-icon",
		bg: "placeholder-bg",
		iconBg: "placeholder-icon-bg"
	},
} as const;
