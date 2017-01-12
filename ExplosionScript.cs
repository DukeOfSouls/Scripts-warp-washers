using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour
{
    public GameObject explosion;

	void Start ()
    {

	}

    void OnTriggerEnter (Collider col)
    {
        if (col.CompareTag("cart"))
        {
            Debug.Log("explode");
            transform.DetachChildren();
            explosion.GetComponent<SpriteRenderer>().enabled = true;
            explosion.GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void Destroy ()
    {
        Destroy(gameObject);
    }
}
