using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sc_menu : MonoBehaviour
{
    public Animator transicion;
    public float TiempoTrancision = 1f;
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
        StartCoroutine(loadLevel(4));
        //SceneManager.LoadScene(4);
    }
    public void GoHome()
    {
        StartCoroutine(loadLevel(2));
        //SceneManager.LoadScene(2);
    }
    public void MainMenu()
    {
        StartCoroutine(loadLevel(0));
        //SceneManager.LoadScene(0);
    }
    public void menu()
    {
        StartCoroutine(loadLevel(0));
        //SceneManager.LoadScene(0);
    }
    public void lvl1()
    {
        StartCoroutine(loadLevel(6));
        //SceneManager.LoadScene(0);
    }
    public void lvl2()
    {
        StartCoroutine(loadLevel(7));
        //SceneManager.LoadScene(0);
    }
    public void lvl3()
    {
        StartCoroutine(loadLevel(8));
        //SceneManager.LoadScene(0);
    }
    public void lvl4()
    {
        StartCoroutine(loadLevel(9));
        //SceneManager.LoadScene(0);
    }
    public void lvl5()
    {
        StartCoroutine(loadLevel(10));
        //SceneManager.LoadScene(0);
    }
    
    public void closeGame()
    {
        Application.Quit();
    }

    IEnumerator loadLevel(int IndexEscena)
    {
        transicion.SetTrigger("Start");

        yield return new WaitForSeconds(TiempoTrancision);

        SceneManager.LoadScene(IndexEscena);


    }
}
    