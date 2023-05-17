using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraLockerScript : MonoBehaviour
{
    public int planetIndex;
    public GameObject EventSystem;
    public GameObject cam;

    void OnMouseOver()
    {
        if (EventSystem.GetComponent<CameraSwitch>().locked == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                cam.GetComponent<CameraHandler>().planetIndex = planetIndex;
                cam.GetComponent<CameraHandler>().Setup();
                EventSystem.GetComponent<CameraSwitch>().Lock();
            }
        }
    }
}