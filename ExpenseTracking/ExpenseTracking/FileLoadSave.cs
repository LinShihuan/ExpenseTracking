using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExpenseTracking
{
    public interface IFileLoadSave
    {
        List<ExpenseItem> LoadFromFile(string fileName);
        bool SaveToFile(string fileName, List<ExpenseItem> items);
    }

    public class SerializerFileLoadSave : IFileLoadSave
    {
        public List<ExpenseItem> LoadFromFile(string fileName)
        {
            List<ExpenseItem> expenseItems = new List<ExpenseItem>();
            if (string.IsNullOrWhiteSpace(fileName) || !File.Exists(fileName))
            {
                throw new Exception("file doesn't exist.");
            }

            using (Stream s = File.OpenRead(fileName))
            {
                var ds = new DataContractSerializer(typeof(List<ExpenseItem>));
                expenseItems = (List<ExpenseItem>)ds.ReadObject(s);
            }

            return expenseItems;
        }

        public bool SaveToFile(string fileName, List<ExpenseItem> items)
        {
            if (items.Count == 0 || string.IsNullOrWhiteSpace(fileName))
            {
                return false;
            }

            var ds = new DataContractSerializer(typeof(List<ExpenseItem>));
            using (Stream s = File.Create(fileName))
            {
                ds.WriteObject(s, items);
            }

            return true;
        }
    }
    public class TxtFileLoadSave : IFileLoadSave
    {
        public List<ExpenseItem> LoadFromFile(string fileName)
        {
            List<ExpenseItem> expenseItems = new List<ExpenseItem>();
            if (string.IsNullOrWhiteSpace(fileName) || !File.Exists(fileName))
            {
                throw new Exception("file doesn't exist.");
            }

            string [] lines = File.ReadAllLines(fileName);
            foreach (string itemLine in lines)
            {
                string[] words = itemLine.Trim().Split(new char[] {','});
                if (words.Length != 4)
                {
                    continue;
                }
                ExpenseItem item = new ExpenseItem();
                int id;
                if (int.TryParse(words[0].Trim(), out id))
                {
                    item.ID = id;
                }
                else
                {
                    continue;
                }

                string tmpString = words[1].Trim();
                item.DateString = tmpString;
                double amount;
                if (double.TryParse(words[2].Trim(), out amount))
                {
                    item.Amount = amount;
                }
                else
                {
                    continue;
                }

                item.Tag = words[3].Trim();
                expenseItems.Add(item);
            }

            return expenseItems;
        }

        public bool SaveToFile(string fileName, List<ExpenseItem> items)
        {
            if (items.Count == 0 || string.IsNullOrWhiteSpace(fileName))
            {
                return false;
            }
            List<string> lines = new List<string>();
            foreach (var item in items)
            {
                lines.Add(item.ToTextString());
            }
            File.WriteAllLines(fileName, lines);
            return true;
        }
    }
    public class XMLFileLoadSave : IFileLoadSave
    {
        public List<ExpenseItem> LoadFromFile(string fileName)
        {
            List < ExpenseItem > expenseItems = new List<ExpenseItem>();
            if (string.IsNullOrWhiteSpace(fileName) || !File.Exists(fileName))
            {
                throw new Exception("file doesn't exist.");
            }
            XmlTextReader reader = new XmlTextReader(fileName);
            ExpenseItem item = null;
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (string.Equals(reader.Name, "Item", StringComparison.CurrentCultureIgnoreCase))
                    {
                        item = new ExpenseItem();
                    }
                    else if (item != null)
                    {
                        if (string.Equals(reader.Name, "ID", StringComparison.CurrentCultureIgnoreCase))
                        {
                            item.ID = int.Parse(reader.ReadElementString().Trim());
                        }

                        if (string.Equals(reader.Name, "Date", StringComparison.CurrentCultureIgnoreCase))
                        {
                            item.DateString = reader.ReadElementString().Trim();
                        }

                        if (string.Equals(reader.Name, "Amount", StringComparison.CurrentCultureIgnoreCase))
                        {
                            item.Amount = double.Parse(reader.ReadElementString().Trim());
                        }

                        if (string.Equals(reader.Name, "Tag", StringComparison.CurrentCultureIgnoreCase))
                        {
                            item.Tag = reader.ReadElementString().Trim();
                        }
                    }
                }

                if (reader.NodeType == XmlNodeType.EndElement && item != null)
                {
                    expenseItems.Add(item);
                    item = null;
                }
            }

            

            return expenseItems;
        }

        public bool SaveToFile(string fileName, List<ExpenseItem> items)
        {
            if (items.Count == 0 || string.IsNullOrWhiteSpace(fileName))
            {
                return false;
            }
            List<string> lines = new List<string>();
            lines.Add("<ExpenseTable>");
            foreach (var item in items)
            {
                lines.Add(item.ToXMLString());
            }
            lines.Add("</ExpenseTable>");
            File.WriteAllLines(fileName, lines);
            return true;
        }
    }
}
