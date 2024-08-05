import { LoadTemplate } from '@helpers/LoadTemplate';
import { Character } from "types/characters";

import html from '@components/character.html';

export async function AddCharacter(character: Character) {
    if (!document.getElementById('characterTemplate')) {
        await LoadTemplate(html);
    }

    const template = document.getElementById('characterTemplate') as HTMLTemplateElement;
    if (!template) {
        console.error('Character template not found');
        return;
    }

    const clone = document.importNode(template.content, true);

    const charElement = clone.querySelector('.character') as HTMLElement;
    if (!charElement) {
        console.error('Character element not found in template');
        return;
    }

    const charName = charElement.querySelector('.charName') as HTMLElement;
    const charHealthCurrent = charElement.querySelector('.charHealth .current') as HTMLElement;
    const charHealthMax = charElement.querySelector('.charHealth .max') as HTMLElement;
    const charActionName = charElement.querySelector('.charAction .name') as HTMLElement;
    const charActionTarget = charElement.querySelector('.charAction .target') as HTMLElement;
    const charInitiative = charElement.querySelector('.initiative .value') as HTMLElement;

    if (charName) charName.textContent = character.name;
    if (charHealthCurrent) charHealthCurrent.textContent = character.health.current?.toString() || character.health.max.toString();
    if (charHealthMax) charHealthMax.textContent = character.health.max.toString();
    if (charActionName) charActionName.textContent = 'None';
    if (charActionTarget) charActionTarget.textContent = 'None';
    if (charInitiative) charInitiative.textContent = character.speed.current?.toString() || character.speed.max.toString();

    const playerBoard = document.getElementById('player');
    if (playerBoard) {
        playerBoard.appendChild(clone);
    }
}