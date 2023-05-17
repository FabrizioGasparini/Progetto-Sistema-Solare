using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetOrbiter : MonoBehaviour
{
    public float roatationSpeed;
    void Update()
    {
        transform.Rotate(new Vector3(0, roatationSpeed, 0), Space.World);
    }
}
