using App.Models;
using OxyPlot;
using OxyPlot.Series;
using System.ComponentModel;


namespace App.ViewModels
{
    public class ChartViewModel : INotifyPropertyChanged
    {
        public ChartViewModel()
        {
            plot = new PlotModel
            {
                Title = "Wykaz stanu portfela",
                Subtitle = $"Użytkownika: "
            };
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


        public void Update()
        {
            // Create two line series (markers are hidden by default)
            var series1 = new LineSeries { Title = "Series 1", MarkerType = MarkerType.Circle };
            series1.Points.Add( new DataPoint( 0, 0 ) );
            series1.Points.Add( new DataPoint( 10, 18 ) );
            series1.Points.Add( new DataPoint( 20, 12 ) );
            series1.Points.Add( new DataPoint( 30, 8 ) );
            series1.Points.Add( new DataPoint( 40, 15 ) );

            var series2 = new LineSeries { Title = "Series 2", MarkerType = MarkerType.Square };
            series2.Points.Add( new DataPoint( 0, 4 ) );
            series2.Points.Add( new DataPoint( 10, 12 ) );
            series2.Points.Add( new DataPoint( 20, 16 ) );
            series2.Points.Add( new DataPoint( 30, 25 ) );
            series2.Points.Add( new DataPoint( 40, 5 ) );
        }


        private PlotModel plot;
        private Chart chart;
    }
}
