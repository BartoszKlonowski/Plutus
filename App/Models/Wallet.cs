using System;
using System.Collections.Generic;


namespace App.Models
{
    public interface ITopic
    {
        public void Attach( IObserver observer );
        public void Detach( IObserver observer );

        public void Notify( decimal amount );
    }


    public class Wallet : ITopic
    {
        public void Income( decimal amount ) => Money += amount;

        public void Outcome( decimal amount ) => Money -= amount;


        public decimal Money
        {
            get => decimal.Round( money, 2 );
            private set
            {
                Notify( Math.Abs( money - value ) );
                money = value;
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
                observer.Update( this, amount );
            }
        }


        private decimal money;

        private List<IObserver> observers = new List<IObserver>();
    }
}
