using System;

namespace CourierApp_.Tasks
{
    internal class SmallCargo : SimpleCargo
    {

        public override double Price 
        { 
            get
            {
                // пытался подогнать цену как у EMS
                const double minCost = 300; // минималка до килограмма

                return Weight <= 1 ? minCost : Math.Round(minCost + Weight * 10, 2);
            }
        }

        public SmallCargo(string name, int id, bool isFragile, double weight, string destination, DateTime time) : base(name, id, isFragile, weight, destination, time)
        {
            if (weight >= 5)
                throw new ArgumentException("invalid weight");
        }
    }
}
