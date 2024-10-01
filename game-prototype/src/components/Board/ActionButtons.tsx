import { type Component } from "solid-js";
import { useGameManager, type UserActionType } from "@stores/GameContext";
import { Button } from "@components/ui/button";
import { rollAllPlayerDice } from "@helpers/rollDice";

type ActionButtonsProps = {
	actionType: UserActionType | undefined;
};

export const ActionButtons: Component<ActionButtonsProps> = (props) => {
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
		<Button onClick={handleClick}>
			{props.actionType === 'continue' ? 'Continuar' : 'Rolar dados!'}
		</Button>
	);
};