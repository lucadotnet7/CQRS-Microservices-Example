using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.API.Book.DTOs;
using StoreServices.API.Book.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StoreServices.API.Book.Application
{
    public class Get
    {
        public class BookList : IRequest<List<BookDto>>
        { }

        public class Handler : IRequestHandler<BookList, List<BookDto>>
        {
            private readonly BookContext _context;
            private readonly IMapper _mapper;

            public Handler(BookContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<BookDto>> Handle(BookList request, CancellationToken cancellationToken)
            {
                return _mapper.Map<List<Models.Book>, List<BookDto>>(await _context.Books.ToListAsync());
            }
        }
    }
}
