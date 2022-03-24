using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ExClalBit.automationpractice.com.Utils
{
    class UtilsXml 
    {
        public static string GetData(string data)
        {
            using (XmlReader reader = XmlReader.Create("automationpractice.com//Data//Config.xml"))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        if (reader.Name.ToString().Equals(data))
                        {
                            return reader.ReadString();
                        }
                    }

                }

            }
            return "Null";
        }
    }
}
