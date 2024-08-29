export type GamePhase = {
    name: string;
    icon: string;
    bg: string;
    iconBg: string;
};

export const GamePhases: { [key: string]: GamePhase } = {
    Presentation: {
        name: "Presentation",
        icon: "presentation-icon",
        bg: "presentation-bg",
        iconBg: "presentation-icon-bg"
    },
    Preparation: {
        name: "Preparation",
        icon: "preparation-icon",
        bg: "preparation-bg",
        iconBg: "preparation-icon-bg"
    },
    BattleSetup: {
        name: "Battle Setup",
        icon: "battle-setup-icon",
        bg: "battle-setup-bg",
        iconBg: "battle-setup-icon-bg"
    },
    BattleStart: {
        name: "Battle Start",
        icon: "battle-start-icon",
        bg: "battle-start-bg",
        iconBg: "battle-start-icon-bg",
    },
    BattleEnd: {
        name: "Battle End",
        icon: "battle-end-icon",
        bg: "battle-end-bg",
        iconBg: "battle-end-icon-bg",
    }
};