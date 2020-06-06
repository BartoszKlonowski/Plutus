using System;
using System.ComponentModel;

namespace App.Models
{
    public interface IOperationPrototype
    {
        public Operation Clone();
        public Operation Clone( decimal amount );
    }


    public class Operation : IOperationPrototype, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = ( sender, e ) => { };

        protected virtual void OnPropertyChanged( string propertyName )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }

        public int ID
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged( nameof( ID ) );
            }
        }


        public DateTime Time
        {
            get => time;
            set
            {
                time = value;
                OnPropertyChanged( nameof( time ) );
            }
        }


        public decimal Amount
        {
            get => amount;
            set
            {
                amount = value;
                OnPropertyChanged( nameof( amount ) );
            }
        }


        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged( nameof( UserName ) );
            }
        }


        public Operation Clone()
        {
            var clone = this.MemberwiseClone() as Operation;
            clone.ID++;
            clone.Time = DateTime.Now;
            clone.UserName = User.Instance.Name;

            return clone;
        }


        public Operation Clone( decimal amount )
        {
            var clone = Clone();
            clone.Amount = amount;

            return clone;
        }

        private string userName;
        private decimal amount;
        private DateTime time;
        private int id;
    }
}
