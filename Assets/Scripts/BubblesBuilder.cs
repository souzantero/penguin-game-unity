using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesBuilder : MonoBehaviour
{
    public float Width;
    public float Height;
    public GameObject BubbleObject;
    public int BubbleQuantity;

    void Start()
    {
        for (int i = 0; i <= BubbleQuantity; i++)
        {
            float positionX = Random.Range(-Width/2, Width/2);
            float positionY = Random.Range(-(2 * Height), 0);
            Vector3 position = new Vector3(positionX, positionY, 0);
            GameObject instance = Instantiate(BubbleObject, position, Quaternion.identity);
            instance.name = "Bubble " + i.ToString();
            instance.transform.parent = gameObject.transform;
        }
    }
}
