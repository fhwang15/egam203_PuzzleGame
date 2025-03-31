using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Table currnetTable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public int CalculateScore()
    {
        int totalScore = 0;

        foreach (Customer customer in currnetTable.customers)
        {
            int score = 0;

            if(customer.mood == "Sad")
            {
                score = 0;
            } else if(customer.prefernce == "spicy")
            {
                score += 50;
            } else if (customer.weather == "rain")
            {
                score += 50;
            }

            totalScore += score;
        }

        int averageScore = totalScore / 4;
        return averageScore;

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
