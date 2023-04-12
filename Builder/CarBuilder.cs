using System;

namespace Builder
{

    public class CarBuilder : IBuilder
    {
        private string _model;
        private string _color;
        private int _year;
        private int _seatingCapacity;
        private string _bodyType;
        private int _numDoors;
        private string _engineType;
        private string _fuelType;
        private int _numCylinders;
        private string _transmission;
        private int _numGears;
        private bool _hasSunroof;
        private bool _hasNavigation;
        private bool _hasBackupCamera;
        private bool _hasHeatedSeats;
        private bool _hasBluetooth;
        private bool _hasAutoClimateControl;

        public IBuilder SetModel(string model)
        {
            _model = model;
            return this;
        }
        public IBuilder SetColor(string color)
        {
            _color = color;
            return this;
        }
        public IBuilder SetYear(int year)
        {
            _year = year;
            return this;
        }
        public IBuilder SetSeatingCapacity(int seatingCapacity)
        {
            _seatingCapacity = seatingCapacity;
            return this;
        }
        public IBuilder SetBodyType(string bodyType)
        {
            _bodyType = bodyType;
            return this;
        }
        public IBuilder SetNumDoors(int numDoors)
        {
            _numDoors = numDoors;
            return this;
        }
        public IBuilder SetEngineType(string engineType)
        {
            _engineType = engineType;
            return this;
        }
        public IBuilder SetFuelType(string fuelType)
        {
            _fuelType = fuelType;
            return this;
        }
        public IBuilder SetNumCylinders(int numCylinders)
        {
            if (string.IsNullOrEmpty(_engineType))
            {
                throw new InvalidOperationException("Specifiy the Engine type");
            }

            _numCylinders = _engineType == "Dual jet" ? 4 : numCylinders;
            return this;
        }
        public IBuilder SetTransmission(string transmission)
        {
            _transmission = transmission;
            return this;
        }
        public IBuilder SetNumGears(int numGears)
        {
            _numGears = numGears;
            return this;
        }
        public IBuilder SetHasSunroof(bool hasSunroof)
        {
            _hasSunroof = hasSunroof;
            return this;
        }
        public IBuilder SetHasNavigation(bool hasNavigation)
        {
            _hasNavigation = hasNavigation;
            return this;
        }
        public IBuilder SetHasBackupCamera(bool hasBackupCamera)
        {
            _hasBackupCamera = hasBackupCamera;
            return this;
        }
        public IBuilder SetHasHeatedSeats(bool hasHeatedSeats)
        {
            _hasHeatedSeats = hasHeatedSeats;
            return this;
        }
        public IBuilder SetHasBluetooth(bool hasBluetooth)
        {
            _hasBluetooth = hasBluetooth;
            return this;
        }
        public IBuilder SetHasAutoClimateControl(bool hasAutoClimateControl)
        {
            _hasAutoClimateControl = hasAutoClimateControl;
            return this;
        }

        public Car Build()
        {
            return new Car(_model, _color, _year, _seatingCapacity, _bodyType, _numDoors, _engineType, _fuelType, _numCylinders, _transmission, _numGears, _hasSunroof, _hasNavigation, _hasBackupCamera, _hasHeatedSeats, _hasBluetooth, _hasAutoClimateControl);
        }
    }
}
