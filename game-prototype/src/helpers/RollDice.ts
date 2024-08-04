export function RollDice(dice: any[]): { indices: number[], actions: string[] } {
    const indices = dice.map(die => Math.floor(Math.random() * die.length));
    const actions = indices.map((index, i) => dice[i][index].name);
    return { indices, actions };
}
