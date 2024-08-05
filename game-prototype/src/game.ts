import './styles/styles.scss';

import { AddDialogue } from '@helpers/Dialogue';
import { AddOptions } from '@helpers/Input';

import { BuildSetup } from './gameplay/BuildSetup';
import { BattleSetup } from './gameplay/BattleSetup';
import { BattleStart } from './gameplay/BattleStart';
import { BattleEnd } from './gameplay/BattleEnd';


async function main() {

    await BuildSetup();
    await BattleSetup();
    await BattleStart();
    await BattleEnd();

}

main();

