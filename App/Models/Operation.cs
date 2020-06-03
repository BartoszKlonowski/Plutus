using System;


namespace App.Models
{
    public interface IOperationPrototype
    {
        public Operation Clone();
        public Operation Clone( decimal amount );
    }


    public class Operation : IOperationPrototype
    {
        public int ID
        {
            get;
            set;
        }


        public DateTime Time
        {
            get;
            set;
        }


        public decimal Amount
        {
            get;
            set;
        }


        public Operation Clone()
        {
            var clone = this.MemberwiseClone() as Operation;
            clone.ID++;
            clone.Time = DateTime.Now;

            return clone;
        }


        public Operation Clone( decimal amount )
        {
            var clone = Clone();
            clone.Amount += amount;

            return clone;
        }
    }
}
