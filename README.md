# AcParamEditor
This is a lightweight param editor that supports several Armored Core games.  
If you are editing Armored Core 6 or later FromSoftware games such as the souls series please check out [Smithbox](https://github.com/vawser/Smithbox/releases) instead.  

# Requirements
Make sure the .NET 9.0 Desktop Runtime is installed or the program cannot run:  
https://dotnet.microsoft.com/en-us/download/dotnet/9.0  

Select ".NET Desktop Runtime"
Most users will need the x64 installer.  
This program has only been tested on Windows x64.  

# Supported Games
| Game                       |
| :------------------------- |
| Armored Core 4             |
| Armored Core For Answer    |
| Armored Core V             |
| Armored Core Verdict Day   |
| Armored Core 6             |
| Armored Core Formula Front |
| Chromehounds               |
| Enchanted Arms             |

# Adding Games
This tool supports adding games by adding their paramdefs to resources.  
All paramdef folders under resources are treated as individual games to load in the editor.  

The paramdef folders may contain XML format paramdefs, or raw paramdef files if read is supported for them.  
The editor can load any param as long as read is supported for them and they have paramdefs.  
Some older game param and paramdef formats are outdated and tricky to load, it's possible not all versions have been found.  
Newer games in the future may change the param or paramdef formats or extend them.  

Games such as Armored Core 6 started removing paramtypes from params, therefore,  
Tentative mappings for param file names to paramdef types are supported currently in a "TentativeParamType.csv" file in a game's def files.

# Building
This project requires the following libraries to be cloned alongside it.  
Place them in the same top-level folder as this project.  
These dependencies may change at any time.  
```
git clone https://github.com/soulsmods/SoulsFormatsNEXT.git  
```