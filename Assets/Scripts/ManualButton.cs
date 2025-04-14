using UnityEngine;

public class ManualButton : MonoBehaviour
{
    public GameObject manualPanel;

    public void Toggle()
    {
        manualPanel.SetActive(!manualPanel.activeSelf);
    }

}
