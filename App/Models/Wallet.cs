using App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;


namespace App.Models
{
    /// <summary>
    /// Interface representing the object to be observed by another objects.
    /// Allows to attach and detach observers to the list
    /// and to notify about any action (in this case about amount of operation made on wallet)
    /// </summary>
    public interface ITopic
    {
        public void Attach( IObserver observer );
        public void Detach( IObserver observer );

        public void Notify( decimal amount );
        public void Notify( int operationID );
    }


    public class Wallet
    {
        public void Income( decimal amount ) => Money += amount;

        public void Outcome( decimal amount ) => Money -= amount;


        public decimal Money
        {
            get => decimal.Round( money, 2 );
            private set
            {
                decimal previousMoney = money;
                money = value;
                Notify( Math.Abs( previousMoney - value ) );
                User.Instance.UpdateStats( money );
            }
        }


        public override string ToString()
        {
            return string.Format( "{0:} zł", Money.ToString() );
        }


        public void Attach( IObserver observer ) => observers.Add( observer );

        public void Detach( IObserver observer ) => observers.Remove( observer );


        public void Notify( decimal amount )
        {
            foreach( var observer in observers )
            {
                observer.Update( new WalletViewModel(), amount, Money );
            }
        }


        public Operation Notify( int operationID )
        {
            /// For now we can assume that there's only one observer: Chart
            /// But we still need to check if any has subscribed
            if( observers.Any() )
                return observers.First().Update( new WalletViewModel(), operationID );
            else
                /// return incorrect data indicating there's an error:
                /// The fetch for Operation should not happen if there was no operation made yet
                return new Operation
                {
                    ID = -1,
                    UserName = "No user",
                    Amount = -1,
                    Time = DateTime.MinValue
                };
        }


        private decimal money;

        private List<IObserver> observers = new List<IObserver>();
    }
}
