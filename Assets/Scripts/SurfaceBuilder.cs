using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceBuilder : MonoBehaviour
{
    public float width;
    public GameObject surfaceObject;

    void Start()
    {
        for (int i = 0; i < width; i++)
        {
            float positionX = (-(width / 2) + i);
            float positionY = 0.0f;
            Vector3 position = new Vector3(positionX, positionY, 0);
            GameObject instance = Instantiate(surfaceObject, position, Quaternion.identity);
            instance.name = "Surface " + i.ToString();
            instance.transform.parent = gameObject.transform;
        }
    }
}
