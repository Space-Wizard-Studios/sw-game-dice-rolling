import { createSignal, JSX } from 'solid-js';

import { Dialog, DialogContent, DialogDescription, DialogHeader, DialogTitle } from '@components/ui/dialog';
import { CharacterSheet } from '@components/Board/Character/CharacterSheet';

import type { Character } from 'types/Characters';

export const renderCharacter = (character: Character, selectItem: () => void, isSelected: boolean) => (
    <div onClick={selectItem} class={isSelected ? 'border-2 border-blue-500 bg-blue-100' : ''}>
        <CharacterSheet character={character} />
    </div>
);
interface SelectionDialogProps<T> {
    open: boolean;
    items: T[];
    renderItem: (item: T, selectItem: () => void, isSelected: boolean) => JSX.Element;
    onConfirm: (item: T) => void;
}

export const SelectionDialog = <T,>(props: SelectionDialogProps<T>) => {
    const [selectedItem, setSelectedItem] = createSignal<T | null>(null);

    return (
        <Dialog open={props.open}>
            <DialogContent>
                <DialogHeader>
                    <DialogTitle>Choose wisely</DialogTitle>
                    <DialogDescription>
                        Choose one of the items below:
                    </DialogDescription>
                </DialogHeader>
                <div>
                    {props.items.map(item => (
                        <div onClick={() => setSelectedItem(() => item)}>
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