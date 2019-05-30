using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceBuilder : MonoBehaviour
{
    public float Width;
    public GameObject SurfaceObject;

    void Start()
    {
        for (int i = 0; i < Width; i++)
        {
            float positionX = (-(Width / 2) + i);
            float positionY = 0.0f;
            Vector3 position = new Vector3(positionX, positionY, 0);
            GameObject instance = Instantiate(SurfaceObject, position, Quaternion.identity);
            instance.name = "Surface " + i.ToString();
            instance.transform.parent = gameObject.transform;
        }
    }
}
