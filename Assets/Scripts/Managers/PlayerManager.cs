using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance { get; private set; }
    public Player player { get; private set; }
    public float decreaseOxygenTime;

    float decreaseOxygenCount = 0.0f;

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

    void Start()
    {
        player = null;
    }

    void Update()
    {
        if (!GameManager.instance.isPlaying)
        {
            return;
        }

        if (decreaseOxygenCount >= decreaseOxygenTime)
        {
            decreaseOxygenCount = 0;
            player.percentageOfOxygen -= 0.1f;

            if (player.percentageOfOxygen <= 0.0f)
            {
                player.percentageOfOxygen = 0.0f;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GameManager.instance.FinishRound();
            }

            UIManager.instance.OnPercentageOfOxygen(player.percentageOfOxygen);
        }

        decreaseOxygenCount += Time.deltaTime;
    }

    public void BuildNew()
    {
        player = new Player()
        {
            percentageOfOxygen = 1.0f,
            caughtFishQuantity = 0
        };
    }

    public void PlusCaughtFishQuantity()
    {
        player.caughtFishQuantity++;
        UIManager.instance.OnCaughtFishQuantityText(player.caughtFishQuantity);
    }
}
