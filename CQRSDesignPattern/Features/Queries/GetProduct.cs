using MediatR;
using RepositoryPattern.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSDesignPattern.Queries
{
    public static class GetProduct
    {
        // Query
        public record Query(int id) : IRequest<Response>;

        // Handler
        public class Handler : IRequestHandler<Query, Response>
        {
            public IProductRepository _productRepository { get; }
            public Handler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                RepositoryPattern.Data.Entity.Product product = await _productRepository.GetById(request.id);
                return product == null ? null : new Response(product.Product_PK, product.ProductName, product.Description);
            }
        }

        public record Response(int Id, string ProductName, string Description);
    }
}