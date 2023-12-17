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
        places.Add(place);
        return place;
    }

    public bool Delete(int id)
    {
        return places.Remove(places.FirstOrDefault(place => place.Id == id));
    }

    public List<Place> GetAll()
        => places;

    public List<Place> GetAvailablePlacesList()
        => places.Where(place => place.IsAvailable).ToList();

    public Place GetById(int id)
    {
        return places.FirstOrDefault(place => place.Id == id);
    }

    public Place Update(int id, Place place)
    {
        Place existPlace = places.FirstOrDefault(place=> place.Id == id);
        if (existPlace == null)
        {
            existPlace.Id = id;
            existPlace.Room = place.Room;
            existPlace.Price = place.Price;
            existPlace.Floor = place.Floor;
            existPlace.Number = place.Number;
            existPlace.Features = place.Features;
            existPlace.IsAvailable = place.IsAvailable;
        }
        return existPlace;
    }
}
