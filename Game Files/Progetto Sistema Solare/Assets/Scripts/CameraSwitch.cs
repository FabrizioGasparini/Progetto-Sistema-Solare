using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private GameObject flyCam;
    [SerializeField] private GameObject planetCam;
    [SerializeField] private GameObject gameMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject timeLabel;

    public bool locked = true;
    public bool pause = false;

    void Awake()
    {
        flyCam.SetActive(false);
        planetCam.SetActive(true);
        gameMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)){
            Lock();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause == false)
            {
                pause = true;
                pauseMenu.SetActive(true);
                gameMenu.SetActive(false);
                Time.timeScale = 0;
            }

            else
            {
                pause = false;
                pauseMenu.SetActive(false);
                gameMenu.SetActive(true);
                Time.timeScale = timeLabel.GetComponent<TimeScript>().speed;
            }
        }
    }

    public void Lock()
    {
        if (locked == true)
        {
            locked = false;
            flyCam.SetActive(true);
            planetCam.SetActive(false);
            flyCam.transform.position = planetCam.transform.position;
            flyCam.transform.rotation = planetCam.transform.rotation;
            gameMenu.SetActive(false);
        }
        else if(locked == false)
        {
            locked = true;
            flyCam.SetActive(false);
            planetCam.SetActive(true);
            gameMenu.SetActive(true);
        }
    }

    public void PauseMenu()
    {
        pause = false;
        pauseMenu.SetActive(false);
        gameMenu.SetActive(true);
        Time.timeScale = timeLabel.GetComponent<TimeScript>().speed;
    }

    public bool GetPause()
    {
        return pause;
    }
}
