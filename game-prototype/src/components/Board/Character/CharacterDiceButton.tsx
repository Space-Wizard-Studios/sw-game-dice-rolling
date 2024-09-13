import type { Component } from 'solid-js';
import { Button } from '@components/ui/button';
import {
    Popover,
    PopoverContent,
    PopoverDescription,
    PopoverTitle,
    PopoverTrigger,
} from '@components/ui/popover';

import type { PopoverTriggerProps } from '@kobalte/core/popover';
import type { DiceType } from '@models/Dice';

type DiceButtonProps = {
    dice: DiceType;
    class?: string;
}

export const CharacterDiceButton: Component<DiceButtonProps> = (props) => {
    // store the count of each unique action
    const actionCountMap = new Map<string, number>();

    props.dice.actions.forEach(action => {
        actionCountMap.set(action.name, (actionCountMap.get(action.name) || 0) + 1);
    });

    // total number of actions
    const totalActions = props.dice.actions.length;

    // probability for each unique action
    const actionProbabilities = Array.from(actionCountMap.entries()).map(([name, count]) => ({
        name,
        probability: ((count / totalActions) * 100).toFixed(2)
    }));

    return (
        <Popover>
            <PopoverTrigger
                as={(triggerProps: PopoverTriggerProps) => (
                    <Button {...triggerProps} class='px-2 bg-white dark:bg-black text-black' size='sm'>
                        {props.dice.name}
                    </Button>
                )}
            />
            <PopoverContent class='w-80'>
                <div class='grid gap-1'>
                    <PopoverTitle class='space-y-1'>
                        <h4 class='font-medium leading-none'>Actions for {props.dice.name}</h4>
                    </PopoverTitle>
                    <PopoverDescription class='grid gap-1'>
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
                                {props.dice.actions.map((action) => (
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
    )
}