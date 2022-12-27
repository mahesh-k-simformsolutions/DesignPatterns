using MediatR;
using RepositoryPattern.Data.Entity;
using RepositoryPattern.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSDesignPattern.Commands
{
    public static class AddProduct
    {
        // Command
        public record Command(Product product) : IRequest<int>;

        // Handler
        public class Handler : IRequestHandler<Command, int>
        {
            public IProductRepository _productRepository { get; }
            public Handler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                _productRepository.Add(request.product);
                return request.product.Product_PK;
            }
        }
    }
}