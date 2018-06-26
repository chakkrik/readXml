using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XmlToSql.config;
using XmlToSql.tool;

namespace XmlToSql.service
{
    class XmlService
    {
        private Dictionary<String, List<String>> dataObj;
        private String attrName = "";
        private String appPath = "";
        private Tool tool;

        public XmlService()
        {
            dataObj = new Dictionary<String, List<String>>();
            tool = new Tool();
        }

        private void processData(String tag, String value)
        {
            if (isFileOrImg(tag))
            {
                String fileType = tag == "gif" ? AppConstant.IMG_TYPE : AppConstant.FILE_TYPE;
                tool.convertBase64StringToFile(value, this.appPath + string.Format("{0:yyyy-MM-dd_hh-mm-ss-fff}", DateTime.Now) + fileType);
            }
     
        }

        private String getData(XmlNode childNode)
        {
            if (childNode.ChildNodes.Count > 0)
            {
                extractChildNodes(childNode);
            }
            else
            {
                String value = childNode.Value;
                String parentTagName = childNode.ParentNode.Name;
                processData(parentTagName, value);
                dataObj[this.attrName].Add(value);
            }

            return childNode.Value;            
        }


        private void extractChildNodes(XmlNode childNode)
        {
            for (int i = 0; i < childNode.ChildNodes.Count; i++)
            {
                 getData(childNode.ChildNodes[i]);
            }
        }


        public void process(XmlDocument xmlDoc, String appPath)
        {
            this.appPath = appPath;
            dataObj = new Dictionary<String, List<String>>();
            List<String> tags = new List<String>();
            tags.Add("item");

            for (int j = 0; j < tags.Count; ++j)
            {
                XmlNodeList elemList = xmlDoc.GetElementsByTagName(tags[j]);
                int elemListCount = elemList.Count; ;
                for (int i = 0; i < elemListCount; ++i)
                {
                    if (elemList[i].ChildNodes.Count > 0)
                    {
                        String name = elemList[i].Attributes[0].Value;
                        this.attrName = name;
                        if (!dataObj.ContainsKey(name))
                        {
                            dataObj.Add(name, new List<string>());
                        }
                        extractChildNodes(elemList[i]);
                        //Console.WriteLine(name + " => ");
                        //var value = dataObj[name];
                        //foreach(var v in value)
                        //{
                        //    Console.WriteLine(v);
                        //}
                    }
                    else
                    {
                        Console.WriteLine(elemList[i].Attributes[0].Value + " => ");
                    }
                }
            }
            //dbHelper.inertToDB();
        }

        private Boolean isFileOrImg(String tagName)
        {
            return AppConstant.FILETAGS.Contains(tagName);
        }
    }
}
