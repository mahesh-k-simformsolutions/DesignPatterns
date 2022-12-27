using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using RepositoryPattern.Repository;

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
            public Handler(IProductRepository productRepository) => this._productRepository = productRepository;

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetById(request.id);
                return product == null ? null : new Response(product.Product_PK, product.ProductName, product.Description);
            }
        }

        public record Response(int Id, string ProductName, string Description);
    }
}