using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TDEE.ViewModel
{
    class WeightGraphViewModel : INotifyPropertyChanged
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

        public WeightGraphViewModel()
        {
            WeightData d = new WeightData();
            AvgLineSeriesData = d.WeightChangeItems.List;
            LineSeriesData = d.Weights.GetAsLineSeriesData();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
