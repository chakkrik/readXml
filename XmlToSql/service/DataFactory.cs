using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToSql.service
{
    class DataFactory
    {
        public IDataType getDataObject(String dataType)
        {
            switch (dataType)
            {
                case "gif":
                    return new ImageFile();
                case "filedata":
                    return new DocumentFile();
                default:
                    return new PrimiTiveDataType();
            }
        }
    }

}
