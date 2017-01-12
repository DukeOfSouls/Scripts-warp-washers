using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject stamp, retry, menu;

    void Start()
    {
        if (InfoScript.info.highscore < mainCamera.GetComponent<ScoreScript>().scoreCount)
        { 
            InfoScript.info.highscore = mainCamera.GetComponent<ScoreScript>().scoreCount;
        }

        InfoScript.info.Save();

        stamp.SetActive(true);
        Invoke("Retry", 2f);    
    }
	
    void Retry ()
    {
        stamp.GetComponent<SpriteRenderer>().enabled = false;
        menu.SetActive(true);
        retry.SetActive(true);
    }


}
