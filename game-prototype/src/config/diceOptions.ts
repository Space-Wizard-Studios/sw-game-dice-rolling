import { DiceActions } from 'types/actions/dice';
import { D4 } from 'types/dice';

export const diceOptions = {
    dice1: [DiceActions.physicalAttack, DiceActions.empty, DiceActions.physicalAttack, DiceActions.empty] as D4,
    dice2: [DiceActions.physicalAttack, DiceActions.magicAttack, DiceActions.defend, DiceActions.empty] as D4,
    dice3: [DiceActions.magicAttack, DiceActions.defend, DiceActions.defend, DiceActions.empty] as D4,
    dice4: [DiceActions.magicAttack, DiceActions.empty, DiceActions.magicAttack, DiceActions.empty] as D4,
};