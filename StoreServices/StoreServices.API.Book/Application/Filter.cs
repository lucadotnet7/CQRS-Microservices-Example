using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.API.Book.DTOs;
using StoreServices.API.Book.Infrastructure;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreServices.API.Book.Application
{
    public class Filter
    {
        public class BookFiltered : IRequest<BookDto>
        {
            public int BookId { get; set; }
        }

        public class Handler : IRequestHandler<BookFiltered, BookDto>
        {
            private readonly BookContext _context;
            private readonly IMapper _mapper;
            public Handler(BookContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BookDto> Handle(BookFiltered request, CancellationToken cancellationToken)
            {
                Models.Book book = await _context.Books
                                            .Where(x => x.Id == request.BookId)
                                            .FirstOrDefaultAsync();

                if (book == null)
                    throw new Exception($"El libro con id {request.BookId} no existe.");
                
                return _mapper.Map<BookDto>(book);
            }
        }
    }
}
