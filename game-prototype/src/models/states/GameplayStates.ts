import type { GameState } from "@models/states/States";

export type GameplayStateType =
	| 'gameplayPresentation'
	| 'gameplayPreparation'
	| 'gameplaySetup'
	| 'gameplayBattle'
	| 'gameplayBattleResult';

export const GameplayStates: Record<GameplayStateType, GameState> = {
	gameplayPresentation: {
		name: "Apresentação",
		icon: "gameplayPresentation-icon",
		bg: "gameplayPresentation-bg",
		iconBg: "gameplayPresentation-icon-bg"
	},
	gameplayPreparation: {
		name: "Preparação",
		icon: "gameplayPreparation-icon",
		bg: "gameplayPreparation-bg",
		iconBg: "gameplayPreparation-icon-bg"
	},
	gameplaySetup: {
		name: "Preparação para Batalha",
		icon: "battle-setup-icon",
		bg: "battle-setup-bg",
		iconBg: "battle-setup-icon-bg"
	},
	gameplayBattle: {
		name: "Início da Batalha",
		icon: "battle-start-icon",
		bg: "battle-start-bg",
		iconBg: "battle-start-icon-bg",
	},
	gameplayBattleResult: {
		name: "Fim da Batalha",
		icon: "battle-end-icon",
		bg: "battle-end-bg",
		iconBg: "battle-end-icon-bg",
	}
} as const;
