import { Character } from "types/characters";

export function GetRandomCharacters(characters: Character[], count: number, maxDuplicates: number = 1): Character[] {
    const selectedCharacters: Character[] = [];
    while (selectedCharacters.length < count) {
        const randomIndex = Math.floor(Math.random() * characters.length);
        const selectedCharacter = characters[randomIndex];
        selectedCharacters.push(selectedCharacter);
        if (selectedCharacters.filter(c => c.name === selectedCharacter.name).length > maxDuplicates) {
            characters.splice(randomIndex, 1);
        }
    }
    return selectedCharacters;
}
