Sitecore SIM Data Folder Config Patch Pipeline Processor
========================================================

This is a pipeline processor for the Sitecore Instance Manager, that creates a *DataFolder.config* patch file in the *App_Config/Include* directory when a new instance is installed or reinstalled.

More information can be found on my blog [here](http://www.seanholmesby.com/datafolder-config-patch-for-sitecore-instance-manager-sim-installs/).

**Note: This build is for SIM 1.3 - Update 3 only. Don't use these files for any other versions as it'll cause installations to fail.**

### How to install ###
Copy the `__install files\Hedgehog.SIM.Pipelines.DLL` file to the root SIM directory (where you run SIM from).<br />
Copy the `__install files\Pipelines.config` file over the top of the default SIM `Pipelines.config` file in the root SIM directory.

**Note:** If you don't want to stomp the `Pipelines.config` file above, then manually your existing one with the following:-

Underneath the `<install><step><processor type="SIM.Pipelines.Install.SetDataFolder, SIM.Pipelines"/>` node.<br />
Add:- <br />
`<processor type="Hedgehog.SIM.Pipelines.Install.SetDataFolderPatch, Hedgehog.SIM.Pipelines" title="Setting data folder patch file" />`

Underneath the `<reinstall><step><processor type="SIM.Pipelines.Reinstall.SetDataFolder, SIM.Pipelines"/>` node.<br />
Add:- <br />
`<processor type="Hedgehog.SIM.Pipelines.Reinstall.SetDataFolderPatch, Hedgehog.SIM.Pipelines" title="Setting data folder patch file" />`

### How to Build ###
To build, copy the DLLs for SIM into the *References* folder. See the README.txt file in there.<br />
You can now build the solution.

### How to use ###
Once installed, restart SIM. Now all future installations will have a correct `DataFolder.config` patch file in the `App_Config\Include` folder.

