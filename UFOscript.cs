using UnityEngine;
using System.Collections;

public class UFOscript : MonoBehaviour
{
    Vector3 launchForce = new Vector3(0f, -5f, 0f);
    public GameObject target, mainCamera, laserPrefab, explosion;
    private float speed = 5f;
    private float moveSpeed = -5f;
    public bool pos, away;

	void Start ()
    {
        Invoke("Away", 8f);
        StartCoroutine("ShootLaser");
        pos = true;
        away = false;
        target = GameObject.Find("Target");
        mainCamera = GameObject.Find("Main Camera");
	}

    IEnumerator ShootLaser ()
    {
        yield return new WaitForSeconds(2);
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Transform>().eulerAngles = new Vector3(0f, 0f, 90f);
        laser.GetComponent<Rigidbody>().AddForce(launchForce, ForceMode.Impulse);
        StartCoroutine("ShootLaser");
    }

	void FixedUpdate ()
    {
        if(away == true)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            Invoke("Remove", 2f);
        }

	    if(pos == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.GetComponent<Transform>().position, speed * Time.deltaTime);
        }

        if(transform.position == target.GetComponent<Transform>().position)
        {
            transform.parent = mainCamera.transform;
            pos = false;
        }

        if (pos == false)
        {
            transform.position += Vector3.right * Time.deltaTime * moveSpeed;
        }
	}

    void OnTriggerEnter (Collider col)
    {
        if (col.CompareTag("WallL"))
        {
            moveSpeed = 5f;
        }

        if (col.CompareTag("WallR"))
        {
            moveSpeed = -5f;
        }

        if (col.CompareTag("cart"))
        {
            StopAllCoroutines();
            transform.DetachChildren();
            explosion.GetComponent<SpriteRenderer>().enabled = true;
            explosion.GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Invoke("Remove", 1f);
        }
    }

    void Away ()
    {
        away = true;
    }

    void Remove ()
    {
        Destroy(gameObject);
    }
}
