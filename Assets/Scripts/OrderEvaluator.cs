using UnityEngine;

public class OrderEvaluator : MonoBehaviour
{
    public LevelManager levelManager;

    public void EvaluateOrder(string baseChoice, string spiceChoice, string utensilChoice)
    {
        var customer = levelManager.GetCurrentCustomer();
        int score = 0;

        if (baseChoice == customer.selectedBase) score += 10;
        if (spiceChoice == customer.selectedSpice) score += 5;
        if (utensilChoice == customer.selectedUtensil) score += 5;

        Debug.Log("SCORE: " + score);
    }
}
