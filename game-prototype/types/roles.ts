export type Role = {
    name: string;
    description: string;
};

export const Roles: { [key: string]: Role } = {
    Fighter: {
        name: "Fighter",
        description: "A strong and brave warrior skilled in combat."
    },
    Healer: {
        name: "Healer",
        description: "A compassionate character who can heal wounds and cure ailments."
    },
    Rogue: {
        name: "Rogue",
        description: "A stealthy and agile character skilled in deception and evasion."
    }
};