# UnderRail Developers Console (Patch for version 1.2.0.20)
## Run (example)
```sh
This program will patch Underail 1.2.0.20 to enable the developers console using ~ (tilde) key
This program cannot harm your computer or the integrity of your files (even in error/crash)
Output is saved to a different file

Input your game resolution (My default 1920 x 1080)
Width (default 1920):

Height (default 1080):

Configured Resolution: 1920 x 1080

Input full path to underrail.exe (version 1.2.0.20)
Default: C:\Program Files (x86)\GOG Galaxy\Games\UnderRail\underrail.exe


Attempting to read C:\Program Files (x86)\GOG Galaxy\Games\UnderRail\underrail.exe

Game has been successfully patched and saved to:
C:\Program Files (x86)\GOG Galaxy\Games\UnderRail\underrail_console_enabled.exe

GoodBye!
```
## Installation
Requires .NET 8 framework (https://dotnet.microsoft.com/en-us/download/dotnet/8.0)   
Requires Underrail version 1.2.0.20
(I suggest to always keep a backup of Underrail.exe version 1.2.0.20)  
  
## Build
Automatic
Using Microsoft Visual Studio, open the UnderrailPatcher.sln

Manually:
Microsoft Visual Studio with C# and .NET 8 support packages  
Mono.Cecil packages (install with Nuget)  

## Run
Run UnderrailPatcher.exe and input the required resolution and game path values.
Defaults are: Width 1920, heigh 1080, path (path to underrail.exe in GOG folder)

The patch will take a few seconds to complete, and create a file in the target folder:
underrail_console_enabled.exe

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
