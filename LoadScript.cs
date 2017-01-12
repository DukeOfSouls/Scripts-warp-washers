using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadScript : MonoBehaviour
{
    public TextMesh highscore;

	void Start ()
    {
        InfoScript.info.Load();
    }

    void Update ()
    {
        highscore.text = InfoScript.info.highscore.ToString();
    }
	
}
