import { addDialogue } from '../helpers/Text';
import { playableCharacters } from '../gameConfig';
import { Character } from '../types/characters';

function getRandomCharacters(characters: Character[], count: number): Character[] {
    const selectedCharacters: Character[] = [];
    while (selectedCharacters.length < count) {
        const randomIndex = Math.floor(Math.random() * characters.length);
        const selectedCharacter = characters[randomIndex];
        selectedCharacters.push(selectedCharacter);
        if (selectedCharacters.filter(c => c.name === selectedCharacter.name).length > 1) {
            characters.splice(randomIndex, 1); // Remove character to avoid more than one duplicate
        }
    }
    return selectedCharacters;
}

export function battleSetup() {
    addDialogue("Setting up characters and builds...");

    const selectedCharacters = getRandomCharacters(playableCharacters, 3);
    selectedCharacters.forEach(character => {
        addDialogue(`Selected character: ${character.name}`);
    });
}