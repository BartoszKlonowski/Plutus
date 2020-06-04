﻿using App.Command;
using App.Models;
using System.ComponentModel;
using System.Windows.Input;

namespace App.ViewModels
{
    public class WalletViewModel : INotifyPropertyChanged
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


        private Wallet wallet;
    }
}
