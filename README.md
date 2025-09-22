# Monsters vs Heroes RPG

A console-based role-playing game (RPG) written in C#, where heroes and monsters face off in turn-based battles.  
The game offers multiple modes, hero classes, monster types, weapons, effects, and leveling mechanics, making each battle dynamic and strategic.

## Features & Gameplay

### Game Modes
- **Campaign Mode**: Progress through a series of battles with increasing difficulty.  
- **Arena Mode**: Fight a single battle for quick practice or high scores.  
- **Custom Battle**: Choose your hero and opponent for a personalized challenge.

### Heroes
- Multiple classes: Warrior, Mage and Archer.  
- Each hero has unique **stats**: health, attack, defense, speed.  
- Different **weapons and abilities** with special effects (e.g., fire, poison, healing).  
- Heroes **gain experience and level up**, increasing stats and unlocking new abilities.

### Monsters
- Various monster types: Goblins, Dragons, Undead, etc.  
- Each has different **strengths, weaknesses, and behaviors**.  
- Some have special **effects** that trigger in battle (e.g., poison attacks, healing, debuffs).

### Combat System
- **Turn-based battles**: Heroes and monsters take turns attacking.  
- **Quick Attacks**: Certain abilities allow faster, lower-damage strikes.  
- Strategic choices: pick the right hero, weapon, or spell for each encounter.  
- Health and damage are calculated dynamically; battles end when one side’s health reaches zero.

### Player Experience
- Console-based interface with menus for choosing heroes, weapons, and abilities.  
- Text output shows attacks, effects, health remaining, and battle status.  
- Provides **feedback on each action**, helping the player plan strategies.  
- Progression through levels and challenges gives a sense of growth and achievement.


## Installation & Running
1. Clone the repository:
```bash
git clone https://github.com/Alcugan/HeroesVsMonsters-RPG.git
```
2. Navigate into the project folder
```bash
cd HeroesVsMonsters-RPG
```
3. Check the .NET version:
Make sure you have the 9th .NET SDK version installed. If not, got to the website and downlode it:
```bash
dotnet --version
```
4. Run the game

Start the game in the console:
```bash
dotnet run
```

You should see the console prompts and be able to play the game.
