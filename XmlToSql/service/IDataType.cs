using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlToSql.service
{
    interface IDataType
    {
        void process(String value);
        void initialize(XmlNode node, String appPath);
    }
}
