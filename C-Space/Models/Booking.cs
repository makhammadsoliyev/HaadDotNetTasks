namespace C_Space.Models;

public class Booking
{
    private static int id = 0;
    public Booking()
    {
        this.Id = ++id;
    }
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PlaceId { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}
