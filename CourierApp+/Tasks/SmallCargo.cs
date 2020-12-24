using System;

namespace CourierApp_.Tasks
{
    class SmallCargo : SimpleCargo
    {
        public SmallCargo(string name, int id, bool isFragile, double weight) : base(name, id, isFragile, weight)
        {
            if (weight >= 5)
                throw new ArgumentException("invalid weight");
        }

        public override double Price 
        { 
            get
            {
                // пытался подогнать цену как у EMS
                const double minCost = 300; // минималка до килограмма

                if (this.Weight <= 1)
                {
                    return minCost;
                }

                return Math.Round(minCost + (this.Weight * 10), 2);
            }
        }

    }
}
