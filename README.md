# **CS 410**
###### *Game Programming*


# Project 2

## Group Members and Tasks

| Group Members  | Project Tasks |
| ------------- |:-------------:|
| Luis Guzman-Cornejo      | Particle effects     |
| Braeden Reynolds      |   Linear Interpolation, Dot Product   |
| Sorin West      | Audio effects     |

## Description of Additions

**Audio** :   Added sound effects woodcreak 1 and 2. Triggered at multiple points within the hallways before the dining room. Done through a box collider with an attached script, *soundTrigger*, to detect when the player walks over the trigger.

**Linear Interpolation** : Within script, *LoS_Light*, linear intrepretation is used to determine the intensity of light sources. Using distance from the player and the lightsource.

**Dot Product** : The dot product is used in script, *LoS*, to calculate whether or not the player is within an enemy's sight to trigger the gameover screen.

**Particle Effects** : Added  a small dust particle occasionally triggered during the player's walkcycle animation.  Added a new particle effect simulating a trail that follows the ghost enemies as they float around. A new trigger around the ghosts dims the effect as the character gets near.

