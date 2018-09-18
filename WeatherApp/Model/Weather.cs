using System;
using System.ComponentModel;

namespace WeatherApp.Model 
{
    class Weather : INotifyPropertyChanged
    {
        private DateTime localObservationDateTime;
        public DateTime LocalObservationDateTime
        {
            get
            {
                return localObservationDateTime;
            }
            set
            {
                LocalObservationDateTime = value;
                OnPropertyChanged("LocalObservationDateTime");
            }
        }

        private string weatherText;

        public string WeatherText
        {
            get { return weatherText; }
            set
            {
                weatherText = value;
                OnPropertyChanged("WeatherText");
            }
        }

        private Temperature temperature;

        public Temperature Temperature
        {
            get { return temperature; }
            set
            {
                temperature = value;
                OnPropertyChanged("Temperature");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class Metric
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial
    {
        public int Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Temperature
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }
}