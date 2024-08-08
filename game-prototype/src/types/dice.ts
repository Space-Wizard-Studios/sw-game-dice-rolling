import { DiceAction } from './actions/dice';

type DiceSide = DiceAction;

type Dice<
    Sides extends number,
    T = DiceSide,
    R extends T[] = []
> = R['length'] extends Sides ? R : Dice<Sides, T, [T, ...R]>;

export type D4 = Dice<4>;
export type D6 = Dice<6>;
export type D8 = Dice<8>;
export type D10 = Dice<10>;
export type D12 = Dice<12>;
export type D20 = Dice<20>;
export type D100 = Dice<100>;
