import { GameplayStates } from '@models/states/GameplayStates';
import type { GameStateType } from '@models/states/States';

export const getGameStateName = (stateType: GameStateType) => {
    return GameplayStates[stateType as keyof typeof GameplayStates]?.name;
};

export const getGameStateIcon = (stateType: GameStateType) => {
    return GameplayStates[stateType as keyof typeof GameplayStates]?.icon;
}

export const getGameStateBg = (stateType: GameStateType) => {
    return GameplayStates[stateType as keyof typeof GameplayStates]?.bg;
}

export const getGameStateIconBg = (stateType: GameStateType) => {
    return GameplayStates[stateType as keyof typeof GameplayStates]?.iconBg;
}

export const getGameState = (stateType: GameStateType) => {
    return {
        name: getGameStateName(stateType),
        icon: getGameStateIcon(stateType),
        bg: getGameStateBg(stateType),
        iconBg: getGameStateIconBg(stateType),
    }
}