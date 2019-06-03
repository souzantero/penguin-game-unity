using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }
    public Text caughtFishQuantityText;
    public Text percentageOfOxygenText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void OnCaughtFishQuantityText(int quantity)
    {
        caughtFishQuantityText.text = quantity.ToString();
    }

    public void OnPercentageOfOxygen(float percentage)
    {
        percentage = percentage * 100;
        percentageOfOxygenText.text = "Oxygen: " + percentage.ToString() + "%";
    }
}
