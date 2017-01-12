using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour
{
    public GameObject backdrop;
    public GameObject loading;
    public GameObject load;

    void Start()
    {
        load.SetActive(false);
        backdrop.SetActive(false);
        loading.SetActive(false);
    }

    public void StartGame()
    {
        StartCoroutine(LoadStartGame());
    }

    IEnumerator LoadStartGame()
    {

        load.SetActive(true);
        backdrop.SetActive(true);
        loading.SetActive(true);
        AsyncOperation async = Application.LoadLevelAsync(1);
        yield return null;
    }

    public void Info()
    {
        StartCoroutine("LoadInfo");
    }

    IEnumerator LoadInfo ()
    {
        load.SetActive(true);
        backdrop.SetActive(true);
        loading.SetActive(true);
        AsyncOperation async = Application.LoadLevelAsync(3);
        yield return null;
    }

    public void Credits()
    {
        StartCoroutine("LoadCredits");
    }

    IEnumerator LoadCredits()
    {
        load.SetActive(true);
        backdrop.SetActive(true);
        loading.SetActive(true);
        AsyncOperation async = Application.LoadLevelAsync(2);
        yield return null;
    }

    public void Menu()
    {
        StartCoroutine("LoadMenu");
    }

    IEnumerator LoadMenu()
    {
        load.SetActive(true);
        backdrop.SetActive(true);
        loading.SetActive(true);
        AsyncOperation async = Application.LoadLevelAsync(0);
        yield return null;
    }



    public void Exit()
    {
        Application.Quit();
    }

    void OnApplicationQuit()
    {
        InfoScript.info.Save();
    }

}