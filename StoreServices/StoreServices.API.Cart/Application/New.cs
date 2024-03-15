using FluentValidation;
using MediatR;
using StoreServices.API.Cart.Infrastructure;
using StoreServices.API.Cart.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StoreServices.API.Cart.Application
{
    public class New
    {
        public class Execute : IRequest
        {
            public DateTime? CreatedAt { get; set; }
            public List<int> Products { get; set; }
        }

        public class ExecuteValidation : AbstractValidator<Execute>
        {
            public ExecuteValidation() 
            {
                RuleFor(x => x.Products).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Execute>
        {
            private readonly CartContext _context;

            public Handler(CartContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                CartSession cartSession = new CartSession
                {
                    CreatedAt = request.CreatedAt,
                };

                await _context.CartSessions.AddAsync(cartSession);
                int transactions = await _context.SaveChangesAsync();

                if (transactions <= 0)
                    throw new Exception("No se pudo guardar la información del carrito correctamente.");

                foreach (var product in request.Products)
                {
                    CartSessionDetail cartSessionDetail = new CartSessionDetail
                    {
                        CreatedAt = DateTime.Now,
                        CartSessionId = cartSession.Id,
                        SelectedProduct = product
                    };

                    _context.CartSessionDetails.Add(cartSessionDetail);
                }

                transactions = await _context.SaveChangesAsync();

                if (transactions <= 0)
                    throw new Exception("No se pudo guardar el detalle del producto correctamente.");

                return Unit.Value;
            }
        }
    }
}
