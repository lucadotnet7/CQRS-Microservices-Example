using FluentValidation;
using MediatR;
using StoreServices.API.Author.Infrastructure;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StoreServices.API.Author.Application
{
    public class New
    {
        public class Execute : IRequest
        {
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public DateTime? BornDate { get; set; }
        }

        public class ExecuteValidations : AbstractValidator<Execute>
        {
            public ExecuteValidations()
            {
                RuleFor(x => x.Firstname).NotEmpty();
                RuleFor(x => x.Lastname).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Execute>
        {
            public readonly AuthorContext _context;

            public Handler(AuthorContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                Models.Author author = new Models.Author
                {
                    Firstname = request.Firstname,
                    Lastname = request.Lastname,
                    BornDate = request.BornDate,
                    AuthorRepresentative = Guid.NewGuid()
                };

                await _context.Authors.AddAsync(author);
                int transactions = await _context.SaveChangesAsync();

                if (transactions > 0)
                    return Unit.Value;

                throw new Exception("El registro no pudo ser insertado en la base de datos.");
            }
        }
    }
}
