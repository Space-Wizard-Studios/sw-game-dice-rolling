export type GameScene = {
    name: string;
    bg: string;
};

export type GameSceneType = 'gameplay' | 'gameover';

export const GameScenes: Record<GameSceneType, GameScene> = {
    gameplay: {
        name: "Gameplay",
        bg: "preparation-bg",
    },
    gameover: {
        name: "Game Over",
        bg: "gameover-bg",
    },
} as const;

console.log(GameScenes);