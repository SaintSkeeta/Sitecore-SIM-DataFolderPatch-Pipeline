Sitecore SIM Data Folder Config Patch Pipeline
==============================================

This is a pipeline for the Sitecore Instance Manager, that creates a *DataFolder.config* patch file in the *App_Config/Include* directory when a new instance is installed or reinstalled.

More information can be found on my blog [here](http://www.seanholmesby.com/).

**Note: This build is for SIM 1.3 - Update 3 only. Don't use these files for any other versions as it'll cause installations to fail.**


### How to Build ###
To build, copy the DLLs for SIM into the *References* folder.<br />
If you don't wish to build, and just want the DLL, you can find it in the `__install files` directory.

**Note:** For this pipeline to run, you will need to add the following to SIM's *Pipelines.config* file:-

Underneath the `<install><step><processor type="SIM.Pipelines.Install.SetDataFolder, SIM.Pipelines"/>` node.<br />
Add:- <br />
`<processor type="Hedgehog.SIM.Pipelines.Install.SetDataFolderPatch, Hedgehog.SIM.Pipelines" title="Setting data folder patch file" />`

Underneath the `<reinstall><step><processor type="SIM.Pipelines.Reinstall.SetDataFolder, SIM.Pipelines"/>` node.<br />
Add:- <br />
`<processor type="Hedgehog.SIM.Pipelines.Reinstall.SetDataFolderPatch, Hedgehog.SIM.Pipelines" title="Setting data folder patch file" />`