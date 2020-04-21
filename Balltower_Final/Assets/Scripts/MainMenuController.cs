using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Button playButton;

    private void Awake()
    {
        playButton.onClick.AddListener(Play);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Play();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }

    }

    public void Play()
    {
        SceneManager.LoadScene("samscene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
