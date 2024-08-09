# sw-game-dice-roll

## Requirements

## Commands

Install packages and run the development environment.

```shell
cd game-prototype
npm i
npm run dev
```

## Game Logic

The game takes place in distinct stages:

### Build setup

- The player receives random characters and can choose 1 to add to his army.
  1. Characters have dice slots where the player allocates the dice there
  2. Characters can have combos that require specific actions

### Battle setup

- Enemies appear on the battlefield
- Player chooses which characters to send
- The order of turns is organized according to the speed of the characters

### Battle start

- Enemies show their intentions of actions
- For each character, the player rolls the allocated dice to see what they will do
- After the roll, the player can choose a rolled action and the target
  1. If there are combos, this option becomes available

### Battle End
