using C_Space.Models;

namespace C_Space.Interfaces;

public interface IBookingService
{
    Booking Create(Booking booking);
    Booking Update(int id, Booking booking);
    bool Delete(int id);
    Booking GetById(int id);
    //List<Booking> GetByUserId(int userId);
    (string placeNumber, TimeOnly startTime, TimeOnly endTime) GetByUserId(int userId);
    List<Booking> GetAll();
}
