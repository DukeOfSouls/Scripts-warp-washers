using UnityEngine;
using System.Collections;

public class CowScript : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject milk;

    private float spinSpeed = -100f;
    private float moveSpeed = -5f;
    private float fallSpeed = -5f;

    private bool MILK = false;

	void Start ()
    {
        mainCamera = GameObject.Find("Main Camera");
	}

	void FixedUpdate ()
    {
        if(MILK == true)
        {
            Color color = milk.GetComponent<SpriteRenderer>().material.color;
            color.a -= 0.03f;
            milk.GetComponent<SpriteRenderer>().material.color = color;
        }

        if (milk.GetComponent<SpriteRenderer>().material.color.a < 0f)
        {
            MILK = false;
            milk.SetActive(false);
        }

        transform.Rotate(Vector3.forward * Time.deltaTime * spinSpeed);
        transform.position += Vector3.right * Time.deltaTime * moveSpeed;
        transform.position += Vector3.up * Time.deltaTime * fallSpeed;
	}

    void OnTriggerEnter (Collider col)
    {
        if(col.CompareTag("WallL"))
        {
            Debug.Log("banaan");
            moveSpeed = 5f;
        }

        if(col.CompareTag("WallR"))
        {
            moveSpeed = -5f;
        }

        if(col.CompareTag("cart"))
        {
            Debug.Log("banaan");
            milk.transform.parent = mainCamera.transform;
            milk.transform.position = mainCamera.transform.position + new Vector3 (0.5f, 5f, 0.5f);
            milk.transform.eulerAngles = new Vector3(0f, 0f, -90f);
            milk.GetComponent<SpriteRenderer>().enabled = true;
            milk.GetComponent<Animator>().enabled = true;
            Invoke("Milk", 5f);
        }
    }

    void Milk ()
    {
        MILK = true;
    }
}
