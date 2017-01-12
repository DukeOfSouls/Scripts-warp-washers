using UnityEngine;
using System.Collections;

public class GnomeScript : MonoBehaviour
{
    private Rigidbody RB;
    public Vector3 launchForce = new Vector3(0f, 0f, 0f);

	void Start ()
    {
        Invoke("Collider", 1f);
        RB = gameObject.GetComponent<Rigidbody>();
        RB.AddForce(launchForce, ForceMode.Impulse);
    }

    void Collider ()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
	

	void FixedUpdate ()
    {
       transform.up = RB.velocity;
    }
}
