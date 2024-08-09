import { Button } from "@components/ui/button";
import {
    Popover,
    PopoverContent,
    PopoverDescription,
    PopoverTitle,
    PopoverTrigger,
} from "@components/ui/popover";

import type { Component } from 'solid-js';
import type { DiceType } from 'types/dice';
import type { PopoverTriggerProps } from "@kobalte/core/popover";

export const CharacterDice: Component<{ diceSet: DiceType[] }> = (props) => {
    return (
        <div>
            <p class="text-sm">Dice:</p>
            <ul class="list-none grid grid-cols-4 gap-4">
                {props.diceSet.map((diceSet) => (
                    <li>
                        <Popover>
                            <PopoverTrigger
                                as={(triggerProps: PopoverTriggerProps) => (
                                    <Button {...triggerProps}>
                                        {diceSet.name}
                                    </Button>
                                )}
                            />
                            <PopoverContent class="w-80">
                                <div class="grid gap-4">
                                    <PopoverTitle class="space-y-2">
                                        <h4 class="font-medium leading-none">Actions for {diceSet.name}</h4>
                                    </PopoverTitle>
                                    <PopoverDescription class="grid gap-2">
                                        <ul>
                                            {diceSet.dice.map((dice) => (
                                                <li>{dice.name}</li>
                                            ))}
                                        </ul>
                                    </PopoverDescription>
                                </div>
                            </PopoverContent>
                        </Popover>
                    </li>
                ))}
            </ul>
        </div>
    );
};