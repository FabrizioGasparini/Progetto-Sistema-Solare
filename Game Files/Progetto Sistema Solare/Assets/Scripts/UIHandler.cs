using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [Header("Labels")]
    [SerializeField] private GameObject planetName;
    [SerializeField] private GameObject planetNameSwitch;
    [SerializeField] private GameObject planetRadius;
    [SerializeField] private GameObject planetMass;
    [SerializeField] private GameObject planetRotation;
    [SerializeField] private GameObject planetRevolution;
    [SerializeField] private GameObject planetSatelliti;

    [Header("References")]
    [SerializeField] private GameObject cam;
    private GameObject planet;

    void Update()
    {
        planet = cam.GetComponent<CameraHandler>().GetPlanet();
        planetName.GetComponent<Text>().text = planet.GetComponent<PlanetStats>().name;
        planetNameSwitch.GetComponent<Text>().text = planet.GetComponent<PlanetStats>().name;
        planetRadius.GetComponent<Text>().text = "RAGGIO: " + planet.GetComponent<PlanetStats>().radius + " KM";
        planetMass.GetComponent<Text>().text = "MASSA: " + planet.GetComponent<PlanetStats>().mass + " M⊕";
        planetSatelliti.GetComponent<Text>().text = "SATELLITI: " + planet.GetComponent<PlanetStats>().satelliti;
        planetRotation.GetComponent<Text>().text = "ROTAZIONE: " + planet.GetComponent<PlanetStats>().rotation;
        planetRevolution.GetComponent<Text>().text = "RIVOLUZIONE: " + planet.GetComponent<PlanetStats>().revolution;
    }
}
