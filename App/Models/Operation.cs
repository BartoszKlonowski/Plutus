using System;
using System.ComponentModel;


namespace App.Models
{
    /// <summary>
    /// IOperationPrototype implements the Prototype design pattern
    /// Each time new operation object is created the prototype patterns checks the previous element on the plot
    /// and creates new one according to it's properties.
    /// </summary>
    public interface IOperationPrototype
    {
        public Operation Clone();
        public Operation Clone( decimal amount );
    }


    /// <summary>
    /// Operation represents the single element on the plot that is created when Income/Outcome is made on the Wallet
    /// This class implements the INotifyPropertyChanged due to it's need to be displayed on the right panel.
    /// This seems to violates the MVVM pattern, but it's not - there's no logic for the view to display the Operation
    /// on the right panel. Moreover there're no adjustment needed to be made for this class to the View to display it.
    /// </summary>
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
