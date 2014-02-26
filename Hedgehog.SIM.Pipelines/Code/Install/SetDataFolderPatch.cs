using SIM.Base;
using SIM.Pipelines.Install;

namespace Hedgehog.SIM.Pipelines.Install
{
    public class SetDataFolderPatch : InstallProcessor
    {
        protected override void Process(InstallArgs args)
        {
            Assert.ArgumentNotNull(args, "args");

            string folderDirectory = args.WebRootPath + @"\App_Config\Include\";
            SetDataFolderPatchHelper.Process(folderDirectory, args.DataFolderPath);
        }
    }
}
