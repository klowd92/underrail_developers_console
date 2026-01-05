# UnderRail Developers Console (Patch for version 1.3.0.17)
This program will runtime-patch Underail 1.3.0.17 to enable the developers console using ~ (tilde) key

This program cannot harm your computer or the integrity of your files (even in error/crash)

## Run (example)
```sh

To run, unzip the release folder into your game folder, or simply unzip, and copy all files to your game folder.
Default: C:\Program Files (x86)\GOG Galaxy\Games\UnderRail\

So your game folder should contain the files:
0Harmony.dll
BepInEx.Core.dll
BepInEx.NET.Framework.Launcher.exe
etc..
BepInEx folder
etc..

Run BepInEx.NET.Framework.Launcher.exe
Enjoy!
```

## Build
Automatic
Using Microsoft Visual Studio, open the UnderrailPatcher.sln

## Run
Run BepInEx.NET.Framework.Launcher.exe
Defaults console values: Width 1920, heigh 1080

## Game
### Developers Console Commands  
Commands have a long name and a few aliased short names.  
I listed the long command name, since it is more descriptive of what the command does.  
  
```sh
goto <localeId>
    goto cc_arena (goes to core city arena)
listCommands
    list (shows all console commands)
loadTestModel
    (unsure)
playerExecuteJoblet <joblet> (asInitiator)
    (unsure)
playerGivAllePsiAbilities
    (gives player all psionic abilities)
playerGiveItem <itemDefinitionPath> <stacks> <quality>
    pgiveitem !supersteel 3 180 (gives player 3 stacks of supersteel at 180 quality)
playerGivePsiAbility <capability>
    pgivepsi Bilocation (give player Bilocation ability)
playerGiveSpecialAbility <capability>
    pgivesab Blitz (gives player Blitz ability (not the feat))
playerGiveSpecialAttack <capability>
    pgivesatt AimedShot (gives player aimed shot special attack)
playerGiveXp <amount>
    (give player experience)
playerKill
    (self kill)
playerListCooldowns
    plistcd (shows current cooldowns.. e.g. aimed shot 15000)
playerRemoveCooldown <cooldown>
    prmcd SA.tAimedShot (removes cooldown of aimed shot)
playerRemovePsiAbility <capability>
    (removes psi ability)
playerRemoveSpecialAbility <capability>
    (removes special ability)
playerRemoveSpecialAttack <capability>
    (removes special attack)
playerSetBaseAbility <ability> <value>
    psetstat Agility 18 (set agility to 18)
playerSetHealth <num>
    psethp 5000 (sets player health. Will not increase your max HP)
playerSetModel <string>
    (unsure)
playerSetSkill <skill> <value>
    psetskil Stealth 5000 (set stealth to 5000)
    psetskil Melee 5000 (set melee to 5000)
playerStatusEffect <statusEffect> <duration> <stacks>
    (hard to say since the status effects are name obfuscated)
readGlobalProperty <globalProperty(name|pattern)>
    readgp *tanner* (Shows all properties with the string tanner. Uses regular expressions. Yay!)
recordTimes <bool>
    recordTimes 1 (displayers draw and update times in top left)
reloadAllResources
    (not useful)
reloadAudioBank
    (not useful)
resetAll
    (not useful)
resetBlueprintsLibrary
    (not useful)
resetIconManager
    (not useful)
resetKnoweldgeManager
    (not useful)
revealGlobalMap
    (reveals the entire minimap 'm')
spawnVisualEffect <effectName>
    svx !cigarsmoke (spawns the cigarsmoke effect)
spawnEntity <entityPath>
    se !carnifex (spawns carnifx)
writeGlobalProperty
    writegp loc_cc_arenaStarted False 
```
### Examples
goto cc_arena (core city arena)  
goto xphw_exobase_tg2 (dark terrirtory final battle area)  
goto dc-tchb (deep caverns tchort fight)  
  
se !savageking (summons magnar)  
se !carnifex (summons carnifex)  
  
pgiveitem !lemurianegineersuit 2 (gives player 2x lemurian engineer suit)  
pgiveitem !allin 10  
  
pgivesatt kcs (gives player kneecap shot special attack)  
  
### Locations
All possible locations are in the game directory:  
Games\UnderRail\data\maps\locale\static  
  
cc_xxxxx - core city locations  
foxxxxx - foundry locations  
dc-xxxx - deep caverns locations  
lu...   - lower underrail locations  
and so on..  
  
### Characters
All possible characters (which you can summon with spawnEntity command) are in the directory:  
Games\UnderRail\data\rules\characters  
  
carnifex, ezra, tanner, savageking, cat, blackcrawler, yngwar, chopchop, camera, etc..  
