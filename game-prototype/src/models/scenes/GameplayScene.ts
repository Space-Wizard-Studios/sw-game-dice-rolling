import type { GameScene } from "@models/scenes/Scenes";

export type GameplaySceneType = 'gameplayScene';

export const GameplayScenes: Record<GameplaySceneType, GameScene> = {
    gameplayScene: {
        name: "Gameover Placeholder",
        bg: "placeholder-bg",
    },
} as const;