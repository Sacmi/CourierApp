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
        private string _destination;
        public string Name { get; }
        public int ID { get; }
        [JsonIgnore] 
        public abstract double Price { get; }
        public double Weight { get; }

        public string Destination
        {
            get => _destination;
            set => _destination = value.Length != 0 ? value : _destination;
        }

        public bool IsFragile { get; }
        public StatusType Status { get; set; }
        public DateTime Time { get; set; }

        protected SimpleCargo(string name, int id, bool isFragile, double weight, string destination, DateTime time)
        {
            if (name.Length == 0) throw new ArgumentException("invalid name. name must not be empty");

            if (id < 0) throw new ArgumentException("invalid id. id must be greater than or equal zero");

            if (weight <= 0) throw new ArgumentException("invalid weight. weight must be greater than zero");

            if (destination.Length == 0)
                throw new ArgumentException("invalid destination. destination must not be empty");

            Name = name;
            ID = id;
            IsFragile = isFragile;
            Status = StatusType.Waiting;
            Weight = weight;
            Destination = destination;
            Time = time;
        }
    }
}