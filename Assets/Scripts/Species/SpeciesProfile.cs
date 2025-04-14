using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[CreateAssetMenu(fileName = "SpeciesProfile", menuName = "Scriptable Objects/SpeciesProfile")]
public class SpeciesProfile : ScriptableObject
{
    public string speciesName;
    public List<string> PreferredBases;
    public List<string> dislikedBases;
    public List<string> PreferredSpices;
    public List<string> dislikedSpices;
    public List<string> allowedUtensils;
    public bool utensilEater;
    public bool isShapeshifter;

}
