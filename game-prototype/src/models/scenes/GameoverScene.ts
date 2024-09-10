import type { GameScene } from "@models/scenes/Scenes";

export type GameoverSceneType = 'gameoverScene';

export const GameoverScenes: Record<GameoverSceneType, GameScene> = {
    gameoverScene: {
        name: "Gameover Placeholder",
        bg: "placeholder-bg",
    },
} as const;