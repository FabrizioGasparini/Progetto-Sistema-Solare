using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject main;
    [SerializeField] private GameObject istruzioni;

    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenIstruzioni()
    {
        main.SetActive(false);
        istruzioni.SetActive(true);
    }

    public void CloseIstruzioni()
    {
        main.SetActive(true);
        istruzioni.SetActive(false);
    }
}
