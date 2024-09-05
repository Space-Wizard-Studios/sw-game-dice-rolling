import type { GameplayStateType } from '@models/gameStates/GameplayStates';
import type { GameoverStateType } from '@models/gameStates/GameoverStates';

import { GameplayStates } from '@models/gameStates/GameplayStates';
import { GameoverStates } from '@models/gameStates/GameoverStates';

export type GameScene = {
    name: string;
    bg: string;
    allowedStates: string[];
};

export type GameSceneType = 'gameplay' | 'gameover';

export const GameScenes: Record<GameSceneType, GameScene> = {
    gameplay: {
        name: "Gameplay",
        bg: "preparation-bg",
        allowedStates: Object.keys(GameplayStates),
    },
    gameover: {
        name: "Game Over",
        bg: "gameover-bg",
        allowedStates: Object.keys(GameoverStates),
    },
} as const;