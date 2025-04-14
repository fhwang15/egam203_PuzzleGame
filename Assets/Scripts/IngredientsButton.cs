using UnityEngine;
using UnityEngine.UI;

public class IngredientsButton : MonoBehaviour
{
    public string ingredientName;
    private bool isSelected;
    private Button button;
    private Image buttonImage;

    public int buttonID;

    public IngredientButtonGroup group; // 연결 필요!

    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(ToggleSelection);

        Debug.Log($"[INIT] {ingredientName} Listener count: {button.onClick.GetPersistentEventCount()}");

        isSelected = false;
        UpdateColor();
    }

    void ToggleSelection()
    {
        if (isSelected)
        {
            // 내가 이미 선택되어있고, 또 누르면 → 해제
            isSelected = false;
            UpdateColor();
            Debug.Log($"[TOGGLE] {ingredientName} → Deselected");
        }
        else
        {
            // 다른 거 선택 → 내 선택 상태는 group이 컨트롤하게!
            Debug.Log($"[TOGGLE] {ingredientName} → Selected");
            group?.OnButtonSelected(this);
        }
    }

    public void ForceDeselect()
    {
        isSelected = false;
        UpdateColor();
    }

    void UpdateColor()
    {
        if (buttonImage != null)
        {
            buttonImage.color = isSelected ? Color.green : Color.white;
        }
    }

    public void ForceSelect()
    {
        isSelected = true;
        UpdateColor();
    }

    public bool IsSelected() => isSelected;

    public string GetIngredient() => ingredientName;
}