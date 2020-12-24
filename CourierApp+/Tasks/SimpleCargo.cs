using System;
using System.Text.Json.Serialization;

namespace CourierApp_.Tasks
{
    public enum StatusType
    {
        Processing,
        Completed,
        Waiting
    }

    public abstract class SimpleCargo
    {
        public string Name { get; }
        public int ID { get; }
        [JsonIgnore]
        public abstract double Price { get; }
        public double Weight { get; }
        public string Destination { get; set; }
        public bool IsFragile { get; }
        public StatusType Status { get; set; }
        public DateTime Time { get; set; }

        protected SimpleCargo(string name, int id, bool isFragile, double weight)
        {
            if (name.Length == 0
                || id < 0
                || weight <= 0) throw new ArgumentException("invalid arguments");

            Name = name;
            ID = id;
            IsFragile = isFragile;
            Status = StatusType.Waiting;
            Weight = weight;
        }
    }
}
