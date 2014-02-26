using Hedgehog.SIM.Pipelines.Install;
using SIM.Base;
using SIM.Pipelines.Install;
using SIM.Pipelines.Reinstall;

namespace Hedgehog.SIM.Pipelines.Reinstall
{
    public class SetDataFolderPatch : ReinstallProcessor
    {
        protected override void Process(ReinstallArgs args)
        {
            Assert.ArgumentNotNull(args, "args");

            string folderDirectory = args.WebRootPath + @"\App_Config\Include\";
            SetDataFolderPatchHelper.Process(folderDirectory, args.DataFolderPath);
        }
    }
}
