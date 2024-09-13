/**
 * Returns a random element from the given array.
 * 
 * @template T - The type of elements in the array.
 * @param {T[]} array - The array from which to select a random element.
 * @returns {T} - A random element from the array.
 */
export function getRandomElement<T>(array: T[]): T {
	return array[Math.floor(Math.random() * array.length)];
}