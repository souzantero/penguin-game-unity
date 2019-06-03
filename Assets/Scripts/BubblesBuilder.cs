using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesBuilder : MonoBehaviour
{
    public float width;
    public float height;
    public GameObject bubbleObject;
    public int bubbleQuantity;

    void Start()
    {
        for (int i = 0; i < bubbleQuantity; i++)
        {
            float positionX = Random.Range(-width/2, width/2);
            float positionY = Random.Range(-(height), -2);
            Vector3 position = new Vector3(positionX, positionY, 0);
            GameObject instance = Instantiate(bubbleObject, position, Quaternion.identity);
            instance.name = "Bubble " + i.ToString();
            instance.transform.parent = gameObject.transform;
        }
    }
}
