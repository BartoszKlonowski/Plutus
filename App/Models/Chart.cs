using System;
using System.Collections.Generic;
using System.Linq;


namespace App.Models
{
    public interface IObserver
    {
        public void Update( ITopic topic, decimal amount );
    }


    public class Chart : IObserver
    {
        public Chart()
        {
            Operations = new List<Operation>();
        }


        public List<Operation> Operations
        {
            get;
            private set;
        }


        public void Update( ITopic topic, decimal amount )
        {
            if( topic is Wallet )
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
            operation.ID = 0;
            operation.Time = DateTime.Now;
            operation.Amount = amount;
            Operations.Add( operation );
        }
    }
}
