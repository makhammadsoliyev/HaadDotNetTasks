using C_Space.Interfaces;
using C_Space.Models;

namespace C_Space.Services;

public class PlaceService : IPlaceService
{
    private List<Place> places;
    public PlaceService()
    {
        this.places = new List<Place>();
    }
    public Place Create(Place place)
    {
        Place existPlace = places.FirstOrDefault(place => place.Number == place.Number);
        if (existPlace is not null)
            throw new Exception("This place already exists");

        places.Add(place);

        return place;
    }

    public bool Delete(int id)
    {
        Place place = places.FirstOrDefault(place => place.Id == id);
        if (place is null)
            throw new Exception("This place was not found");

        return places.Remove(place);
    }

    public List<Place> GetAll()
        => places;

    public List<Place> GetAvailablePlacesList()
        => places.Where(place => place.IsAvailable).ToList();

    public Place GetById(int id)
    {
        Place place = places.FirstOrDefault(place => place.Id == id);
        if (place is null)
            throw new Exception("This place was not found");

        return place;
    }

    public Place Update(int id, Place place)
    {
        Place existPlace = places.FirstOrDefault(place=> place.Id == id);
        if (existPlace is null)
            throw new Exception("This place was not found");

        existPlace.Id = id;
        existPlace.Room = place.Room;
        existPlace.Price = place.Price;
        existPlace.Floor = place.Floor;
        existPlace.Number = place.Number;
        existPlace.Features = place.Features;
        existPlace.IsAvailable = place.IsAvailable;

        return existPlace;
    }
}
