using AbstractPattern.Interface;
namespace AbstractPattern.Concrete
{
    internal class Samsung : IPhone
    {
        private readonly string model;
        private readonly string battery;
        public Samsung(string model, string battery)
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
            return $"Samsung:{model}--{battery}";
        }
    }
}
