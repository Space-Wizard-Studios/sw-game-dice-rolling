import { Actions } from 'types/actions';
import { D4 } from 'types/dice';

export const diceOptions = {
    1: [Actions.attack, Actions.empty, Actions.attack, Actions.empty] as D4,
    2: [Actions.attack, Actions.attack, Actions.defend, Actions.empty] as D4,
    3: [Actions.attack, Actions.defend, Actions.defend, Actions.empty] as D4,
    4: [Actions.attack, Actions.empty, Actions.attack, Actions.empty] as D4,
};

export type DiceOptions = keyof typeof diceOptions;