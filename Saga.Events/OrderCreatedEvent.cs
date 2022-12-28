namespace Saga.Events
{
    public class OrderCreatedEvent
    {
        public int OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }

        public string Product { get; set; }
    }
}
