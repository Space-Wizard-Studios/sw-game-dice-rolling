import { AddDialogue } from '@helpers/AddDialogue';
import { AddInputOptions } from '@helpers/AddInputOptions';
import { AddCharacter } from '@helpers/AddCharacter';
import { GetRandomCharacters } from '@helpers/GetRandomCharacters';
import { Character } from 'types/characters';
import { diceOptions } from '@config/diceOptions';

import { playableCharacters } from '@config/playableCharacters';

export async function BuildSetup() {
    // Step 1: Present the build phase to the player
    AddDialogue("Build phase where player can choose characters.");

    // Step 2: Present the characters to the player
    const randomCharacters: Character[] = GetRandomCharacters(playableCharacters, 3, 1);
    const characterOptions = randomCharacters.map(character => character.name);
    AddDialogue(`Choose one character: ${randomCharacters.map(c => c.name).join(", ")}`);

    // Step 3: for each randomly get character, assign an option with a button to add the character selected
    await AddInputOptions(
        [
            {
                label: 'Add character',
                callback: async (selectedValues: string[]) => {
                    const selectedCharacter = randomCharacters.find(character => character.name === selectedValues[0]);
                    if (selectedCharacter) {
                        AddCharacter(selectedCharacter);
                        AddDialogue(`Character ${selectedCharacter.name} has been added.`);

                        // Step 4: Present the dice options to the player
                        const diceOptionKeys = Object.keys(diceOptions);
                        AddDialogue(`Choose one dice: ${diceOptionKeys.join(", ")}`);

                        await AddInputOptions(
                            [
                                {
                                    label: 'Select Dice',
                                    callback: (selectedDiceValues: string[]) => {
                                        const selectedDice = diceOptions[selectedDiceValues[0] as keyof typeof diceOptions];
                                        if (selectedDice) {
                                            selectedCharacter.dice = selectedDice;
                                            AddDialogue(`Dice ${selectedDiceValues[0]} has been added to character ${selectedCharacter.name}.`);
                                        }
                                    }
                                },
                            ],
                            'radio',
                            diceOptionKeys,
                            true
                        );
                    }
                }
            },
        ],
        'radio',
        characterOptions,
        false
    );
}