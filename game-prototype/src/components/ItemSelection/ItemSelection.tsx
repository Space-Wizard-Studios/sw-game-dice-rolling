import { createSignal, type JSX } from 'solid-js';
import { Dialog, DialogContent, DialogDescription, DialogHeader, DialogTitle } from '@components/ui/dialog';

type SelectionDialogProps<T> = {
	title: string,
	description: string,
	buttonText?: string,
	open: boolean,
	items: T[],
	renderItem: (item: T, selectItem: () => void, isSelected: boolean) => JSX.Element,
	onConfirm: (item: T) => void,
}

export const ItemSelection = <T,>(props: SelectionDialogProps<T>) => {
	const [selectedItem, setSelectedItem] = createSignal<T | null>(null);

	return (
		<Dialog open={props.open} >
			<DialogContent enableClose={false}>
				<DialogHeader>
					<DialogTitle>{props.title}</DialogTitle>
					<DialogDescription>{props.description}</DialogDescription>
				</DialogHeader>
				<div class='flex flex-col gap-1'>
					{props.items.map(item => (
						<div onClick={() => setSelectedItem(() => item)} class='cursor-pointer hover:bg-blue-100'>
							{props.renderItem(item, () => setSelectedItem(() => item), selectedItem() === item)}
						</div>
					))}
				</div>
				<button onClick={() => { if (selectedItem()) { props.onConfirm(selectedItem()!); } }}>{props.buttonText ?? 'Confirmar'}</button>
			</DialogContent>
		</Dialog>
	);
};