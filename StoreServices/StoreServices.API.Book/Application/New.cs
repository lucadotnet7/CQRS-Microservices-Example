using FluentValidation;
using MediatR;
using StoreServices.API.Book.Infrastructure;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StoreServices.API.Book.Application
{
    public class New
    {
        public class Execute : IRequest
        {
            public string Title { get; set; }
            public DateTime PublishAt { get; set; }
            public Guid AuthorRepresentative { get; set; }
        }

        public class ExecuteValidation : AbstractValidator<Execute> 
        {
            public ExecuteValidation()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.PublishAt).NotEmpty();
                RuleFor(x => x.AuthorRepresentative).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Execute>
        {
            private readonly BookContext _context;

            public Handler(BookContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                Models.Book book = new Models.Book
                {
                    Title = request.Title,
                    PublishAt = request.PublishAt,
                    AuthorRepresentative = request.AuthorRepresentative,
                };

                await _context.Books.AddAsync(book);
                int transactions = await _context.SaveChangesAsync();

                if (transactions > 0)
                    return Unit.Value;

                throw new Exception("El libro no pudo ser guardado correctamente.");
            }
        }
    }
}
