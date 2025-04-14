using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[System.Serializable] 
public class CustomProfile
{

    public SpeciesProfile species;
    public SpeciesProfile mimickedSpecies;

    public string selectedBase;
    public string selectedSpice;
    public string selectedUtensil;

    public string mood;

    public void GenerateRandomPreference(List<SpeciesProfile> allSpecies)
    {
        if (species.isShapeshifter)
        {

            var potentialTargets = allSpecies.FindAll(s => !s.isShapeshifter);

            if (potentialTargets == null || potentialTargets.Count == 0)
            {
                Debug.LogWarning("No valid mimic targets for Shapeshifter!");
                // fallback 처리: 자기 자신으로 대체
                mimickedSpecies = species;
                selectedBase = "None";
                selectedSpice = "None";
                selectedUtensil = "None";
                return;
            }

            mimickedSpecies = potentialTargets[Random.Range(0, potentialTargets.Count)];
            selectedBase = GetInverse(mimickedSpecies.PreferredBases, mimickedSpecies.dislikedBases);
            selectedSpice = GetInverse(mimickedSpecies.PreferredSpices, mimickedSpecies.dislikedSpices);
            selectedUtensil = "None";
        }
        else
        {
            selectedBase = GetRandom(species.PreferredBases);
            selectedSpice = GetRandom(species.PreferredSpices);
            selectedUtensil = GetRandom(species.allowedUtensils);
        }

        mood = Random.Range(0, 2) == 0 ? "Sad" : "Neutral";
    }

    string GetInverse(List<string> prefers, List<string> dislikes)
    {
       
        List<string> inversePool = new List<string>();
        inversePool.AddRange(dislikes);
        if (inversePool.Count == 0) inversePool.Add("None");
        return inversePool[Random.Range(0, inversePool.Count)];
    }

    string GetRandom(List<string> list)
    {
        if (list == null || list.Count == 0) return "None";
        return list[Random.Range(0, list.Count)];
    }
}
