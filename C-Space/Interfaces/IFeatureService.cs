using C_Space.Models;

namespace C_Space.Interfaces;

public interface IFeatureService
{
    Feature Create(Feature feature);
    Feature Update(int id, Feature feature);
    Feature GetById(int id);
    bool Delete(int id);
    List<Feature> GetAll();
}
