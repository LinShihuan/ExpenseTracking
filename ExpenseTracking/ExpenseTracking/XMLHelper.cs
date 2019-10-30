using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracking
{
    public class XMLHelper
    {
        public static string AddNode(string name, string value)
        {
            if (null == name || string.IsNullOrWhiteSpace(name) || null == value)
            {
                return string.Empty;
            }

            StringBuilder sbNode = new StringBuilder();
            sbNode.Append("<" + name + ">");
            sbNode.Append(value);
            sbNode.Append("</" + name + ">");
            return sbNode.ToString();
        }


        private string MakeNode(string name, string value)
        {
            if (string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder("<");
            sb.Append(name);
            sb.Append(">");
            sb.Append(value);
            sb.Append("</");
            sb.Append(name);
            sb.Append(">");
            return sb.ToString();
        }

        private string GetNodeValueFromXMLString(string nodeName, string xmlString)
        {
            string value = string.Empty;
            int startIndex = -1;
            int endIndex = -1;
            if (!String.IsNullOrEmpty(xmlString))
            {
                startIndex = xmlString.IndexOf("<" + nodeName + ">") + nodeName.Length + 2;
                endIndex = xmlString.IndexOf("</" + nodeName + ">");
                if (endIndex > startIndex && startIndex != -1)
                {
                    value = xmlString.Substring(startIndex, endIndex - startIndex);
                }
            }
            return value;
        }

        public void ParseXMLStream(string xmlStream)
        {
            if (string.IsNullOrWhiteSpace(xmlStream))
            {
                return;
            }
            string paramLine = GetNodeValueFromXMLString("Item", xmlStream);
            if (!string.IsNullOrWhiteSpace(paramLine))
            {
                string paramValue = GetNodeValueFromXMLString("ID", paramLine);
                if (!string.IsNullOrWhiteSpace(paramValue))
                {
                    //ID = int.Parse(paramValue);
                }
                paramValue = GetNodeValueFromXMLString("Date", paramLine);
                if (!string.IsNullOrWhiteSpace(paramValue))
                {
                    //DateString = paramValue;
                }
                paramValue = GetNodeValueFromXMLString("Amount", paramLine);
                if (!string.IsNullOrWhiteSpace(paramValue))
                {
                    //Amount = double.Parse(paramValue);
                }
                paramValue = GetNodeValueFromXMLString("Tag", paramLine);
                if (!string.IsNullOrWhiteSpace(paramValue))
                {
                    //Tag = paramValue;
                }                
            }
        }
    }
}
