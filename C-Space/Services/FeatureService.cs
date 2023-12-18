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
        Feature feature = features.FirstOrDefault(feature => feature.Id == id);
        if (feature is null)
            throw new Exception("This feature wsa not found");

        return features.Remove(feature);
    }

    public List<Feature> GetAll()
        => features;

    public Feature GetById(int id)
    {
        Feature feature = features.FirstOrDefault(feature => feature.Id == id);
        if (feature is null)
            throw new Exception("This feature was not found");

        return feature;
    }

    public Feature Update(int id, Feature feature)
    {
        Feature existFeature = features.FirstOrDefault(feature => feature.Id == id);
        if (existFeature is null)
            throw new Exception("This feature was not found");

        existFeature.Id = id;
        existFeature.Name = feature.Name;

        return existFeature;
    }
}
