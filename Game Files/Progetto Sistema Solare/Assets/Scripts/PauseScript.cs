using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameMenu;

    public bool pause = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(pause == false){
                pause = true;
                pauseMenu.SetActive(true);
                gameMenu.SetActive(false);
            }

            else
            {
                pause = true;
                pauseMenu.SetActive(false);
                gameMenu.SetActive(true);
            }
        }
    }
}
