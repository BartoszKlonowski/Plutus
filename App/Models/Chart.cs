using App.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;


namespace App.Models
{
    /// <summary>
    /// IObserver interface forces the class to implement the method that will allow to react on ITopic activity
    /// This method is called by ITopic when Notify() occurs
    /// </summary>
    public interface IObserver
    {
        public void Update( ITopic topic, decimal amount, decimal accountMoney );
        public Operation Update( ITopic topic, int operationID );
    }


    public class Chart
    {
        public Chart()
        {
            Operations = new ObservableCollection<Operation>();
        }


        public ObservableCollection<Operation> Operations
        {
            get;
            private set;
        }


        public void Update( ITopic topic, decimal amount )
        {
            if( topic is WalletViewModel )
            {
                if( Operations.Any() )
                    Operations.Add( Operations.Last().Clone( amount ) );
                else
                    AddFirstElement( amount );
            }
        }


        private void AddFirstElement( decimal amount )
        {
            var operation = new Operation();
            operation.UserName = User.Instance.Name;
            operation.ID = 0;
            operation.Time = DateTime.Now;
            operation.Amount = amount;
            Operations.Add( operation );
        }
    }
}
