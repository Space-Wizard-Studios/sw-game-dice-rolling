import { Button } from '@components/ui/button';
import {
    Popover,
    PopoverContent,
    PopoverDescription,
    PopoverTitle,
    PopoverTrigger,
} from '@components/ui/popover';

import type { Component } from 'solid-js';
import type { DiceType } from 'types/Dice';
import type { PopoverTriggerProps } from '@kobalte/core/popover';

type CharacterDiceProps = {
    class?: string;
    diceSet: DiceType[];
    onClick?: () => void;
}

export const CharacterDice: Component<CharacterDiceProps> = (props) => {
    return (
        <div class='flex flex-row gap-4 items-center'>
            <p class='text-sm'>Dice Set:</p>
            <ul class='list-none grid grid-cols-4 gap-4'>
                {props.diceSet.map((diceSet) => {
                    // store the count of each unique action
                    const actionCountMap = new Map<string, number>();
                    diceSet.dice.forEach(action => {
                        actionCountMap.set(action.name, (actionCountMap.get(action.name) || 0) + 1);
                    });

                    // total number of actions
                    const totalActions = diceSet.dice.length;

                    // probability for each unique action
                    const actionProbabilities = Array.from(actionCountMap.entries()).map(([name, count]) => ({
                        name,
                        probability: ((count / totalActions) * 100).toFixed(2)
                    }));

                    return (
                        <li>
                            <Popover>
                                <PopoverTrigger
                                    as={(triggerProps: PopoverTriggerProps) => (
                                        <Button {...triggerProps} class='bg-white dark:bg-black text-black' size='sm'>
                                            {diceSet.name}
                                        </Button>
                                    )}
                                />
                                <PopoverContent class='w-80'>
                                    <div class='grid gap-4'>
                                        <PopoverTitle class='space-y-2'>
                                            <h4 class='font-medium leading-none'>Actions for {diceSet.name}</h4>
                                        </PopoverTitle>
                                        <PopoverDescription class='grid gap-2'>
                                            <div>
                                                <h5 class='font-medium'>Probability:</h5>
                                                <ul>
                                                    {actionProbabilities.map(({ name, probability }) => (
                                                        <li>
                                                            {name} - {probability}%
                                                        </li>
                                                    ))}
                                                </ul>
                                            </div>
                                            <div>
                                                <h5 class='font-medium'>Dice:</h5>
                                                <ul>
                                                    {diceSet.dice.map((action) => (
                                                        <li>
                                                            {action.name}
                                                        </li>
                                                    ))}
                                                </ul>
                                            </div>
                                        </PopoverDescription>
                                    </div>
                                </PopoverContent>
                            </Popover>
                        </li>
                    );
                })}
            </ul>
        </div>
    );
};