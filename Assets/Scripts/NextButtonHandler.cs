using UnityEngine;

public class NextButtonHandler : MonoBehaviour
{
    public LevelManager levelManager;
    public GameObject nextButton;

    public void OnNextButtonPressed()
    {
        levelManager.GoToNextLevel(); 
        nextButton.SetActive(false);
    }
}
