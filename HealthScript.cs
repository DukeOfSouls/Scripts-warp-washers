using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour
{
    public ControlsScript controlscript;
    public GameObject cabels, cart, player;
    public GameOverScript gameOverScript;
    public SpriteRenderer health1, health2, health3;
    public Sprite fullHearth, emptyHearth;
    public int hearths = 3;

	void Start ()
    {
	
	}

	void Update ()
    {
        if (hearths == 3)
        {
            health1.sprite = fullHearth;
            health2.sprite = fullHearth;
            health3.sprite = fullHearth;
        }

        if (hearths == 2)
        {
            health1.sprite = fullHearth;
            health2.sprite = fullHearth;
            health3.sprite = emptyHearth;
        }

        if (hearths == 1)
        {
            health1.sprite = fullHearth;
            health2.sprite = emptyHearth;
            health3.sprite = emptyHearth;
        }

        if (hearths == 0)
        {
            health1.sprite = emptyHearth;
            health2.sprite = emptyHearth;
            health3.sprite = emptyHearth;

            controlscript.enabled = false;
            cabels.SetActive(false);
            cart.GetComponent<BoxCollider>().enabled = false;
            player.GetComponent<BoxCollider>().enabled = false;
            cart.GetComponent<Rigidbody>().useGravity = true;
            cart.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Invoke("GameOver", 2f);
          
        }
    }

    void GameOver ()
    {
        gameOverScript.enabled = true;
    }
}
