using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[System.Serializable] 
public class CustomProfile : MonoBehaviour
{

    public SpeciesProfile species;
    public string selectedBase;
    public string selectedSpice;
    public string selectedUtensil;

    public string mood;

    public void GenerateRandomPreference()
    {
        selectedBase = GetWeightedRandom(species.PreferredBases, species.dislikedBases);
        selectedSpice = GetWeightedRandom(species.PreferredSpices, species.dislikedSpices);
        selectedUtensil = species.utensilEater ? "None" : species.allowedUtensils[Random.Range(0, species.allowedUtensils.Count)];
    }


    private string GetWeightedRandom(List<string> preferred, List<string> disliked)
    {
        int roll = Random.Range(0, 100);
        if (roll < 60 && preferred.Count > 0) return preferred[Random.Range(0, preferred.Count)];
        if (roll < 90 && disliked.Count > 0) return disliked[Random.Range(0, disliked.Count)];
        return "None";
    }
}
