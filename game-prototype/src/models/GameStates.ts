export type GameState = {
    name: string;
    icon: string;
    bg: string;
    iconBg: string;
};

export type GameStatesType = {
    [key: string]: GameState;
};
