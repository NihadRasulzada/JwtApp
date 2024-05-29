using JwtApp.Back.Core.Application.Features.CQRS.Commands;
using JwtApp.Back.Core.Application.Interfaces;
using JwtApp.Back.Core.Domain;
using MediatR;

namespace JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IRepository<Product> _productRepository;
        public UpdateProductCommandHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                throw new ApplicationException($"Product with id {request.Id} not found");
            }

            product.Name = request.Name;
            product.Stock = request.Stock;
            product.Price = request.Price;
            product.CategoryId = request.CategoryId;

            await _productRepository.UpdateAsync(product);

            return Unit.Value;
        }
    }
}
