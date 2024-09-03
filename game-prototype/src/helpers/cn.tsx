import type { ClassValue } from "clsx";
import clsx from "clsx";
import { twMerge } from "tailwind-merge";

/**
 * Combines multiple class names into a single string and merges Tailwind CSS classes.
 * 
 * @param {...ClassValue[]} classLists - An array of class names or objects with class names as keys.
 * @returns {string} - A single string with merged class names.
 */
export const cn = (...classLists: ClassValue[]) => twMerge(clsx(classLists));