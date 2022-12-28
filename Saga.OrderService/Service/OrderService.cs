using EasyNetQ;
using Saga.Events;
using Saga.OrderService.Data;
using System.Threading.Tasks;

namespace Saga.OrderService.Service
{
    public class OrderService : IOrderService
    {
        private readonly IBus _bus;
        private readonly AppDbContext _context;

        public OrderService(IBus bus, AppDbContext context)
        {
            _bus = bus;
            _context = context;
        }

        public async Task<int> CreateOrderAsync(Order order)
        {
            order.Status = OrderStatus.Pending;
            _ = _context.Orders.Add(order);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                OrderCreatedEvent message = new()
                {
                    OrderId = order.Id,
                    TotalAmount = order.Amount,
                    Status = order.Status.ToString(),
                    Product = order.Product
                };
                await _bus.PubSub.PublishAsync(message);
            }
            return result;
        }

        public Task CompleteOrderAsync(int orderId)
        {
            Order order = _context.Orders.Find(orderId);
            order.Status = OrderStatus.Completed;
            _ = _context.Orders.Update(order);
            _ = _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task RejectOrderAsync(int orderId, string reason)
        {
            Order order = _context.Orders.Find(orderId);
            order.Status = OrderStatus.Rejected;
            _ = _context.Orders.Update(order);
            _ = _context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
