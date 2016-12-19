# Power Dissipator

*FortressCraft Evolved mod*

[Steam Workshop](http://steamcommunity.com/sharedfiles/filedetails/?id=821616719)


## Building

1. Clone the source
2. Open the solution in Visual Studio
3. Open *Project Properties -> Reference Paths* and add new path `<Steam Library>/steamapps/common/FortressCraft/64/FC_64_Data/Managed`
4. Build
5. Create local mod in `<User Dir>/AppData/Local/ProjectorGames/FortressCraft/Mods/nailgunster2.PowerDissipator` dir with the following structure:

```
nailgunster2.PowerDissipator
|- <Version number>
   |- Xml
   |- mod.config
   |- plugin_nailgunster2.PowerDissipator.dll
|- SteamPreview.png
|- WorkshopFileId.config
```

6. Run FortressCraft Evolved and enable the mod.


## Thanks

Based on [FCE_Mod_Tutorial code](https://github.com/steveman0/FCE_Mod_Tutorial).
