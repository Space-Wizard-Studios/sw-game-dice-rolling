import { DiceOptions, diceOptions } from ".";
import { RollDice } from './game/RollDice';

export function getRandomDice(): DiceOptions {
    const keys = Object.keys(diceOptions) as unknown as DiceOptions[];
    return keys[Math.floor(Math.random() * keys.length)];
}

export function simulatePlays(numPlays: number): void {
    const results: Record<string, number> = {};

    for (let i = 0; i < numPlays; i++) {
        const die1 = getRandomDice() as keyof typeof diceOptions;
        const die2 = getRandomDice() as keyof typeof diceOptions;
        const chosenDice = [diceOptions[die1], diceOptions[die2]];

        const { actions } = RollDice(chosenDice);
        actions.forEach(action => {
            results[action] = (results[action] || 0) + 1;
        });
    }

    console.log(`Results after ${numPlays} plays:`);
    for (const [action, count] of Object.entries(results)) {
        console.log(`${action}: ${count}`);
    }
}
