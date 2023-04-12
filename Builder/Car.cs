namespace Builder
{
    public class Car
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public int SeatingCapacity { get; set; }
        public string BodyType { get; set; }
        public int NumDoors { get; set; }
        public string EngineType { get; set; }
        public string FuelType { get; set; }
        public int NumCylinders { get; set; }
        public string Transmission { get; set; }
        public int NumGears { get; set; }
        public bool HasSunroof { get; set; }
        public bool HasNavigation { get; set; }
        public bool HasBackupCamera { get; set; }
        public bool HasHeatedSeats { get; set; }
        public bool HasBluetooth { get; set; }
        public bool HasAutoClimateControl { get; set; }

        public Car(string model, string color, int year, int seatingCapacity, string bodyType, int numDoors, string engineType, string fuelType, int numCylinders, string transmission, int numGears,bool hasSunroof, bool hasNavigation, bool hasBackupCamera, bool hasHeatedSeats, bool hasBluetooth, bool hasAutoClimateControl)
        {
        }
    }
}
