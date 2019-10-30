using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ExpenseTracking
{
    public class ExpenseViewer : INotifyPropertyChanged
    {
        private string _tagAdd = string.Empty;
        public string TagAdd
        {
            get { return _tagAdd; }
            set
            {
                if (value != null)
                {
                    _tagAdd = value;
                }
                else
                {
                    _tagAdd = string.Empty;
                }
                NotifyPropertyChanged("TagAdd");
            }
        }

        private string _amountAdd = string.Empty;

        public string AmountAdd
        {
            get { return _amountAdd; }
            set
            {
                if (value != null)
                {
                    _amountAdd = value;
                }
                else
                {
                    _amountAdd = string.Empty;
                }
                NotifyPropertyChanged("AmountAdd");
            }
        }


        private string _userName = string.Empty;

        public string UserName
        {
            get { return _userName; }
        }

        private ExpenseData _expenseData = new ExpenseData();
        public ExpenseData ExpenseTable
        {
            get { return _expenseData; }
            set
            {
                _expenseData = value;
                NotifyPropertyChanged("ExpenseTable");
            }
        }

        private StatisData _statis = new StatisData();
        public StatisData Statis
        {
            get { return _statis; }
            set
            {
                _statis = value;
                NotifyPropertyChanged("Statis");
            }
        }

        public int UpdateStatisData()
        {
            DateTime firstDay = DateTime.Parse(string.Format("{0}-01-2019", _statis.SelectedMonth + 1));
            DateTime lastDay;
            if (_statis.SelectedMonth + 1 != 2)
            {
                lastDay = DateTime.Parse(string.Format("{0}-30-2019", _statis.SelectedMonth + 1));
            }
            else
            {
                lastDay = DateTime.Parse(string.Format("{0}-28-2019", _statis.SelectedMonth + 1));
            }

            List<ExpenseItem> items = new List<ExpenseItem>();
            foreach (ExpenseItem item in _expenseData.Items)
            {
                DateTime itemDate = DateTime.Parse(item.DateString);
                if (itemDate >= firstDay && itemDate <= lastDay)
                {
                    bool contained = false;
                    for (int i = 0; i < items.Count; ++i)
                    {
                        DateTime tmpDate = DateTime.Parse(items[i].DateString);
                        if (tmpDate == itemDate)
                        {
                            items[i].Amount += item.Amount;
                            contained = true;
                        }
                    }

                    if (!contained)
                    {
                        items.Add(item);
                    }
                }
            }

            if (items.Count > 0)
            {
                double[] dates = new double[items.Count];
                double[] values = new double[items.Count];
                for(int i = 0; i < items.Count; ++i)
                {
                    dates[i] = double.Parse(items[i].DateString.Split(new char[] {'/'})[1]);
                    values[i] = items[i].Amount;
                }

                _statis.UpdateDataPoints(dates, values);
            }
            NotifyPropertyChanged("Statis");
            return items.Count;
        }

        private ExpenseItem _selectedItem;

        public ExpenseItem SelectedExpenseItem
        {
            get { return _selectedItem; }
            set
            {
                if (value != null)
                {
                    _selectedItem = value;
                    NotifyPropertyChanged("SelectedExpenseItem");
                    IsSelected = true;
                }
                else
                {
                    IsSelected = false;
                }
            }
        }

        private bool _isSelected = false;

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                NotifyPropertyChanged("IsSelected");
            }
        }
        public ExpenseViewer()
        {
            _tagAdd = string.Empty;
            _amountAdd = string.Empty;
            _userName = System.Environment.UserName;
        }

        internal void RemoveItemAt(int selectedIndex)
        {
            _expenseData.RemoveItemAt(selectedIndex);
        }

        public bool LoadExpenseItems(IFileLoadSave fileLoader, string fileName)
        {
            List<ExpenseItem> expenseItems = fileLoader.LoadFromFile(fileName);
            if (null == expenseItems)
            {
                return false;
            }

            if (expenseItems.Count == 0)
            {
                MessageBox.Show("Unable to load any data.");
                return false;
            }

            UpdateStatisData();
            return _expenseData.LoadFromList(expenseItems);
        }

        public bool SaveExpenseItems(IFileLoadSave fileSaver, string fileName)
        {
            List<ExpenseItem> items = new List<ExpenseItem>(_expenseData.Items);
            return fileSaver.SaveToFile(fileName, items);
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

        public void UpdateSelectedItem(double amount, string tag)
        {
            if (null == _selectedItem)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(tag))
            {
                tag = string.Empty;
            }
            SelectedExpenseItem.Amount = amount;
            SelectedExpenseItem.Tag = tag;
            NotifyPropertyChanged(("SelectedExpenseItem"));
        }

        public bool AddOneItem(string dateString, double amount, string tag)
        {
            return _expenseData.AddOneItem(-1, dateString, amount, tag);
        }
    }
}
