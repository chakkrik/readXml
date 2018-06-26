using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XmlToSql.service;

namespace XmlToSql.XmlHelper
{
    class Xmlhelper
    {
        private XmlService xmlService;
        private List<String> paths= new List<String>();

        public Xmlhelper()
        {
            xmlService = new XmlService();
            initializePaths();
        }

        private List<String> initializePaths()
        {
            var appSettings = ConfigurationManager.AppSettings;
            foreach (var key in appSettings.AllKeys)
            {
                paths.Add(appSettings[key]);
            }
            return this.paths;
        }

        public void process()
        {
            foreach (var appPath in this.paths)
            {
                string[] XMLfiles = Directory.GetFiles(appPath, "*.xml");
                foreach (string file in XMLfiles)
                {
                    XmlDocument doc = new XmlDocument();
                    try
                    {
                        doc.Load(appPath + Path.GetFileName(file));
                        xmlService.process(doc, appPath);
                    }catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
        }


    }
}
