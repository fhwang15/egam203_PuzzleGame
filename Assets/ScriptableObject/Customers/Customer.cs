using UnityEngine;

[CreateAssetMenu(fileName = "Customer", menuName = "Scriptable Objects/Customer")]
public class Customer : ScriptableObject
{
    public string name;
    public string mood;
    public string prefernce;
    public string weather;
    public string hint;
}
