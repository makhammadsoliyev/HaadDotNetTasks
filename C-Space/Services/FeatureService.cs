using C_Space.Interfaces;
using C_Space.Models;

namespace C_Space.Services;

public class FeatureService : IFeatureService
{
    private List<Feature> features;
    public FeatureService()
    {
        this.features = new List<Feature>();
    }
    public Feature Create(Feature feature)
    {
        features.Add(feature);
        return feature;
    }

    public bool Delete(int id)
    {
        return features.Remove(features.FirstOrDefault(feature => feature.Id == id));
    }

    public List<Feature> GetAll()
        => features;

    public Feature GetById(int id)
    {
        return features.FirstOrDefault(feature => feature.Id == id);
    }

    public Feature Update(int id, Feature feature)
    {
        Feature existFeature = features.FirstOrDefault(feature => feature.Id == id);
        if (existFeature is not null)
        {
            existFeature.Id = id;
            existFeature.Name = feature.Name;
        }

        return existFeature;
    }
}
