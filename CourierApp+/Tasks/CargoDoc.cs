using System;

namespace CourierApp_.Tasks
{
    public class CargoDoc
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public virtual double Price { get; }
        public double Weight { get; set; }
        public string Destination { get; set; }
        public bool IsFragile { get; set; }
        public StatusType Status { get; set; }
        public DateTime Time { get; set; }
    }
}