using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardUI : MonoBehaviour
{
    public GameObject cam;
    public GameObject cam2;
    public GameObject planetName;
    private GameObject planet;

    void Awake()
    {
        planet = transform.parent.gameObject;
        planetName.GetComponent<UnityEngine.UI.Text>().text = planet.name;
    }

    void Update()
    {
        if(cam.activeSelf == true)
        {
            transform.rotation = cam.transform.rotation;
        }
        else
        {
            transform.rotation = cam2.transform.rotation;
        }
    }
}
