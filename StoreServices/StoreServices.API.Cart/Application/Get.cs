using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using StoreServices.API.Cart.Dtos;
using StoreServices.API.Cart.Infrastructure;
using StoreServices.API.Cart.Interfaces;
using StoreServices.API.Cart.Models;
using StoreServices.API.Cart.Models.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreServices.API.Cart.Application
{
    public class Get
    {
        public class Execute : IRequest<CartDto>
        {
            public int CartSessionId { get; set; }
        }

        public class Handler : IRequestHandler<Execute, CartDto> 
        {
            private readonly CartContext _context;
            private readonly IBookService _bookService;
            private readonly IAuthorService _authorService;

            public Handler(CartContext cartContext, IBookService bookService, IAuthorService authorService)
            {
                _context = cartContext;
                _bookService = bookService;
                _authorService = authorService;
            }

            public async Task<CartDto> Handle(Execute request, CancellationToken cancellationToken)
            {
                CartSession cartSession = await _context.CartSessions
                                            .Where(x => x.Id == request.CartSessionId)
                                            .FirstOrDefaultAsync();
                
                List<CartSessionDetail> cartSessionDetail = await _context.CartSessionDetails
                                                        .Where(x => x.CartSessionId == cartSession.Id)
                                                        .ToListAsync();

                List<CartDetailDto> cartDetails = new List<CartDetailDto>();

                foreach (var detail in cartSessionDetail)
                {
                    var getBookResponse = await _bookService.GetBook(detail.SelectedProduct);

                    if (getBookResponse.result)
                    {
                        BookRemote book = getBookResponse.bookRemote;

                        var getAuthorResponse = await _authorService.GetAuthor(book.AuthorRepresentative);

                        if (!getAuthorResponse.result)
                            throw new Exception("Error calling the author service...");

                        cartDetails.Add(new CartDetailDto
                        {
                            BookId = book.Id,
                            BookTitle = book.Title,
                            PublishDate = book.PublishAt,
                            BookAuthorName = $"{getAuthorResponse.authorRemote.Firstname} {getAuthorResponse.authorRemote.Lastname}"
                        });
                    }
                }

                return new CartDto
                {
                    CartId = cartSession.Id,
                    CreatedAt = cartSession.CreatedAt,
                    Details = cartDetails
                };
            }
        }
    }
}
