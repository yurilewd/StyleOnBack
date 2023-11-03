## Summary
This adds your current movestyle to your back when not currently in use, furthermore you will also keep the BMX and skateboard in your hand when boosting.

## Notes
By default this might clip through your character and should be manually tuned with the config. In some cases with custom characters they may not have the appropriate bone to attach to and that will also need to be adjusted.

## Installation
 - Ensure you have BepInEx 5.4.21 installed, if you do not have that installed you can find it [here](https://github.com/BepInEx/BepInEx/releases/tag/v5.4.21)
 - Navigate to the Bomb Rush Cyberfunk folder, if you have the steam version it is located at this path "Program Files\Steam\steamapps\common\BombRushCyberfunk"
 - Place the StyleOnBack.dll into the \BepInEx\plugins folder, if you have BepInEx installed correctly this folder should already exist
 - Launch the game<br>

 - Alternatively you can use r2modman and let that handle the entire process for you, it can be found [here](https://thunderstore.io/c/bomb-rush-cyberfunk/p/ebkr/r2modman/)

## Configuration
I highly recommend downloading [BepInEx Configuration Manager](https://github.com/BepInEx/BepInEx.ConfigurationManager), this will allow you to edit the config while in game and even has a setting for adjusting the position in real time, this entire configuration section will assume you're using it. 

To begin adjusting the position of your movestyle open the configuration manager with the F1 key, find the StyleOnBack section and expand it, optionally you can disable advanced settings with the checkbox in the top of the configuration manager window. From that point on you just want to enable placement mode and adjust the global position, rotation, and scale of your movestyle. You will likely be working with pretty small numbers in most cases and keep in mind negatives are valid, so if your movesetyle is slighting clipping inside your character you might for example adjust the z value of global position by -0.05 to move it just a bit out. Make sure to disable placement mode after you're finished otherwise your movestyle will be permanently on your back. This is all saved automatically so no need to worry about losing it when closing the game. 

More advanced configuration will not be covered here, but adjusting each piece of the bmx and each individual inline skate is an option and all of their transforms can be found in the advanced settings, this is also where you can find what bone they're each attached to.

## Known Issues
- After cutscenes like the taxi or cypher the movestyle will not be visible until switching to it once

## Planned Features
- Optional separate configurations for each character
- Adjustable movestyle boost position



