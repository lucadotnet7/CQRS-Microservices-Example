using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.API.Author.Dtos;
using StoreServices.API.Author.Infrastructure;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreServices.API.Author.Application
{
    public class Filter
    {
        public class AuthorFiltered : IRequest<AuthorDto>
        {
            public Guid AuthorRepresentative { get; set; }
        }

        public class Handler : IRequestHandler<AuthorFiltered, AuthorDto>
        {
            private readonly AuthorContext _context;
            private readonly IMapper _mapper;

            public Handler(AuthorContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AuthorDto> Handle(AuthorFiltered request, CancellationToken cancellationToken)
            {
                Models.Author author = await _context.Authors
                                                .Where(x => x.AuthorRepresentative == request.AuthorRepresentative)
                                                .FirstOrDefaultAsync();
                
                if (author == null)
                    throw new Exception($"El usuario con id: {request.AuthorRepresentative} no existe.");
                    
                return _mapper.Map<AuthorDto>(author);
            }
        }
    }
}
