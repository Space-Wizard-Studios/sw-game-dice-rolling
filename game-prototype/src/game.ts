import './styles/styles.scss';

import { addDialogue } from '@helpers/Text';
import { waitForSubmit } from '@helpers/waitForSubmit';

import { battleSetup } from './game/battleSetup';
import { battleStart } from './game/battleStart';
import { battleEnd } from './game/battleEnd';

async function main() {

    addDialogue("Welcome to the game! Press 'Start Battle' to start the battle phases.");
    await waitForSubmit('Start Battle');

    battleSetup();
    battleStart();
    battleEnd();

    // for (let i = 1; i <= 150; i++) {
    //     addTextToDialogue(`Debug line ${i}`);
    // }

}

main();