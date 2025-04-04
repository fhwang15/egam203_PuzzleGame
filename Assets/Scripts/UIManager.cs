using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI resultText;

    public void ShowResult(string message)
    {
        resultText.text = message;
    }
}