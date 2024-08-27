import { createSignal, JSX } from 'solid-js';

import { Dialog, DialogContent, DialogDescription, DialogHeader, DialogTitle } from '@components/ui/dialog';
import { CharacterSheet } from '@components/Board/Character/CharacterSheet';

import type { Character } from '../../types/Characters';

export const renderCharacter = (character: Character, selectItem: () => void, isSelected: boolean) => (
    <CharacterSheet character={character} onClick={selectItem}
        class={isSelected ? 'border-2 border-blue-500 bg-blue-200' : ''}
    />
);
interface SelectionDialogProps<T> {
    open: boolean;
    items: T[];
    renderItem: (item: T, selectItem: () => void, isSelected: boolean) => JSX.Element;
    onConfirm: (item: T) => void;
}

export const ItemSelection = <T,>(props: SelectionDialogProps<T>) => {
    const [selectedItem, setSelectedItem] = createSignal<T | null>(null);

    return (
        <Dialog open={props.open} >
            <DialogContent enableClose={false}>
                <DialogHeader>
                    <DialogTitle>Choose wisely</DialogTitle>
                    <DialogDescription>
                        Choose one of the items below:
                    </DialogDescription>
                </DialogHeader>
                <div class='flex flex-col gap-2'>
                    {props.items.map(item => (
                        <div onClick={() => setSelectedItem(() => item)} class='cursor-pointer hover:bg-blue-100'>
                            {props.renderItem(item, () => setSelectedItem(() => item), selectedItem() === item)}
                        </div>
                    ))}
                </div>
                <button
                    onClick={() => {
                        if (selectedItem()) {
                            props.onConfirm(selectedItem()!);
                        }
                    }}
                >
                    Confirm Selection
                </button>
            </DialogContent>
        </Dialog>
    );
};