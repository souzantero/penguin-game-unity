using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBuilder : MonoBehaviour
{
    public float Width;
    public float Height;
    public GameObject FishObject;
    public int FishQuantity;

    void Start()
    {
        for (int i = 0; i < FishQuantity; i++)
        {
            float positionX = Random.Range(-Width/2, Width/2);
            float positionY = Random.Range(-(Height), -2);
            Vector3 position = new Vector3(positionX, positionY, 0);

            SpriteRenderer fishSpriteRenderer = FishObject.GetComponent<SpriteRenderer>();
            if (Random.Range(0, 2) == 0)
            {
                fishSpriteRenderer.flipX = true;
            }
            else
            {
                fishSpriteRenderer.flipX = false;
            }

            GameObject instance = Instantiate(FishObject, position, Quaternion.identity);
            instance.name = "Fish " + i.ToString();
            instance.transform.parent = gameObject.transform;

            FishController instanceController = instance.GetComponent<FishController>();
            instanceController.MoveSpeed = Random.Range(1, 3);
            instanceController.TurnTime = Random.Range(2, 6);
        }
    }
}
