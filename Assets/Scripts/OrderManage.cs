using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class OrderManager : MonoBehaviour
{
    public Customer currentCustomer;
    public TextMeshProUGUI feedbackText;
    public IngredientsButton[] ingredientButtons;

    public Dictionary<string, int> scoreTable = new Dictionary<string, int>()
{
    {"Solid", 0}, {"Liquid", 5}, {"Gas", 10},
    {"None", 0}, {"Mild", 5}, {"Hot", 10},
    {"Spoon", 0}, {"Chopsticks", 5}, {"Straw", 10}
};

    void Start()
    {
        GenerateCustomer();
        DisplayCustomerInfo();
    }

    void GenerateCustomer()
    {
        currentCustomer = new Customer("Nyarlathotep", "Outer Space", "Want Challenge");
    }

    void DisplayCustomerInfo()
    {
        feedbackText.text = currentCustomer.GetInfo();
    }

    public void CompleteOrder()
    {
        string result = EvaluateOrder().ToString();
        feedbackText.text = result;
    }

    int EvaluateOrder()
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