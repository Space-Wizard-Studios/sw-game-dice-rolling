
export function getDiceIcon(sides: number) {
	switch (sides) {
		case 4:
			return (
				<svg xmlns="http://www.w3.org/2000/svg" class='h-6 w-6' viewBox="0 0 24 24">
					<path fill="currentColor" d="m10.25 15.15l1.67-2.68v2.68zM21.92 21H2.08c-.84 0-1.36-.92-.92-1.64l9.92-16.23c.42-.69 1.42-.69 1.84 0l9.92 16.23c.44.72-.08 1.64-.92 1.64m-7.63-5.85h-.86v-4.73h-1.52l-3.16 4.99l.07.95h3.1V18h1.51v-1.64h.86z" />
				</svg>
			);
		case 6:
			return (
				<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24">
					<path fill="currentColor" d="M13.05 13.5c0 .77-.44 1.33-1.05 1.33s-1.15-.56-1.15-1.33l-.02-.72s.38-.78 1.12-.68c.61 0 1.1.63 1.1 1.4M21 5v14c0 1.11-.89 2-2 2H5a2 2 0 0 1-2-2V5c0-1.1.9-2 2-2h14a2 2 0 0 1 2 2m-6.45 8.41c-.05-1.96-1.36-2.54-2.02-2.54c-1.12 0-1.67.66-1.67.66s.03-2.03 2.53-2v-1.2s-4.06-.39-4.09 4.33c-.03 4.2 3.47 3.34 3.47 3.34s1.84-.53 1.78-2.59" />
				</svg>
			);
		case 8:
			return (
				<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24">
					<path fill="currentColor" d="M12 2c-.5 0-1 .19-1.41.59l-8 8c-.79.78-.79 2.04 0 2.82l8 8c.78.79 2.04.79 2.82 0l8-8c.79-.78.79-2.04 0-2.82l-8-8C13 2.19 12.5 2 12 2m0 6.25c1.31 0 2.38.95 2.38 2.13c0 .69-.38 1.3-.94 1.69c.7.39 1.16 1.06 1.16 1.83c0 1.22-1.16 2.2-2.6 2.2s-2.6-.98-2.6-2.2c0-.77.46-1.44 1.16-1.83c-.56-.39-.93-1-.93-1.69c0-1.18 1.06-2.13 2.37-2.13m0 1.25c-.5 0-.9.45-.9 1s.4 1 .9 1s.9-.45.9-1s-.4-1-.9-1m0 3.15c-.61 0-1.1.49-1.1 1.1s.49 1.1 1.1 1.1s1.1-.49 1.1-1.1s-.49-1.1-1.1-1.1" />
				</svg>
			);
		case 10:
			return (

				<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24">
					<path fill="currentColor" d="M12 2c-.5 0-1 .19-1.41.59l-8 8c-.79.78-.79 2.04 0 2.82l8 8c.78.79 2.04.79 2.82 0l8-8c.79-.78.79-2.04 0-2.82l-8-8C13 2.19 12.5 2 12 2m2.07 6.21c1.43 0 2.57 1.15 2.57 2.57v2.64c0 1.42-1.14 2.58-2.57 2.58s-2.57-1.16-2.57-2.58v-2.64a2.57 2.57 0 0 1 2.57-2.57m-3.71.2h.14V16H9v-5.79l-1.78.55V9.53zm3.7 1.24c-.59 0-1.06.48-1.06 1.06v2.79c0 .57.47 1.04 1.06 1.04c.58 0 1.08-.48 1.08-1.04v-2.79c0-.59-.5-1.06-1.08-1.06" />
				</svg>
			);
		case 12:
			return (
				<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24">
					<path fill="currentColor" d="M12 2L1.5 9.64L5.5 22h13l4-12.36zm-1.5 15H8.89v-6.11L7 11.47v-1.28L10.31 9h.19zm6.5 0h-5.34v-1.09s3.57-3.46 3.57-4.51c0-1.28-1.05-1.15-1.05-1.15c-.68.05-1.18.62-1.18 1.3h-1.56c.06-1.46 1.28-2.61 2.83-2.55c2.47 0 2.5 1.85 2.5 2.3c0 1.77-3.19 4.47-3.19 4.47l3.42-.02z" />
				</svg>
			);
		case 20:
			return (
				<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24">
					<path fill="currentColor" d="m20.47 6.62l-7.9-4.44C12.41 2.06 12.21 2 12 2s-.41.06-.57.18l-7.9 4.44c-.32.17-.53.5-.53.88v9c0 .38.21.71.53.88l7.9 4.44c.16.12.36.18.57.18s.41-.06.57-.18l7.9-4.44c.32-.17.53-.5.53-.88v-9c0-.38-.21-.71-.53-.88m-9.02 9.34l-5.14-.03v-1.02s3.43-3.33 3.44-4.34c0-1.24-1.02-1.11-1.02-1.11s-.98.04-1.09 1.25l-1.5.05s.04-2.5 2.69-2.5c2.37 0 2.4 1.78 2.4 2.24c0 1.68-3.08 4.27-3.08 4.27l3.3-.01zm6.05-2.46c0 1.4-1.15 2.55-2.57 2.55c-1.43 0-2.57-1.15-2.57-2.55v-2.66c0-1.42 1.14-2.57 2.57-2.57s2.57 1.15 2.57 2.57zM16 10.77v2.76c0 .59-.5 1.07-1.08 1.07s-1.06-.48-1.06-1.07v-2.76c0-.59.48-1.06 1.06-1.06s1.08.47 1.08 1.06" />
				</svg>

			);
		case 100:
			return (
				<div></div>
			);
		default:
			return <div></div>;
	}
}