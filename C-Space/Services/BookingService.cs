using C_Space.Interfaces;
using C_Space.Models;
using System.ComponentModel.Design;

namespace C_Space.Services;

public class BookingService : IBookingService
{
    private List<Booking> bookings;
    private readonly UserService userService;
    private readonly PlaceService placeService;
    public BookingService(PlaceService placeService, UserService userService)
    {
        this.bookings = new List<Booking>();
        this.placeService = placeService;
        this.userService = userService;
    }
    public Booking Create(Booking booking)
    {
        Place place = placeService.GetById(booking.PlaceId);
        if (!place.IsAvailable)
            throw new Exception("This place is not available");

        place.IsAvailable = false;
        bookings.Add(booking);

        return booking;
    }

    public bool Delete(int id)
    {
        Booking booking = bookings.FirstOrDefault(booking => booking.Id == id);
        if (booking is null)
            throw new Exception("This booking was not found.");

        return bookings.Remove(booking);
    }

    public List<Booking> GetAll()
        => bookings;

    public Booking GetById(int id)
    {
        Booking booking = bookings.FirstOrDefault(booking => booking.Id == id);
        if (booking is null)
            throw new Exception("This booking was not found");

        return booking;
    }

    public (string placeNumber, TimeOnly startTime, TimeOnly endTime) GetByUserId(int userId)
    {
        User user = userService.GetById(userId);
        

        Booking booking = bookings.FirstOrDefault(booking => booking.UserId == userId);
        if (booking is null)
            throw new Exception("This booking was not found");

        Place place = placeService.GetById(booking.PlaceId);

        return (placeNumber: place.Number, startTime: booking.StartTime, endTime: booking.EndTime);
    }

    public Booking Update(int id, Booking booking)
    {
        Booking existBooking = bookings.FirstOrDefault(booking => booking.Id == id);
        if (existBooking is null)
            throw new Exception("This booking was not found");

        existBooking.Id = id;
        existBooking.UserId = booking.UserId;
        existBooking.EndTime = booking.EndTime;
        existBooking.PlaceId = booking.PlaceId;
        existBooking.StartTime = booking.StartTime;

        return existBooking;
    }
}
