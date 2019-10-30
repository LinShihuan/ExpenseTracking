using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ExpenseTracking
{
    [DataContract]
    public class ExpenseItem : INotifyPropertyChanged
    {
        [DataMember] private int _expID;
        [DataMember] private string _dateString;
        [DataMember] private double _amount;
        [DataMember] private string _tag;

        public ExpenseItem()
        {
            _expID = 0;
            _dateString = string.Empty;
            _amount = 0.0;
            _tag = string.Empty;
        }

        public ExpenseItem(int expID, string dateString, double amount, string tag)
        {
            _expID = expID;
            _dateString = dateString;
            _amount = amount;
            _tag = tag;
        }
        #region Properties
        public int ID
        {
            get { return _expID; }
            set
            {
                if (value > 0)
                {
                    _expID = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        public string DateString
        {
            get { return _dateString; }
            set
            {
                if (value != null && !String.IsNullOrWhiteSpace(value))
                {
                    //Check if it is date string
                    DateTime result;
                    if (DateTime.TryParse(value, out result))
                    {
                        _dateString = value;
                        NotifyPropertyChanged("DateString");
                    }
                }
            }
        }

        public double Amount
        {
            get { return _amount;}
            set
            {
                if (value > 0)
                {
                    _amount = value;
                    NotifyPropertyChanged("Amount");
                }
            }
        }

        public string Tag
        {
            get { return _tag; }
            set
            {
                if (value != null)
                {
                    _tag = value;
                    NotifyPropertyChanged("Tag");
                }
            }
        }
        #endregion

        public bool Validate()
        {
            if (_expID < 0)
            {
                return false;
            }

            DateTime tmpDate;
            if (_dateString == null || string.IsNullOrWhiteSpace(_dateString)
                                    || !DateTime.TryParse(_dateString, out tmpDate))
            {
                return false;
            }

            if (_amount <= 0)
            {
                return false;
            }

            if (_tag == null)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder sbResult = new StringBuilder();
            sbResult.Append(_expID.ToString());
            sbResult.Append(", ");
            if (_dateString != null)
            {
                sbResult.Append(_dateString);
            }
            sbResult.Append(", ");
            sbResult.Append(_amount.ToString());
            sbResult.Append(", ");
            if (_tag != null)
            {
                sbResult.Append(_tag);
            }

            return sbResult.ToString();
        }

        public string ToXMLString()
        {
            StringBuilder sbXML = new StringBuilder();
            sbXML.Append(XMLHelper.AddNode("ID", _expID.ToString()));
            sbXML.Append(XMLHelper.AddNode("Date", _dateString));
            sbXML.Append(XMLHelper.AddNode("Amount", _amount.ToString()));
            sbXML.Append(XMLHelper.AddNode("Tag", _tag));
            return XMLHelper.AddNode("Item", sbXML.ToString());
        }

        public string ToTextString()
        {
            StringBuilder sbText = new StringBuilder();
            sbText.Append(_expID.ToString());
            sbText.Append(",");
            sbText.Append(_dateString);
            sbText.Append(",");
            sbText.Append(_amount.ToString());
            sbText.Append(",");
            sbText.Append(_tag);
            return sbText.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
