using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isStarted = false;

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

    void Update()
    {
        switch (SystemInfo.deviceType)
        {
            case DeviceType.Desktop: UpdateByDesktop(); break;
            case DeviceType.Handheld: UpdateByHandheld(); break;
            default: break;
        }
    }

    void UpdateByDesktop()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float y = Input.mousePosition.y - Camera.main.WorldToScreenPoint(gameObject.transform.position).y;
            CheckIfStart(y);
        }
    }

    void UpdateByHandheld()
    {
        if (Input.touchCount == 2)
        {
            Touch touch = Input.GetTouch(0);

            float y = touch.position.y - Camera.main.WorldToScreenPoint(gameObject.transform.position).y;
            CheckIfStart(y);
        }
    }

    void CheckIfStart(float y)
    {
        if (y < -25.0f)
        {
            isStarted = true;
        }
    }
}
