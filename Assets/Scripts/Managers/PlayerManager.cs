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
            player.DecreaseOxygen(decreaseOxygenTime / 100);
        }

        decreaseOxygenCount += Time.deltaTime;
    }

    public void BuildNew()
    {
        player = new Player()
        {
            oxygen = 1.0f
        };
    }
}
