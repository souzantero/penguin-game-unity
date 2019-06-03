using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBuilder : MonoBehaviour
{
    public float width;
    public float height;
    public GameObject fishObject;
    public int fishQuantity;

    void Start()
    {
        for (int i = 0; i < fishQuantity; i++)
        {
            float positionX = Random.Range(-width/2, width/2);
            float positionY = Random.Range(-(height), -2);
            Vector3 position = new Vector3(positionX, positionY, 0);

            SpriteRenderer fishSpriteRenderer = fishObject.GetComponent<SpriteRenderer>();
            if (Random.Range(0, 2) == 0)
            {
                fishSpriteRenderer.flipX = true;
            }
            else
            {
                fishSpriteRenderer.flipX = false;
            }

            GameObject instance = Instantiate(fishObject, position, Quaternion.identity);
            instance.name = "Fish " + i.ToString();
            instance.transform.parent = gameObject.transform;

            FishController instanceController = instance.GetComponent<FishController>();
            instanceController.moveSpeed = Random.Range(1, 3);
            instanceController.turnTime = Random.Range(2, 6);
        }
    }
}
