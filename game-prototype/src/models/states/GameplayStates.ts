import type { GameState } from "@models/states/States";

export type GameplayStateType =
	| 'gameplayIntroduction'
	| 'gameplayInitialSetup'
	| 'gameplayBattleSetup'
	| 'gameplayBattleTurn'
	| 'gameplayBattleResult';

export const GameplayStates: Record<GameplayStateType, GameState> = {
	gameplayIntroduction: {
		name: "Introdução",
		icon: "gameplayPresentation-icon",
		bg: "gameplayPresentation-bg",
		iconBg: "gameplayPresentation-icon-bg"
	},
	gameplayInitialSetup: {
		name: "Início do Jogo",
		icon: "gameplayPreparation-icon",
		bg: "gameplayPreparation-bg",
		iconBg: "gameplayPreparation-icon-bg"
	},
	gameplayBattleSetup: {
		name: "Preparação para Batalha",
		icon: "battle-setup-icon",
		bg: "battle-setup-bg",
		iconBg: "battle-setup-icon-bg"
	},
	gameplayBattleTurn: {
		name: "Turno da Batalha",
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
