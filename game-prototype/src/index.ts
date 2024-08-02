import { Action, Actions } from '../types/actions';
import { Character } from '../types/characters';
import { Roles } from '../types/roles';
import { D4, D6, D8, D10, D12, D20, D100 } from '../types/dice';

import * as readline from 'readline';

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

const diceOptions = {
    1: [Actions.attack, Actions.empty, Actions.attack, Actions.empty] as D4,
    2: [Actions.attack, Actions.attack, Actions.defend, Actions.empty] as D4,
    3: [Actions.attack, Actions.defend, Actions.defend, Actions.empty] as D4,
    4: [Actions.attack, Actions.empty, Actions.attack, Actions.empty] as D4,
};

type DiceType = keyof typeof diceOptions;

// function askQuestion(query: string): Promise<string> {
//     return new Promise(resolve => rl.question(query, resolve));
// }

// async function chooseDice(): Promise<void> {
//     console.log("Choose two dice for your character:");
//     for (const [key, actions] of Object.entries(diceOptions)) {
//         const actionCounts = actions.reduce((acc, action) => {
//             acc[action.name] = (acc[action.name] || 0) + 1;
//             return acc;
//         }, {} as Record<string, number>);

//         const actionPercentages = Object.entries(actionCounts).map(
//             ([action, count]) => `${action}: ${(count / actions.length) * 100}%`
//         );

//         console.log(`${key}. ${actions.map(action => action.name).join(', ')} (${actionPercentages.join(', ')})`);
//     }

//     const choice1 = await askQuestion("Enter the number of the first die: ");
//     const choice2 = await askQuestion("Enter the number of the second die: ");

//     const die1 = parseInt(choice1) as DiceType;
//     const die2 = parseInt(choice2) as DiceType;

//     if (!diceOptions[die1] || !diceOptions[die2]) {
//         console.log("Invalid choice. Please choose valid dice.");
//         return;
//     }

//     const chosenDice = [diceOptions[die1], diceOptions[die2]];

//     playerCharacters[0].die = chosenDice as any;
// }

function getRandomDice(): DiceType {
    const keys = Object.keys(diceOptions) as unknown as DiceType[];
    return keys[Math.floor(Math.random() * keys.length)];
}

function rollDice(dice: any[]): { indices: number[], actions: string[] } {
    const indices = dice.map(die => Math.floor(Math.random() * die.length));
    const actions = indices.map((index, i) => dice[i][index].name);
    return { indices, actions };
}

function simulatePlays(numPlays: number): void {
    const results: Record<string, number> = {};

    for (let i = 0; i < numPlays; i++) {
        const die1 = getRandomDice() as keyof typeof diceOptions;
        const die2 = getRandomDice() as keyof typeof diceOptions;
        const chosenDice = [diceOptions[die1], diceOptions[die2]];

        const { actions } = rollDice(chosenDice);
        actions.forEach(action => {
            results[action] = (results[action] || 0) + 1;
        });
    }

    console.log(`Results after ${numPlays} plays:`);
    for (const [action, count] of Object.entries(results)) {
        console.log(`${action}: ${count}`);
    }
}

async function main() {
    // await chooseDice();

    // const playerDice = playerCharacters[0].die;
    // if (playerDice) {
    //     const { indices, actions } = rollDice(playerDice);
    //     console.log(`You rolled: ${actions.join(', ')}`);
    // }

    // rl.close();

    simulatePlays(10000);
}

main();