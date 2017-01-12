using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour
{
    public Sprite BG2, BG3, BG4, BG5;
    public ScoreScript scoreScript;
    public int timeZone;

    void Start ()
    {
        timeZone = 0;
    }
	void Update ()
    {
        //Debug.Log(timeZone);

        if (timeZone == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = BG2;
        }

        else if (timeZone == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = BG3;
        }

        else if (timeZone == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = BG4;
        }

        else if (timeZone == 4)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = BG5;
        }

        else if (timeZone == 5)
        {
            Destroy(gameObject);
        }
    }
}
