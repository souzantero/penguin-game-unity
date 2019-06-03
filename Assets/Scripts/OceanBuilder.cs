using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanBuilder : MonoBehaviour
{
    public float width;
    public float height;
    public GameObject oceanObject;

    void Start()
    {
        for (int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                float positionX = (-(width / 2) + i);
                float positionY = (-(height) + j);
                Vector3 position = new Vector3(positionX, positionY, 0);
                GameObject instance = Instantiate(oceanObject, position, Quaternion.identity);
                instance.name = "Ocean " + i.ToString();
                instance.transform.parent = gameObject.transform;
            }
        }
    }
}
