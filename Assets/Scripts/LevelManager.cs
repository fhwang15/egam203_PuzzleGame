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

    public List<SpeciesProfile> shapeshifterTargets;

    public int currentLevel = 1;
    public TextMeshProUGUI infoText;

    private CustomProfile currentCustomer;

    public Image customerImage;


    void Start()
    {
        SpawnRandomCustomer();
    }

    public void SpawnRandomCustomer()
    {
        List<SpeciesProfile> speciesList = GetSpeciesListForCurrentLevel();

        if (currentLevel < 3)
        {
            speciesList = speciesList.FindAll(s => !s.isShapeshifter);
        }

        if (speciesList == null || speciesList.Count == 0)
        {
            Debug.LogWarning("No species available for this level.");
            return;
        }

        SpeciesProfile selectedSpecies = speciesList[Random.Range(0, speciesList.Count)];

        currentCustomer = new CustomProfile { species = selectedSpecies };

        // 셰이프시프터 흉내낼 대상 리스트 전달
        currentCustomer.GenerateRandomPreference(shapeshifterTargets);

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
        Sprite imageToShow = currentCustomer.species.customerPortrait;
        string nameToShow = currentCustomer.species.speciesName;

        if (currentCustomer.species.isShapeshifter && currentCustomer.mimickedSpecies != null)
        {
            imageToShow = currentCustomer.mimickedSpecies.customerPortrait;
            nameToShow = "???";
        }

        customerImage.sprite = imageToShow;

        infoText.text = $"Species: {nameToShow}\nMood: {currentCustomer.mood}";
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
