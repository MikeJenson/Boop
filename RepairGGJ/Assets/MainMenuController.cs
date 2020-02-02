using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Scene_Level");
    }

    public void home()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
