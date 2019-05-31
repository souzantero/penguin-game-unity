using System;
public class Player
{
    public float oxygen { get; set; }

    public Player() { }

    public void DecreaseOxygen(float value)
    {
        oxygen -= value;
    }
}
