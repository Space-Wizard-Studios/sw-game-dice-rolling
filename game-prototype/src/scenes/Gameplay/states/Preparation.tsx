import { addDialogueLine, addDialogueMessage } from '@stores/Dialogue';
import { generateRandomCharacters } from '@helpers/generateRandomCharacters';
import { CharacterSelection } from '@components/ItemSelection/CharacterSelection';
import { enemyCharacterStore } from '@stores/Character';

export async function Preparation() {
    addDialogueMessage({
        lines: [
            { text: 'Esta é a fase de preparação.' },
        ]
    });

    // Generate random characters and present them to the player for selection
    const playerCharacters = generateRandomCharacters(3, 'Player');
    const playerSelectedCharacter = await CharacterSelection(playerCharacters);
    addDialogueLine(`Character chosen: ${playerSelectedCharacter.name}`);
    
    const enemyCharacters = generateRandomCharacters(5, 'Enemy');
    enemyCharacterStore.addCharacters(enemyCharacters);
    
    return null;
}

// - Generate dices and present them to the player
// - Prompt the player to choose one dice to be added to the player's inventory
// - Prompt the player to choose one dice and assign it to the character's diceSet