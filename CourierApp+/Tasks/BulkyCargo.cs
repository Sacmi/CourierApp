using System;

namespace CourierApp_.Tasks
{
    class BulkyCargo : SimpleCargo
    {
        public BulkyCargo(string name, int id, bool isFragile, double weight) : base(name, id, isFragile, weight)
        {
            if (weight < 5 || weight > 31.5)
                throw new ArgumentException("invalid weight");
        }

        public override double Price { 
            get
            {
                // пытался подогнать цену как у EMS
                double coefficient = 0;
                const double min = 295;

                if (this.Weight <= 10)
                {
                    coefficient = 12;
                }
                else if (this.Weight <= 20)
                {
                    coefficient = 22.1;
                }
                else if (this.Weight <= 31.5)
                {
                    coefficient = 28.8;
                }

                return Math.Round((this.Weight * coefficient) + min, 2);
            }
        }

        
    }
}
