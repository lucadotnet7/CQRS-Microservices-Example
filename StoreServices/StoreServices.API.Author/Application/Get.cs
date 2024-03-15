using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.API.Author.Dtos;
using StoreServices.API.Author.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StoreServices.API.Author.Application
{
    public class Get
    {
        public class AuthorList : IRequest<List<AuthorDto>>
        {
        }

        public class Handler : IRequestHandler<AuthorList, List<AuthorDto>>
        {
            private readonly AuthorContext _context;
            private readonly IMapper _mapper;

            public Handler(AuthorContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<AuthorDto>> Handle(AuthorList request, CancellationToken cancellationToken)
            {
                List<Models.Author> authors = await _context.Authors.ToListAsync();
                List<AuthorDto> authorDtosList = _mapper.Map<List<Models.Author>, List<AuthorDto>>(authors);

                return authorDtosList;
            }
        }
    }
}
