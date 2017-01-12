using UnityEngine;
using System.Collections;

public class StorkScript : MonoBehaviour
{
    private float speed = 8f;
    public GameObject bomb;

	void FixedUpdate ()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
        transform.position += Vector3.up * Time.deltaTime * 5f;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("player"))
        {
            bomb.transform.parent = null;
            bomb.GetComponent<Rigidbody>().useGravity = true;
            bomb.GetComponent<Rigidbody>().AddForce(new Vector3(0f, -5f, 0f), ForceMode.Impulse);
            bomb.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, 0f), ForceMode.Impulse);
        }

    }
}
