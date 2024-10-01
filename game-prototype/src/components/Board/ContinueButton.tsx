import { type Component } from "solid-js";
import { useGameManager } from "@stores/GameContext";
import { Button } from "@components/ui/button";

export const ContinueButton: Component = () => {
	const [gameState, setGameState] = useGameManager();

	const handleContinue = () => {
		setGameState('paused', false);
	};

	return (
		<Button onClick={handleContinue}>
			Continuar
		</Button>
	);
};