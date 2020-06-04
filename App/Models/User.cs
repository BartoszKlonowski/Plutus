using System.ComponentModel;


namespace App.Models
{
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
