using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace ExpenseTracking
{
    [DataContract]
    public class ExpenseData : INotifyPropertyChanged
    {
        [DataMember] private ObservableCollection<ExpenseItem> _expenseItems;
        
        public ObservableCollection<ExpenseItem> Items
        {
            get { return _expenseItems; }
            set { _expenseItems = value; }
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
       
        public bool AddOneItem(int expID, string dateString, double amount, string tag)
        {
            if (expID < 0)
            {
                expID = GetNextID();
            }
            ExpenseItem item = new ExpenseItem(expID, dateString, amount, tag);
            if (!item.Validate())
            {
                return false;
            }

            if (ContainsID(expID))
            {
                return false;
            }
            _expenseItems.Add(item);
            return true;
        }

        public bool RemoveItemAt(int index)
        {
            if (_expenseItems.Count <= index)
            {
                return false;
            }
            _expenseItems.RemoveAt(index);
            return true;
        }

        private bool ContainsID(int expID)
        {
            foreach (var item in _expenseItems)
            {
                if (item.ID == expID)
                {
                    return true;
                }
            }

            return false;
        }

        public int GetNextID()
        {
            int maxID = 0;
            foreach (var item in _expenseItems)
            {
                if (item.ID > maxID)
                {
                    maxID = item.ID;
                }
            }

            maxID += 1;
            return maxID;
        }

        public bool LoadFromList(List<ExpenseItem> itemList)
        {
            bool ret = false;
            _expenseItems.Clear();
            foreach (ExpenseItem item in itemList)
            {
                if (!ContainsID(item.ID) && item.Validate())
                {
                    _expenseItems.Add(item);
                    ret = true;
                }
            }

            return ret;
        }

        public ExpenseData()
        {
            _expenseItems = new ObservableCollection<ExpenseItem>();
            //ExpenseItem item = new ExpenseItem();
            //item.ID = 1;
            //item.DateString = "06-06-2019";
            //item.Tag = "test1";
            //item.Amount = 1.2;
            //_expenseItems.Add(item);
            //item = new ExpenseItem();
            //item.ID = 2;
            //item.DateString = "05-06-2019";
            //item.Tag = "test2";
            //item.Amount = 2.2;
            //_expenseItems.Add(item);
            //item = new ExpenseItem();
            //item.ID = 3;
            //item.DateString = "07-06-2019";
            //item.Tag = "test3";
            //item.Amount = 3.2;
            //_expenseItems.Add(item);
            //Random random = new Random();
            //int index = 1;
            //for (int i = 1; i < 31; i++)
            //{
            //    ExpenseItem item = new ExpenseItem();
            //    item.ID = index++;
            //    item.DateString = string.Format("04/{0}/2019", i);
            //    item.Tag = "Auto populate";

            //    item.Amount = random.Next(10, 1000000) / 100.0;
            //    _expenseItems.Add(item);
            //}
            //for (int i = 1; i < 31; i++)
            //{
            //    ExpenseItem item = new ExpenseItem();
            //    item.ID = index++;
            //    item.DateString = string.Format("05/{0}/2019", i);
            //    item.Tag = "Auto populate";

            //    item.Amount = random.Next(10, 1000000) / 100.0;
            //    _expenseItems.Add(item);
            //}
            //for (int i = 1; i < 13; i++)
            //{
            //    ExpenseItem item = new ExpenseItem();
            //    item.ID = index++;
            //    item.DateString = string.Format("06/{0}/2019", i);
            //    item.Tag = "Auto populate";
                
            //    item.Amount = random.Next(10, 1000000) / 100.0;
            //    _expenseItems.Add(item);
            //}
        }
    }
}
