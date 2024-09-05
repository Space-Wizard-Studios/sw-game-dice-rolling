import type { GameState } from "@models/GameStates";

export type MainMenuStateType = 'mainMenuPlaceholder';

export const MainMenuStates: Record<MainMenuStateType, GameState> = {
    mainMenuPlaceholder: {
        name: "Placeholder",
        icon: "placeholder-icon",
        bg: "placeholder-bg",
        iconBg: "placeholder-icon-bg"
    },
} as const;
