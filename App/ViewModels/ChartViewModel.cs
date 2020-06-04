using App.Models;
using OxyPlot;
using OxyPlot.Series;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;


namespace App.ViewModels
{
    public class ChartViewModel : INotifyPropertyChanged, IObserver
    {
        public ChartViewModel()
        {
            plot = new PlotModel
            {
                Title = "Wykaz stanu portfela",
                Subtitle = $"Użytkownika: "
            };

            Operations.Points.Add( new DataPoint( 0, 0 ) );
            Summary.Points.Add( new DataPoint( 0, 0 ) );
            plot.Series.Add( Operations );
            plot.Series.Add( Summary );
            chart = new Chart();
        }


        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        protected virtual void OnPropertyChanged( string propertyName )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }


        public PlotModel Plot
        {
            get => plot;
            set
            {
                plot = value;
                OnPropertyChanged( nameof(Plot) ) ;
            }
        }


        public LineSeries Operations { get; } = new LineSeries
        {
            Title = "Operacje na portfelu",
            MarkerType = MarkerType.Circle,
            Color = OxyColors.Brown
        };

        public LineSeries Summary { get; } = new LineSeries
        {
            Title = "Stan portfela",
            MarkerType = MarkerType.Diamond,
            Color = OxyColors.LawnGreen
        };


        public void Update( ITopic topic, decimal amount, decimal accountMoney )
        {
            chart.Update( topic, amount );
            plot.Series.Remove( Operations );
            plot.Series.Remove( Summary );
            Operations.Points.Add( new DataPoint( chart.Operations.Last().ID, decimal.ToDouble(chart.Operations.Last().Amount) ) );
            Summary.Points.Add( new DataPoint( chart.Operations.Last().ID, decimal.ToDouble( accountMoney ) ) );
            plot.Series.Add( Summary );
            plot.Series.Add( Operations );
            OnPropertyChanged( nameof( Plot ) );
        }

        private PlotModel plot;
        public readonly Chart chart;
    }
}
