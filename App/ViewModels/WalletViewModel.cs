using App.Models;
using System.ComponentModel;


namespace App.ViewModels
{
    public class WalletViewModel : INotifyPropertyChanged
    {
        public WalletViewModel()
        {
            wallet = new Wallet();
        }


        public event PropertyChangedEventHandler PropertyChanged = ( sender, e ) => { };

        protected virtual void OnPropertyChanged( string propertyName )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
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


        private Wallet wallet;
    }
}
