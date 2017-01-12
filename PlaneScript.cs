using UnityEngine;
using System.Collections;

public class PlaneScript : MonoBehaviour
{
    private float speed = 15f;

    public GameObject mainCamera;

	void Start ()
    {
        mainCamera = GameObject.Find("Main Camera");
        transform.parent = mainCamera.transform;
        Invoke("Collider", 1f);
        Invoke("Turn", 3.5f);
    }
	
	void FixedUpdate ()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
    }

    void Turn ()
    {
        speed = -20f;
        transform.eulerAngles = new Vector3(180f, 180f, 0f);
        transform.position = transform.position + new Vector3(0f, 16f, 0f);
    }

    void Collider ()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }


}
