using UnityEngine;

[System.Serializable]
public class Customer : MonoBehaviour
{
    public string species;
    public string origin;
    public string utensil;

    public Customer(string species, string origin, string utensil)
    {
        this.species = species;
        this.origin = origin;
        this.utensil = utensil;
    }

    public string GetInfo()
    {
        return $"Species: {species}\nOrigin: {origin}\nMood: {utensil}";
    }
}
