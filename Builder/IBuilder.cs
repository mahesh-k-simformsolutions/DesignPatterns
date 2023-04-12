namespace Builder
{
    public interface IBuilder
    {
        IBuilder SetModel(string model);
        IBuilder SetColor(string color);
        IBuilder SetYear(int year);
        IBuilder SetSeatingCapacity(int seatingCapacity);
        IBuilder SetBodyType(string bodyType);
        IBuilder SetNumDoors(int numDoors);
        IBuilder SetEngineType(string engineType);
        IBuilder SetFuelType(string fuelType);
        IBuilder SetNumCylinders(int numCylinders);
        IBuilder SetTransmission(string transmission);
        IBuilder SetNumGears(int numGears);
        IBuilder SetHasSunroof(bool hasSunroof);
        IBuilder SetHasNavigation(bool hasNavigation);
        IBuilder SetHasBackupCamera(bool hasBackupCamera);
        IBuilder SetHasHeatedSeats(bool hasHeatedSeats);
        IBuilder SetHasBluetooth(bool hasBluetooth);
        IBuilder SetHasAutoClimateControl(bool hasAutoClimateControl);
        Car Build();
    }

}
