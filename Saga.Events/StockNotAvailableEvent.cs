namespace Saga.Events
{
    public class StockNotAvailableEvent
    {
        public string Product { get; set; }
        public int OrderId { get; set; }
    }
}
