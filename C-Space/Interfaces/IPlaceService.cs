using C_Space.Models;

namespace C_Space.Interfaces;

public interface IPlaceService
{
    Place Create(Place place);
    Place Update(int id, Place place);
    bool Delete(int id);
    Place GetById(int id);
    List<Place> GetAll();
    List<Place> GetAvailablePlacesList();
}
