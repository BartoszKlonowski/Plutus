using App.Models;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;


namespace App.ViewModels
{
    /// <summary>
    /// Class representing the model for the View in the MVVM design pattern
    /// This class represents the Chart (line diagram) adjusted to the needs of View
    /// It implements:
    /// INotifyPropertyChanged - so it's possible the commands to react and react on commands
    /// IObserver - so it's possible to react on ITopic's activity
    /// </summary>
    public class ChartViewModel : INotifyPropertyChanged, IObserver
    {
        public ChartViewModel()
        {
            plot = new PlotModel
            {
                Title = "Wykaz stanu portfela"
            };

            CreatePlotModel();

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
            Title = "Kwota operacji wykonanej na portfelu (zł)",
            MarkerType = MarkerType.Circle,
            Color = OxyColors.Brown
        };

        public LineSeries Summary { get; } = new LineSeries
        {
            Title = "Stan portfela w danej operacji",
            MarkerType = MarkerType.Diamond,
            Color = OxyColors.LawnGreen
        };


        public void Update( ITopic topic, decimal amount, decimal accountMoney )
        {
            chart.Update( topic, amount );
            Operations.Points.Add( new DataPoint( chart.Operations.Last().ID, decimal.ToDouble(chart.Operations.Last().Amount) ) );
            Summary.Points.Add( new DataPoint( chart.Operations.Last().ID, decimal.ToDouble( accountMoney ) ) );
            OnPropertyChanged( nameof( Plot ) );
        }



        private void CreatePlotModel()
        {
            plot.Series.Add( Operations );
            plot.Series.Add( Summary );

            plot.Axes.Add( new LinearAxis
            {
                Title = "Kwota",
                Unit = "zł",
                TitleFontSize = 12,
                TitleFontWeight = FontWeights.Bold,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Solid,
                Position = AxisPosition.Left
            } );

            plot.Axes.Add( new LinearAxis
            {
                Title = "Numer operacji",
                TitleFontSize = 12,
                TitleFontWeight = FontWeights.Bold,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Solid,
                Position = AxisPosition.Bottom,
                AbsoluteMinimum = 0,
                AbsoluteMaximum = 100
            } );
        }


        private PlotModel plot;
        public readonly Chart chart;
    }
}
