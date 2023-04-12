namespace Builder
{
    public class Director
    {
        public static void ConstructSportsCar(IBuilder builder)
        {
            _ = builder.SetModel("Sports Car");
            _ = builder.SetColor("Red");
            _ = builder.SetYear(2015);
            _ = builder.SetSeatingCapacity(2);
            _ = builder.SetBodyType("Coupe");
            _ = builder.SetNumDoors(2);
            _ = builder.SetEngineType("V8");
            _ = builder.SetFuelType("Gasoline");
            _ = builder.SetNumCylinders(8);
            _ = builder.SetTransmission("Automatic");
            _ = builder.SetNumGears(6);
            _ = builder.SetHasSunroof(true);
            _ = builder.SetHasNavigation(false);
            _ = builder.SetHasBackupCamera(false);
            _ = builder.SetHasHeatedSeats(false);
            _ = builder.SetHasBluetooth(false);
            _ = builder.SetHasAutoClimateControl(false);
        }

        public static void ConstructSUV(IBuilder builder)
        {
            _ = builder.SetModel("SUV");
            _ = builder.SetColor("Black");
            _ = builder.SetYear(2015);
            _ = builder.SetSeatingCapacity(5);
            _ = builder.SetBodyType("SUV");
            _ = builder.SetNumDoors(4);
            _ = builder.SetEngineType("V6");
            _ = builder.SetFuelType("Gasoline");
            _ = builder.SetNumCylinders(6);
            _ = builder.SetTransmission("Automatic");
            _ = builder.SetNumGears(6);
            _ = builder.SetHasSunroof(false);
            _ = builder.SetHasNavigation(false);
            _ = builder.SetHasBackupCamera(false);
            _ = builder.SetHasHeatedSeats(false);
            _ = builder.SetHasBluetooth(false);
            _ = builder.SetHasAutoClimateControl(false);
        }
    }
}
