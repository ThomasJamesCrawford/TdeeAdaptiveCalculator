using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TDEE
{
    class TdeeGraphViewModel : INotifyPropertyChanged
    {
        private List<LineSeriesData> _avgLineSeriesData;
        public List<LineSeriesData> AvgLineSeriesData
        {
            get
            {
                return _avgLineSeriesData;
            }
            set
            {
                _avgLineSeriesData = value;
                OnPropertyChanged("AvgLineSeriesData");
            }
        }

        private List<LineSeriesData> _lineSeriesData;
        public List<LineSeriesData> LineSeriesData
        {
            get
            {
                return _lineSeriesData;
            }
            set
            {
                _lineSeriesData = value;
                OnPropertyChanged("LineSeriesData");
            }
        }

        public TdeeGraphViewModel()
        {
            TdeeData d = new TdeeData();
            AvgLineSeriesData = d.AvgTdeeLineData.List;
            LineSeriesData = d.Weeks.GetAsLineSeriesData();
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
