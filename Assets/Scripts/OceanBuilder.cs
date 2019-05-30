using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanBuilder : MonoBehaviour
{
    public float Width;
    public float Height;
    public GameObject OceanObject;

    void Start()
    {
        for (int i = 0; i < Width; i++)
        {
            for(int j = 0; j < Height; j++)
            {
                float positionX = (-(Width / 2) + i);
                float positionY = (-(Height) + j);
                Vector3 position = new Vector3(positionX, positionY, 0);
                GameObject instance = Instantiate(OceanObject, position, Quaternion.identity);
                instance.name = "Ocean " + i.ToString();
                instance.transform.parent = gameObject.transform;
            }
        }
    }
}
