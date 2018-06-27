using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XmlToSql.tool;

namespace XmlToSql.service
{
    class ImageFile : IDataType
    {
        String appPath, fileType;
        Tool tool;
        public ImageFile()
        {
            tool = new Tool();
        }

        public void initialize(XmlNode node, String path)
        {
            this.appPath = path;
            this.fileType = getFileTypeFromParentNode(node);
        }

        public void process(String value)
        {
            tool.convertBase64StringToFile(value, this.appPath + string.Format("{0:yyyy-MM-dd_hh-mm-ss-fff}", DateTime.Now) + fileType);
        }

        private String getFileTypeFromParentNode(XmlNode node)
        {
            return ".gif";
        }
    }
}
