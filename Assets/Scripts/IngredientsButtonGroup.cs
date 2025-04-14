using UnityEngine;
using System.Collections.Generic;

public class IngredientButtonGroup : MonoBehaviour
{
    public List<IngredientsButton> buttons;

    public void OnButtonSelected(IngredientsButton selectedButton)
    {
        foreach (IngredientsButton btn in buttons)
        {
            // 모두 꺼버리고, 마지막에 내가 선택한 것만 켜자!
            btn.ForceDeselect();
        }

        selectedButton.ForceSelect(); // 강제로 자신만 선택
    }

    public string GetSelectedIngredient()
    {
        foreach (var btn in buttons)
        {
            if (btn.IsSelected()) return btn.GetIngredient();
        }
        return null;
    }
}
