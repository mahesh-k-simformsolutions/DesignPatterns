namespace Builder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IBuilder builder = new CarBuilder();
            Director.ConstructSportsCar(builder);
            _ = builder.Build();
        }
    }
}
