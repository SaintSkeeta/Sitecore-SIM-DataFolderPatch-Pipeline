using SIM.Base;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Hedgehog.SIM.Pipelines.Install
{
    public static class SetDataFolderPatchHelper
    {
        private const string dataFolderFilename = "DataFolder.config";

        public static void Process (string configPatchDirectoryPath, string dataFolderPath)
        {
            var doc = SetDataFolderPatchHelper.CreateDataFolderPatchConfig(dataFolderPath);
            using (var stringWriter = new StringWriter())
            {
                using (var xmlWriter = new XmlTextWriter(stringWriter))
                {
                    xmlWriter.Formatting = Formatting.Indented;
                    doc.WriteTo(xmlWriter);
                    xmlWriter.Flush();

                    File.WriteAllText(configPatchDirectoryPath + dataFolderFilename, stringWriter.GetStringBuilder().ToString());
                }
            }
        }

        private static XElement CreateDataFolderPatchConfig(string dataFolderPath)
        {
            Assert.ArgumentNotNull(dataFolderPath, "dataFolderPath");

            XNamespace ns = "http://www.sitecore.net/xmlconfig/";
            XElement configuration = new XElement("configuration",
                new XAttribute(XNamespace.Xmlns + "patch", "http://www.sitecore.net/xmlconfig/"), "");

            var sitecore = new XElement("sitecore", "");
            configuration.Add(sitecore);

            var scvariable = new XElement("sc.variable", "");
            sitecore.Add(scvariable);

            scvariable.Add(new XAttribute("name", "dataFolder"));

            var patchattribute = new XElement(ns + "attribute");
            scvariable.Add(patchattribute);

            patchattribute.Add(new XAttribute("name", "value"));
            patchattribute.SetValue(dataFolderPath);

            return configuration;
        }
    }
}
