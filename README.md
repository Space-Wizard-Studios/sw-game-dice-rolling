# sw-game-dice-roll

## Useful commands

Install packages and run the prototype game.

```shell
cd game-prototype
npm i
npm run dev
```

## Game logic

The game consists in phases:

### Build Setup

- Player gets 3 random characters and can choose 1 to add to it's army.
- Player allocates dices to the character chosen, with predefined actions accordingly to the dice options.

### Battle Setup

- Enemies are deployed and shown to the player.
- Player must select what characters they will send to battle.

### Battle

- Both player's and enemy's characters are sorted accordingly to their speed.
- Enemies reveals it's intent of actions.
- Player rolls for each character with their dices, following the characters speeds.
- After rolling for every character, the player then can allocate one of the dices rolled and assign a target for it.
- If two dices are rolled equal, an extra action will be available to be allocated

### Battle End
