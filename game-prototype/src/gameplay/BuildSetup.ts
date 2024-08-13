import { AddDialogue } from '@helpers/dialogueStore';
import { AddInputOptions } from '@helpers/AddInputOptions';
import { AddCharacter } from '@helpers/AddCharacter';
import { GetRandomCharacters } from '@helpers/GetRandomCharacters';
import { Character } from 'types/characters';
// import { diceOptions } from '@config/diceOptions';
import { playerCharacters } from '@example/playerCharacters';

export async function BuildSetup() {
    // Step 1: Present the build phase to the player
    AddDialogue("BUILD PHASE: player can choose characters.");

    // Step 2: Present the characters to the player
    const randomCharacters = GetRandomCharacters(playerCharacters, 3, 1);
    const characterOptions = randomCharacters.map(character => character.name);
    AddDialogue(`Choose one character: ${characterOptions.join(", ")}`);

    // Step 3: Handle character selection
    await handleCharacterSelection(randomCharacters, characterOptions);
}

async function handleCharacterSelection(randomCharacters: Character[], characterOptions: string[]): Promise<void> {
    return new Promise((resolve) => {
        AddInputOptions(
            [
                {
                    label: 'Add character',
                    callback: async (selectedValues: string[]) => {
                        const selectedCharacter = randomCharacters.find(character => character.name === selectedValues[0]);
                        if (selectedCharacter) {
                            AddCharacter(selectedCharacter);
                            AddDialogue(`Character ${selectedCharacter.name} has been added.`);
                            await handleDiceSelection(selectedCharacter);
                        }
                        resolve();
                    }
                },
            ],
            'radio',
            characterOptions,
            false
        );
    });
}

async function handleDiceSelection(selectedCharacter: Character): Promise<void> {
    return new Promise((resolve) => {
        const diceOptionKeys = Object.keys(diceOptions);
        AddDialogue(`Choose one dice: ${diceOptionKeys.join(", ")}`);

        AddInputOptions(
            [
                {
                    label: 'Select Dice',
                    callback: async (selectedDiceValues: string[]) => {
                        const selectedDice = diceOptions[selectedDiceValues[0] as keyof typeof diceOptions];
                        if (selectedDice) {
                            selectedCharacter.diceSet = selectedDice;
                            AddDialogue(`Dice ${selectedDiceValues[0]} has been added to character ${selectedCharacter.name}.`);
                            AddDialogue("----------------------------------------");
                        }
                        resolve();
                    }
                },
            ],
            'radio',
            diceOptionKeys,
            true
        );
    });
}