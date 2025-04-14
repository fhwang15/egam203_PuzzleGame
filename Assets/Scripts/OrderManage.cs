using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class OrderManager : MonoBehaviour
{
    public TextMeshProUGUI feedbackText;
    public IngredientsButton[] ingredientButtons;

    public LevelManager levelManager;
    public GameObject nextButton;

    public Dictionary<string, int> scoreTable = new Dictionary<string, int>()
{
    {"Solid", 0}, {"Liquid", 5}, {"Gas", 10},
    {"None", 0}, {"Mild", 5}, {"Hot", 10},
    {"Spoon", 0}, {"Chopsticks", 5}, {"Straw", 10}
};

    public void CompleteOrder()
    {
        CustomProfile customer = levelManager.GetCurrentCustomer();

        int score = EvaluateOrder(customer);
        feedbackText.text = "Final Score: " + score;
        nextButton.SetActive(true);
    }

    int EvaluateOrder(CustomProfile customer)
    {
        int score = 0;

        foreach (IngredientsButton button in ingredientButtons)
        {
            if (button.IsSelected())
            {
                string ingredient = button.GetIngredient();
                if (scoreTable.ContainsKey(ingredient))
                {
                    score += scoreTable[ingredient];
                }
            }
        }

        Debug.Log("Final Score: " + score);
        return score;
    }
}