using UnityEngine;
using System.Collections;

public class SharkScript : MonoBehaviour
{
    public Animator bite;
    int activeHash = Animator.StringToHash("hit");

    private Rigidbody RB;
    public Vector3 launchForce = new Vector3(0f, 0f, 0f);

    public GameObject player;

    void Start ()
    {
        Invoke("Collider", 1f);
        RB = gameObject.GetComponent<Rigidbody>();
        RB.AddForce(launchForce, ForceMode.Impulse);

        player = GameObject.Find("Player");
    }


    void FixedUpdate()
    {
        transform.right = -RB.velocity;
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("cart"))
        {
            bite.SetTrigger(activeHash);
            player.GetComponent<SpriteRenderer>().enabled = false;
            player.GetComponent<ControlsScript>().enabled = false;
            player.GetComponent<HealthScript>().hearths = 0;
        }
    }

    void Collider ()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
