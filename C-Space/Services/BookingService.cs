using C_Space.Interfaces;
using C_Space.Models;

namespace C_Space.Services;

public class BookingService : IBookingService
{
    private List<Booking> bookings;
    private readonly PlaceService placeService;
    public BookingService(PlaceService placeService)
    {
        this.bookings = new List<Booking>();
        this.placeService = placeService;
    }
    public Booking Create(Booking booking)
    {
        bookings.Add(booking);
        return booking;
    }

    public bool Delete(int id)
    {
        return bookings.Remove(bookings.FirstOrDefault(booking => booking.Id == id));
    }

    public List<Booking> GetAll()
        => bookings;

    public Booking GetById(int id)
    {
        return bookings.FirstOrDefault(booking => booking.Id == id);
    }

    public (string placeNumber, TimeOnly startTime, TimeOnly endTime) GetByUserId(int userId)
    {
        Booking booking = bookings.FirstOrDefault(booking => booking.UserId == userId);
        Place place = placeService.GetById(booking.PlaceId);
        return (placeNumber: place.Number, startTime: booking.StartTime, endTime: booking.EndTime);
    }

    public Booking Update(int id, Booking booking)
    {
        Booking existBooking = bookings.FirstOrDefault(booking => booking.Id == id);
        if (existBooking is not null)
        {
            existBooking.Id = id;
            existBooking.UserId = booking.UserId;
            existBooking.EndTime = booking.EndTime;
            existBooking.PlaceId = booking.PlaceId;
            existBooking.StartTime = booking.StartTime;
        }

        return existBooking;
    }
}
