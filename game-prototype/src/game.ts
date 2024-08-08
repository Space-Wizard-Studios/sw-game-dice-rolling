import './styles/styles.scss';

import { BuildSetup } from './gameplay/BuildSetup';
import { BattleSetup } from './gameplay/BattleSetup';
import { BattleStart } from './gameplay/BattleStart';
import { BattleEnd } from './gameplay/BattleEnd';
import { GamePresentation } from './gameplay/GamePresentation';
import { AddInputContinue } from './helpers/AddInputContinue';

async function main() {
    GamePresentation();
    await AddInputContinue();
    await BuildSetup();
    await BattleSetup();
    // await BattleStart();
    // await BattleEnd();
}

main();

