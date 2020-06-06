using System.ComponentModel;


namespace App.Models
{
    /// <summary>
    /// User class implements the Singleton design pattern. It is useful to have the User's data reachable anywhere,
    /// plus it's necessary to have ONLY ONE user's instance in the system.
    ///
    /// User also implements the INotifyPropertyChanged due to having it's data also displayed in the application
    /// so each time View reaches for those data it expects them to use PropertyChanged event.
    /// </summary>
    public class User : INotifyPropertyChanged
    {
        private User() { }

        public static User Instance
        {
            get
            {
                if( instance is null )
                    instance = new User();
                return instance;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged = ( sender, e ) => { };

        protected virtual void OnPropertyChanged( string propertyName )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }


        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged( nameof( Name ) );
            }
        }


        public decimal MaxAccountState
        {
            get => max;
            set
            {
                max = value;
                OnPropertyChanged( nameof( MaxAccountState ) );
            }
        }


        public decimal MinAccountState
        {
            get => min;
            set
            {
                min = value;
                OnPropertyChanged( nameof( MinAccountState ) );
            }
        }


        public void UpdateStats( decimal amount )
        {
            if( amount > MaxAccountState )
                MaxAccountState = amount;
            else if( amount < MinAccountState )
                MinAccountState = amount;
        }


        private static User instance;

        private decimal max;
        private decimal min;

        private string name;
    }
}
