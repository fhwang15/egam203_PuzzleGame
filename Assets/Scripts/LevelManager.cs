using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public List<SpeciesProfile> level1Species;
    public List<SpeciesProfile> level2Species;
    public List<SpeciesProfile> level3Species;

    public int currentLevel = 1;
    public TextMeshProUGUI infoText;

    private CustomProfile currentCustomer;

    void Start()
    {
        SpawnRandomCustomer();
    }

    public void SpawnRandomCustomer()
    {
        List<SpeciesProfile> speciesList = GetSpeciesListForCurrentLevel();
        if (speciesList == null || speciesList.Count == 0)
        {
            Debug.LogWarning("No species available for this level.");
            return;
        }

        SpeciesProfile selectedSpecies = speciesList[Random.Range(0, speciesList.Count)];
        currentCustomer = new CustomProfile { species = selectedSpecies };
        currentCustomer.GenerateRandomPreference();

        UpdateCustomerInfoUI();
    }

    List<SpeciesProfile> GetSpeciesListForCurrentLevel()
    {
        switch (currentLevel)
        {
            case 1: return level1Species;
            case 2: return level2Species;
            case 3: return level3Species;
            default: return new List<SpeciesProfile>();
        }
    }

    void UpdateCustomerInfoUI()
    {
        infoText.text = $"Species: {currentCustomer.species.speciesName}\n" +
                        $"Mood: {currentCustomer.mood}\n";
    }

    public CustomProfile GetCurrentCustomer()
    {
        return currentCustomer;
    }

    public void GoToNextLevel()
    {
        currentLevel++; 
        SpawnRandomCustomer(); 
    }
}
