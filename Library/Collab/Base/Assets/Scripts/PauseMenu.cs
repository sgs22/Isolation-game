using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public bool pauseEnabled;
    public GameObject pauseImage;

    public GameObject Player;
    public GameObject MainCamera;

    private GameObject enemiesEnabled;

    private void Start()
    {
        enemiesEnabled = GameObject.FindGameObjectWithTag("AllEnemies");
        enemiesEnabled.SetActive(true);
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            pauseEnabled = !pauseEnabled;

        if (pauseEnabled == true)
        {
            pauseImage.SetActive(true);
            Player.GetComponent<Camera_Control>().enabled = false;
            MainCamera.GetComponent<Camera_Control>().enabled = false;

            Player.GetComponent<characterController>().enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
            Pause();

        }
        else
        {
            pauseImage.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Player.GetComponent<Camera_Control>().enabled = true;
            MainCamera.GetComponent<Camera_Control>().enabled = true;

            Player.GetComponent<characterController>().enabled = true;
            Resume();
        }
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    void Pause()
    {
        Time.timeScale = 0;
        enemiesEnabled.SetActive(false);
    }
    void Resume()
    {
        Time.timeScale = 1;
        enemiesEnabled.SetActive(true);
    }





}
