using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [Header("Camera")]
    public Camera cam;
    public float rotationSpeed;

    [Header("Planets")]
    public GameObject[] planets;
    public int planetIndex = 3;
    public GameObject target;
    private float radius;
    private float minDistanceFromTarget;
    private float maxDistanceFromTarget;
    private float distanceFromTarget;
    private Vector3 previousPosition;

    [Header("")]
    public GameObject eventSystem;
   


    private bool pause;

    void Awake()
    {
        Setup();
    }

    void Update()
    {
        pause = eventSystem.GetComponent<CameraSwitch>().GetPause();

        if(pause == false)
        {
            HandleRotation();
            HandleZoom();
            HandlePlanetSwitch();
        }
    }

    public void Setup()
    {
        target = planets[planetIndex];
        cam.transform.parent = target.transform;
        radius = target.transform.localScale.x;

        minDistanceFromTarget = radius * 3;
        maxDistanceFromTarget = minDistanceFromTarget * 5;

        distanceFromTarget = (minDistanceFromTarget + maxDistanceFromTarget) / 2;
    }

    private void HandleRotation()
    {
        Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        Vector3 direction = previousPosition - newPosition;

        float rotationAroundXAxis = direction.y * 180 * rotationSpeed; // camera moves vertically

        float rotationAroundYAxis = -direction.x * 180 * rotationSpeed; // camera moves horizontally

        cam.transform.position = target.transform.position;

        cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
        cam.transform.Rotate(new Vector3(0, -1, 0), rotationAroundYAxis, Space.World); // <� This is what makes it work!

        cam.transform.Translate(new Vector3(0, 0, -distanceFromTarget));

        previousPosition = newPosition;
    }

    private void HandleZoom()
    {
        float zoom = (radius * 5) / 10;
        if (Input.mouseScrollDelta.y > 0)
        {
            if (distanceFromTarget > minDistanceFromTarget)
            {
                distanceFromTarget -= zoom;
            }
        }

        else if (Input.mouseScrollDelta.y < 0)
        {
            if (distanceFromTarget < maxDistanceFromTarget)
            {
                distanceFromTarget += zoom;
            }
        }



        if (Input.GetKey(KeyCode.W))
        {
            if (distanceFromTarget > minDistanceFromTarget)
            {
                distanceFromTarget -= zoom / 5;
            }
        }

        else if (Input.GetKey(KeyCode.S))
        {
            if (distanceFromTarget < maxDistanceFromTarget)
            {
                distanceFromTarget += zoom / 5;
            }
        }

        if (distanceFromTarget < minDistanceFromTarget)
        {
            distanceFromTarget = minDistanceFromTarget;
        }

        if (distanceFromTarget > maxDistanceFromTarget)
        {
            distanceFromTarget = maxDistanceFromTarget;
        }
    }

    private void HandlePlanetSwitch()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            planetIndex++;
            SwitchPlanet();
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            planetIndex--;
            SwitchPlanet();
        }
    }

    public void ChangeIndex(int value)
    {
        planetIndex += value;
        SwitchPlanet();
    }

    private void SwitchPlanet()
    {
        if (planetIndex < 0)
        {
            planetIndex = 9;
        }

        if (planetIndex > 9)
        {
            planetIndex = 0;
        }

        Setup();
    }

    public GameObject GetPlanet()
    {
        return target;
    }

    public float GetRadius()
    {
        return radius;
    }
}