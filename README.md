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

**Audio** :   Added sound effects *woodcreak 1* and *woodcreak 2*. Triggered at multiple points within the hallways before the dining room. Done through a box collider with an attached script, *soundTrigger*, to detect when the player walks over the trigger.

**Linear Interpolation** : Within script, *LoS_Light*, linear intrepretation is used to determine the intensity of light sources. Using distance from the player and the lightsource.

**Dot Product** : The dot product is used in script, *LoS*, to calculate whether or not the player is within an enemy's sight to trigger the gameover screen. The difference of the target.position and player transform.position is normalized to determine detection range.

**Particle Effects** : Added small dust particles when the character takes a step. Done by creating two animation event triggers within the walk cycle animation at the point where the player's foot touches the ground, and using the *FootstepEffect* script to play the correct particles for their corresponding events.

