using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExpenseTracking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty MonthsProperty = DependencyProperty.Register(
            "Months",
            typeof(List<string>),
            typeof(MainWindow),
            new PropertyMetadata(new CultureInfo("en-US").DateTimeFormat.MonthNames.Take(12).ToList()));

        public List<string> Months
        {
            get { return (List<string>)this.GetValue(MonthsProperty); }

            set { this.SetValue(MonthsProperty, value); }
        }

        private ExpenseViewer _myViewer;

        public MainWindow()
        {
            InitializeComponent();
            _myViewer = new ExpenseViewer();
            this.DataContext = _myViewer;
        }

        public ExpenseViewer ViewModel
        {
            get { return _myViewer; }
        }

        private void DatagridExpense_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonViewUpdate_OnClick(object sender, RoutedEventArgs e)
        {
            if (datagridExpense.SelectedIndex >= 0)
            {
                //Update the item
                //validate the amount
                double amount = 0.0;
                if (!double.TryParse(textViewAmount.Text, out amount) || amount < 0)
                {
                    MessageBox.Show("Amount is invalid.");
                    return;
                }

                _myViewer.UpdateSelectedItem(amount, textViewTag.Text);
            }
        }

        private void ButtonAddExpense_OnClick(object sender, RoutedEventArgs e)
        {
            //Get amount, tag, datestring
            double amount = 0;

            if (!double.TryParse(_myViewer.AmountAdd, out amount) || amount <= 0)
            {
                MessageBox.Show("Amount is not valid");
                return;
            }

            if (!_myViewer.AddOneItem(datePickter.Text, amount, _myViewer.TagAdd))
            {
                MessageBox.Show("Please check the input.");
            }
            else
            {
                //Clear current
                _myViewer.AmountAdd = string.Empty;
                _myViewer.TagAdd = string.Empty;
                datePickter.Text = string.Empty;
            }

        }

        private void ButtonViewDelete_OnClick(object sender, RoutedEventArgs e)
        {
            if (null == _myViewer.SelectedExpenseItem)
            {
                return;
            }

            _myViewer.RemoveItemAt(datagridExpense.SelectedIndex);
        }

        private void MenuFile_OnClick(object sender, RoutedEventArgs e)
        {
            MenuItem mi = e.Source as MenuItem;

            switch (mi.Name)
            {
                case "menuOpenSerial":
                {
                    //Serialization
                    IFileLoadSave fileLoader = new SerializerFileLoadSave();
                    _myViewer.LoadExpenseItems(fileLoader, @"D:\Code\ExpenseTracking\ExpenseCase1.obj.xml");
                    break;
                }
                case "menuOpenXML":
                {
                    //XML
                    IFileLoadSave fileLoader = new XMLFileLoadSave();
                    _myViewer.LoadExpenseItems(fileLoader, @"D:\Code\ExpenseTracking\ExpenseCase1.txt.xml");
                    break;
                }
                case "menuOpenText":
                {
                    //Text
                    IFileLoadSave fileLoader = new TxtFileLoadSave();
                    _myViewer.LoadExpenseItems(fileLoader, @"D:\Code\ExpenseTracking\ExpenseCase1.txt");
                    break;
                }

                case "menuSaveSerial":
                {
                    //do something else
                    IFileLoadSave fileSaver = new SerializerFileLoadSave();
                    _myViewer.SaveExpenseItems(fileSaver, @"D:\Code\ExpenseTracking\ExpenseCase1.obj.xml");
                    break;
                }
                case "menuSaveXML":
                {
                    //XML
                    IFileLoadSave fileSaver = new XMLFileLoadSave();
                    _myViewer.SaveExpenseItems(fileSaver, @"D:\Code\ExpenseTracking\ExpenseCase1.txt.xml");
                    break;
                }
                case "menuSaveText":
                {
                    IFileLoadSave fileSaver = new TxtFileLoadSave();
                    _myViewer.SaveExpenseItems(fileSaver, @"D:\Code\ExpenseTracking\ExpenseCase1.txt");
                    break;
                }
                case "menuExit":
                {
                    //something else again

                    break;
                }

            }
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _myViewer.UpdateStatisData();
            plotView.InvalidatePlot();
        }
    }
    [ValueConversion(typeof(List<string>), typeof(List<string>))]
    public class MonthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //get the list of months from the object sent in    
            List<string> months = (List<string>)value;

            //manipulate the data index starts at 0 so add 1 and set to 2 decimal places
            if (months != null && months.Count > 0)
            {
                for (int x = 0; x < months.Count; x++)
                {
                    months[x] = (x + 1).ToString("D2") + " - " + months[x];
                }
            }

            return months;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
