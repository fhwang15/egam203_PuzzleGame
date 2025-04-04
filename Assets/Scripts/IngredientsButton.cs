using UnityEngine;
using UnityEngine.UI;

public class IngredientsButton : MonoBehaviour
{
    public string ingredientName;
    private bool isSelected;
    private Button button;
    private Image buttonImage;

    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = GetComponentInChildren<Image>();

        if (button == null)
        {
            Debug.LogError("Button component not found on " + gameObject.name);
            return;
        }

        if (buttonImage == null)
        {
            Debug.LogError("Image component not found on " + gameObject.name);
            return;
        }

        // 중복 Listener 방지
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(ToggleSelection);
        isSelected = false;
    }

    void ToggleSelection()
    {
        isSelected = !isSelected;
        UpdateColor();
        Debug.Log("Button clicked: " + ingredientName + ", Selected: " + isSelected);
    }

    void UpdateColor()
    {
        if (buttonImage != null)
        {
            Color color = isSelected ? Color.green : Color.white;
            buttonImage.color = color;
            Debug.Log("Color changed: " + color);
        }
    }

    public bool IsSelected()
    {
        return isSelected;
    }

    public string GetIngredient()
    {
        return ingredientName;
    }
}