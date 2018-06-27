using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlToSql.config;

namespace XmlToSql.tool
{
    class Tool
    {
        public Tool()
        {
        }

        public void convertBase64StringToFile(String base64Str, String fileName)
        {
            var bytes = Convert.FromBase64String(base64Str);
            using (var file = new FileStream(fileName, FileMode.Create))
            {
                file.Write(bytes, 0, bytes.Length);
                file.Flush();
            }
        }

        public int convertStringToInteger(String value)
        {
            return Int32.Parse(value);
        }

        public Double convertStringToDouble(String value)
        {
            return Double.Parse(value);
        }

        public DateTime convertStringToDateTime(String value)
        {
            return DateTime.ParseExact(value, AppConstant.DATE_FORMAT_1, CultureInfo.InvariantCulture);
        }
    }

   
}
