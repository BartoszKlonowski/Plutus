using App.Command;
using App.Models;
using System.ComponentModel;
using System.Windows.Input;


namespace App.ViewModels
{
    /// <summary>
    /// Class representing the model for the View in the MVVM design pattern
    /// This class represents the Wallet adjusted to the needs of View
    /// It implements:
    /// INotifyPropertyChanged - so it's possible the commands to react and react on commands
    /// ITopic - so it's possible to be observed by ChartViewModel
    /// </summary>
    public class WalletViewModel : INotifyPropertyChanged, ITopic
    {
        public WalletViewModel()
        {
            wallet = new Wallet();

            Income = new RelayCommand( IncomeWrap );
            Outcome = new RelayCommand( OutcomeWrap );
        }


        public event PropertyChangedEventHandler PropertyChanged = ( sender, e ) => { };

        protected virtual void OnPropertyChanged( string propertyName )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }


        private void IncomeWrap()
        {
            wallet.Income( Amount );
            OnPropertyChanged( nameof( Wallet ) );
        }
        public ICommand Income
        {
            get;
            private set;
        }


        private void OutcomeWrap()
        {
            wallet.Outcome( Amount );
            OnPropertyChanged( nameof( Wallet ) );
        }
        public ICommand Outcome
        {
            get;
            private set;
        }


        public string Wallet
        {
            get => wallet.ToString();
            set => OnPropertyChanged( nameof(Wallet) );
        }


        public decimal Amount
        {
            get;
            set;
        }


        public void AttachObserverToWallet( IObserver observer )
        {
            wallet.Attach( observer );
        }

        public void Attach( IObserver observer ) => wallet.Attach( observer );

        public void Detach( IObserver observer ) => wallet.Detach( observer );

        public void Notify( decimal amount ) => wallet.Notify( amount );


        private Wallet wallet;
    }
}
