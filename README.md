# FrostyAutoRunPlugin
A plugin for [Frosty Toolsuite v1](https://github.com/CadeEvs/FrostyToolsuite) to auto run files

*There are a lot of things I can't do. Plz help me if you want. Any contributions are welcome.*

## Install
Download from [GitHub Release](https://github.com/shoushou1106/FrostyAutoRunPlugin/releases) and put the .dll file in `Plugins` folder under **Frosty**. This plugin both support Editor and Mod Manager

## How to use
- Open `Tools -> Options -> Auto Run Options` to config this plugin.
- `Enable Auto Run` will not run anythig, it only enables other options
- `Enable Pre Launch` will run files in `PreLaunch` folder, subfolders will be ignored
- `Enable Post Launch` will run files in `PostLaunch` folder, subfolders will be ignored
- Click on option to see the specific details, such as the folder to search for.
- If you need to run a program as administrator, you can try use shortcut (.lnk). You can even use Python if you need
- Files are sorted by name, as you see in File Explorer. If you have requirements on the order, you can add a prefix to the file name, such as `1_` `2_` `A_` `B_`
- If you encounter an exception, don't worry. If your Frosty is not closed after clicking Ok, it means it is not important. But if your Frosty is closed, please be sure to submit an issue!

## Others
- `Pack Directory` option is experimental. May cause unknown errors. If you encounter it, welcome to submit issues
- `Pack Directory` might not work for Frosty Editor
- You can use `Tools -> Manage ModData` to find the pack directory (1.0.6.3 or newer), but create shortcut (in Manage ModData) do not support Auto Run
