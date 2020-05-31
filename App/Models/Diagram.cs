using System.Collections.Generic;
using System.Linq;


namespace App.Models
{
    public interface IObserver
    {
        public void Update( ITopic topic, decimal amount );
    }


    public class Diagram : IObserver
    {
        public Diagram()
        {
            operations = new List<Operation>();
        }


        public List<Operation> operations
        {
            get;
            private set;
        }


        public void Update( ITopic topic, decimal amount )
        {
            if( topic is Wallet )
            {
                operations.Add( operations.Last().Clone( amount ) );
            }
        }
    }
}
