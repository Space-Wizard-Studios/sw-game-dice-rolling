import { Action, Actions } from '../types/actions';
import { Character } from '../types/characters';
import { Roles } from '../types/roles';
import { D4, D6, D8, D10, D12, D20, D100 } from '../types/dice';

import * as readline from 'readline';
import { simulatePlays } from './simulatePlays';

import { RollDice } from './game/RollDice';

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

const playerCharacters: Character[] = [
    {
        name: "Player 1",
        role: Roles.Fighter,
        health: 100,
        die: null,
    },
];

const enemyCharacters: Character[] = [
    {
        name: "Enemy 1",
        role: Roles.Fighter,
        health: 50,
        die: [Actions.empty, Actions.empty, Actions.empty, Actions.empty] as D4,
    },
];

export const diceOptions = {
    1: [Actions.attack, Actions.empty, Actions.attack, Actions.empty] as D4,
    2: [Actions.attack, Actions.attack, Actions.defend, Actions.empty] as D4,
    3: [Actions.attack, Actions.defend, Actions.defend, Actions.empty] as D4,
    4: [Actions.attack, Actions.empty, Actions.attack, Actions.empty] as D4,
};

export type DiceOptions = keyof typeof diceOptions;

function askQuestion(query: string): Promise<string> {
    return new Promise(resolve => rl.question(query, resolve));
}

async function chooseDice(): Promise<void> {
    console.log("Choose two dice for your character:");
    for (const [key, actions] of Object.entries(diceOptions)) {
        const actionCounts = actions.reduce((acc, action) => {
            acc[action.name] = (acc[action.name] || 0) + 1;
            return acc;
        }, {} as Record<string, number>);

        const actionPercentages = Object.entries(actionCounts).map(
            ([action, count]) => `${action}: ${(count / actions.length) * 100}%`
        );

        console.log(`${key}. ${actions.map(action => action.name).join(', ')} (${actionPercentages.join(', ')})`);
    }

    const choice1 = await askQuestion("Enter the option for the first die: ");
    const choice2 = await askQuestion("Enter the option for the second dice: ");

    const die1 = parseInt(choice1) as DiceOptions;
    const die2 = parseInt(choice2) as DiceOptions;

    if (!diceOptions[die1] || !diceOptions[die2]) {
        console.log("Invalid choice. Please choose valid dice.");
        return;
    }

    const chosenDice = [diceOptions[die1], diceOptions[die2]];

    playerCharacters[0].die = chosenDice as any;
}

async function main() {
    await chooseDice();

    const playerDice = playerCharacters[0].die;
    if (playerDice) {
        const { indices, actions } = RollDice(playerDice);
        console.log(`You rolled: ${actions.join(', ')}`);
    }

    rl.close();

    // simulatePlays(10000);
}

main();