using UnityEngine;
using System.Collections;

public class DamageScript : MonoBehaviour
{
    public HealthScript healthscript;
    public GameObject cart, cabels, player;

    void Start ()
    {
        healthscript = GameObject.Find("Player").GetComponent<HealthScript>();
        cart = GameObject.Find("Cart");
        cabels = GameObject.Find("Cabels");
        player = GameObject.Find("Player");
    }
	
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("cart"))
        {
            healthscript.hearths -= 1;
            Invoke("Damage", 0.1f);
        }
    }

    void StartDamage()
    {
        StartCoroutine("Damage");
    }

    IEnumerator Damage()
    {
        cart.tag = "None";
        cart.GetComponent<SpriteRenderer>().enabled = false;
        cabels.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        cart.GetComponent<SpriteRenderer>().enabled = true;
        cabels.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        cart.GetComponent<SpriteRenderer>().enabled = false;
        cabels.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        cart.GetComponent<SpriteRenderer>().enabled = true;
        cabels.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        cart.GetComponent<SpriteRenderer>().enabled = false;
        cabels.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        cart.GetComponent<SpriteRenderer>().enabled = true;
        cabels.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        cart.tag = "cart";

    }


}
