using EasyNetQ;
using Saga.PaymentService.Data;

namespace Saga.PaymentService.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IBus _bus;
        private readonly AppDbContext _context;

        public PaymentService(IBus bus, AppDbContext context)
        {
            _bus = bus;
            _context = context;
        }
        public int MakePayment(int orderId, decimal totalAmount)
        {
            Payment payment = new()
            {
                OrderId = orderId,
                TotalAmount = totalAmount
            };
            _ = _context.Payments.Add(payment);
            return _context.SaveChanges();
        }
    }
}
