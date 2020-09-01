using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sc_menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayTest()
    {
        SceneManager.LoadScene(3);
    }
    public void GoOptions()
    {
        SceneManager.LoadScene(4);
    }
    public void GoHome()
    {
        SceneManager.LoadScene(2);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void menu()
    {
        SceneManager.LoadScene(0);
    }
    public void closeGame()
    {
        Application.Quit();
    }
}
    