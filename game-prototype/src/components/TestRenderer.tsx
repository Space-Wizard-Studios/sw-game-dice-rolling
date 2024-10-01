import { onMount } from "solid-js";

import { useGameManager } from "@stores/GameContext";
import { GameplayScene } from '@components/Scenes/Gameplay';
import { updateGameScene } from "@helpers/updateGameState";

import { diceStore } from "@stores/DiceStore";
import { enemyCharacterStore, playerCharacterStore } from "@stores/CharacterStore";

import { generateRandomDice } from "@helpers/generateRandomDice";
import { generateRandomCharacter } from "@helpers/generateRandomCharacter";
import { transferDice } from "@helpers/diceTransferHandler";
import { addChatMessage } from "@stores/ChatStore";

export const TestRenderer = () => {
	const [gameManager] = useGameManager();
	updateGameScene("gameplayScene", "gameplayBattleTurn");

	onMount(async () => {
		if (playerCharacterStore.store.characters.length === 0) {
			const randomPlayerCharacters = generateRandomCharacter(3);
			playerCharacterStore.addMultipleCharacters(randomPlayerCharacters);
		}

		if (diceStore.store.diceSet.length === 0) {
			const randomPlayerDice = generateRandomDice(6, [4, 6, 8, 10, 20, 100]);
			diceStore.addMultipleDice(randomPlayerDice);
			diceStore.store.diceSet.forEach(dice => {
				transferDice(dice.id, null, 'inventory');
			});
		}

		if (enemyCharacterStore.store.characters.length === 0) {
			const randomEnemyCharacters = generateRandomCharacter(3, 'Enemy', true);
			enemyCharacterStore.addMultipleCharacters(randomEnemyCharacters);
		}

		await addChatMessage({
			lines: [
				{
					text: 'Foram gerados personagens e dados, equipe e role!',
					type: 'info',
				}
			],
			requiresUserAction: { type: 'rollDice' },
		});

	});

	return (
		<main class="relative h-dvh w-dvh overflow-hidden">
			<GameplayScene />
		</main>
	);
};