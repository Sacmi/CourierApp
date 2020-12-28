using System;

namespace CourierApp_.Tasks
{
    internal class BulkyCargo : SimpleCargo
    {
        public override double Price { 
            get
            {
                // пытался подогнать цену как у EMS
                double coefficient = 0;
                const double min = 295;

                if (Weight <= 10)
                    coefficient = 12;
                else if (Weight <= 20)
                    coefficient = 22.1;
                else if (Weight <= 31.5) coefficient = 28.8;

                return Math.Round(Weight * coefficient + min, 2);
            }
        }
        
        public BulkyCargo(string name, int id, bool isFragile, double weight, string destination, DateTime time) : base(name, id, isFragile, weight, destination, time)
        {
            if (weight < 5 || weight > 31.5)
                throw new ArgumentException("invalid weight");
        }
    }
}
