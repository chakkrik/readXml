using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XmlToSql.tool;

namespace XmlToSql.service
{
    class DocumentFile : IDataType
    {
        String fileType, appPath;
        Tool tool;

        public DocumentFile()
        {
            tool = new Tool();
        }

        public void initialize(XmlNode node, String appPath)
        {
            this.appPath = appPath;
            this.fileType = getFileTypeFromParentNode(node);
        }

        public void process(String value)
        {
            tool.convertBase64StringToFile(value, this.appPath + string.Format("{0:yyyy-MM-dd_hh-mm-ss-fff}", DateTime.Now) + this.fileType);
        }

        private String getFileTypeFromParentNode(XmlNode node)
        {
            var attributes = node.ParentNode.Attributes;
            for(int i = 0; i < attributes.Count; ++i)
            {
                if(attributes[i].Name == "name")
                {
                    String[] fileType = attributes[i].Value.Split('.');
                    return "." + fileType[fileType.Length - 1];
                }
            }
            return ".pdf";
        }
    }
}
