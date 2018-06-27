using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
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
            if(appSettings.AllKeys.Length == 0) {
                this.paths.Add(Directory.GetCurrentDirectory() + "\\");
            }
            else 
            {
                foreach (var key in appSettings.AllKeys)
                {
                    this.paths.Add(appSettings[key]);
                }
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
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        doc.Load(appPath + Path.GetFileName(file));
                        xmlService.process(doc, appPath);
                        stopwatch.Stop();
                        Console.WriteLine("{0} converted successful time : {1} milliseconds", Path.GetFileName(file), stopwatch.ElapsedMilliseconds);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
        }


    }
}
