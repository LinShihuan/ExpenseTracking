using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Wpf;
using LineSeries = OxyPlot.Series.LineSeries;

namespace ExpenseTracking
{

    public class StatisData : INotifyPropertyChanged
    {
        private int _selectedMonth = 0;

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public int SelectedMonth
        {
            get { return _selectedMonth; }
            set
            {
                if (value >= 0)
                {
                    _selectedMonth = value;
                    NotifyPropertyChanged("SelectedMonth");
                }
            }
        }

        private string _total = string.Empty;

        public string Total
        {
            get { return _total; }
            set
            {
                _total = value;
                NotifyPropertyChanged("Total");
            }
        }
        private PlotModel _xyPlotModel;

        public PlotModel XYPlotModel
        {
            get { return _xyPlotModel; }
            set { _xyPlotModel = value; }
        }

        public void UpdateDataPoints(double[] dates, double[] values)
        {
            if (dates == null || values == null)
            {
                return;
            }

            int size = dates.Length > values.Length ? dates.Length : values.Length;
            LineSeries series = new LineSeries();
            double totalAmount = 0.0;
            for (int i = 0; i < size; ++i)
            {
                series.Points.Add(new DataPoint(dates[i], values[i]));
                totalAmount += values[i];
            }
            _xyPlotModel.Series.Clear();
            _xyPlotModel.Series.Add(series);
            Total = totalAmount.ToString();
            NotifyPropertyChanged("XYPlotModel");
        }
        public StatisData()
        {
            _selectedMonth = 5;
            _xyPlotModel = new PlotModel();
            _xyPlotModel.Title = "Expense Daily Data";
        }
    }

    

}
