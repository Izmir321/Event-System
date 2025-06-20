using Presentation.Entities;
using Presentation.Models;
using Presentation.Repositories;

namespace Presentation.Service;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;

    public BookingService(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public async Task<BookingResult> CreateBookingAsync(CreateBookingRequest request)
    {
        var bookingOwner = new BookingOwnerEntity
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Address = new BookingAddressEntity
            {
                StreetName = request.StreetName,
                PostalCode = request.PostalCode,
                City = request.City,
            }
        };

        var bookingEntity = new BookingEntity
        {
            EventId = request.EventId,
            BookingDate = DateTime.Now,
            TicketQuantity = request.TicketQuantity,
            BookingOwner = bookingOwner
        };

        var result = await _bookingRepository.AddAsync(bookingEntity);

        return result.Success
            ? new BookingResult { Success = true }
            : new BookingResult { Success = false, Error = result.Error };
    }
}
