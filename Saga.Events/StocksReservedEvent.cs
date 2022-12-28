namespace Saga.Events
{
    public class StocksReservedEvent
    {
        public int OrderId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
