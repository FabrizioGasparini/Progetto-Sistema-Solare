using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetStats : MonoBehaviour
{
    [Header("Stats")]
    public int planetIndex;
    public float radius;
    public float mass;
    public int satelliti;
    public string rotation;
    public string revolution;

    [Header("Variables")]
    public float startingDistance;
    
    [Header("References")]
    public GameObject EventSystem;
    public GameObject cam;
    public GameObject trail;

    public GameObject newTrail;

    void OnMouseOver()
    {
        if (EventSystem.GetComponent<CameraSwitch>().locked == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                cam.GetComponent<CameraHandler>().planetIndex = planetIndex;
                cam.GetComponent<CameraHandler>().Setup();
                EventSystem.GetComponent<CameraSwitch>().Lock();
                Debug.Log("Pianeta: " + planetIndex);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }

    void Awake() {
        transform.position = new Vector3(startingDistance, 0, 0);
        newTrail = Instantiate(trail, transform.position, Quaternion.identity, transform);
    }

    private void Start()
    {
        Time.timeScale = 1;
        newTrail.GetComponent<TrailRenderer>().Clear();
        newTrail.GetComponent<TrailRenderer>().time = 1;
    }
}
