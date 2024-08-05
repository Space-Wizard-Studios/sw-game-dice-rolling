import './styles/styles.scss';

import { AddDialogue } from '@helpers/Text';
import { WaitForSubmit } from '@helpers/WaitForSubmit';

import { BattleSetup } from './gameplay/BattleSetup';
import { BattleStart } from './gameplay/BattleStart';
import { BattleEnd } from './gameplay/BattleEnd';
import { BuildSetup } from './gameplay/BuildSetup';

import { Character } from "types/characters";

import { playableCharacters } from '@config/playableCharacters';
import { AddCharacter } from '@helpers/AddCharacter';

async function main() {

    let character = playableCharacters[0];
    character.name = "Fighter";
    AddCharacter(character);

    // AddDialogue("Welcome to the game! Press 'Start Battle' to start the battle phases.");
    // await WaitForSubmit('Start Battle');

    // BuildSetup();
    // BattleSetup();
    // BattleStart();
    // BattleEnd();

}

main();

