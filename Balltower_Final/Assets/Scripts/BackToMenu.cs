using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public Button menuButton;

    private void Awake()
    {
        menuButton.onClick.AddListener(Menu);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Menu();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }

    }

    public void Menu()
    {
        SceneManager.LoadScene("intro");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
