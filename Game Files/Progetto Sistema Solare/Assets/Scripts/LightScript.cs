using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public GameObject sun;
    public GameObject planet;

    void Update()
    {
        transform.position = sun.transform.position;
        transform.LookAt(planet.transform);
    }
}
