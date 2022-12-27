using AbstractPattern.Interface;
namespace AbstractPattern.Concrete
{
    internal class OnePlus : IPhone
    {
        private readonly string model;
        private readonly string battery;
        public OnePlus(string model, string battery)
        {
            this.model = model;
            this.battery = battery;
        }
        public string Battery()
        {
            return battery;
        }

        public string Model()
        {
            return model;
        }
        public override string ToString()
        {
            return $"Iphone:{model}--{battery}";
        }
    }
}
