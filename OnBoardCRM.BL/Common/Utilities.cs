using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace OnBoardCRM.BL.Common
{
    public class Utilities
    {
        public static string XMLSerialize(object obj, Type type)
        {
            XmlSerializer xsSubmit = new XmlSerializer(type);
            string xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, obj);
                    xml = sww.ToString(); // Your XML
                }
            }

            return xml;
        }

        public static object XMLDeserialize(string req, Type type)
        {
            object retObject = null;
            XmlSerializer serializer = new XmlSerializer(type);

            StreamReader reader = new StreamReader(req);
            reader.ReadToEnd();
            retObject = serializer.Deserialize(reader);
            reader.Close();

            return retObject;
        }
    }
}
