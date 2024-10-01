import { type Component } from "solid-js";
import { useGameManager, type UserActionType } from "@stores/GameContext";
import { Button } from "@components/ui/button";
import { rollAllPlayerDice } from "@helpers/rollDice";

type ActionButtonProps = {
	actionType: UserActionType | undefined;
};

export const ActionButton: Component<ActionButtonProps> = (props) => {
	const [gameState, setGameState] = useGameManager();

	const handleContinue = () => {
		setGameState('status', 'running');
	};

	const handleRollDice = () => {
		rollAllPlayerDice();
		// setGameState('status', 'running');
	};

	const handleClick = () => {
		if (props.actionType === 'continue') {
			handleContinue();
		} else if (props.actionType === 'rollDice') {
			handleRollDice();
		}
	};

	return (
		<Button onClick={handleClick} class='bg-green-700 bg-opacity-100'>
			{props.actionType === 'continue' ? 'Continuar' : 'Rolar dados!'}
		</Button>
	);
};