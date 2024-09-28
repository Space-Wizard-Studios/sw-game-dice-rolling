import { createSignal, type JSX } from 'solid-js';
import { Dialog, DialogContent, DialogDescription, DialogHeader, DialogTitle } from '@components/ui/dialog';
import { Button } from '@components/ui/button';

type RenderIcon<T> = (icon: T) => JSX.Element;
type RenderItem<T> = (item: T, selectItem: () => void, isSelected: boolean) => JSX.Element;
type RenderLabel<T> = (label: T) => JSX.Element;

type SelectionDialogProps<T> = {
	title: string,
	description: string,
	buttonText?: string,
	open: boolean,
	items: T[],
	onConfirm: (item: T) => void,
	renderItem: RenderItem<T>,
	renderIcon?: RenderIcon<T>,
	renderLabel?: RenderLabel<T>,
}

export const ItemSelection = <T,>(props: SelectionDialogProps<T>) => {
	const [selectedItem, setSelectedItem] = createSignal<T | null>(null);

	const handleConfirm = () => {
		if (selectedItem()) {
			props.onConfirm(selectedItem()!);
		}
	};

	const handleItemClick = (item: T) => {
		setSelectedItem(() => item);
	};

	const renderIcon = (item: T) => (
		<div>
			{props.renderIcon?.(item)}
		</div>
	);

	const renderItem = (item: T) => (
		<div
			onClick={() => handleItemClick(item)}
			class={`w-full cursor-pointer rounded-md  hover:bg-blue-200 
				${selectedItem() === item
					? 'bg-blue-100 '
					: ''}`}
		>
			{props.renderItem(item, () => handleItemClick(item), selectedItem() === item)}
		</div>
	);

	const renderLabel = (item: T) => (
		<div>
			{props.renderLabel?.(item)}
		</div>
	);

	return (
		<Dialog open={props.open} >
			<DialogContent enableClose={false}>
				<DialogHeader>
					<DialogTitle>{props.title}</DialogTitle>
					<DialogDescription>{props.description}</DialogDescription>
				</DialogHeader>
				<div class='flex flex-col gap-1 max-h-96 overflow-scroll'>
					{props.items.map(item => (
						<div class='flex flex-row w-full gap-1 items-center justify-center'>
							{renderIcon(item)}
							{renderItem(item)}
							{renderLabel(item)}
						</div>
					))}
				</div>
				<Button onClick={handleConfirm}>
					{props.buttonText ?? 'Confirmar'}
				</Button>
			</DialogContent>
		</Dialog>
	);
};