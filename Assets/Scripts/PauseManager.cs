using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    GameObject PauseMenu = null;
    [SerializeField]
    Button Pausebutton = null;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void InGamePaused()
    {
        Time.timeScale = 0;
        TogglePauseMenu(true);
        Pausebutton.interactable = false;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        TogglePauseMenu(false);
        Pausebutton.interactable = true;
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Resume();
    }
    public void Quit()
    {
        Resume();
        if (Application.platform == RuntimePlatform.Android)
        {
            Application.Quit();
        }
    }
    void TogglePauseMenu(bool activate)
    {
        PauseMenu.SetActive(activate);
    }
}
