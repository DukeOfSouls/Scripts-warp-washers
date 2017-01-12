using UnityEngine;
using System.Collections;

public class PlantScript : MonoBehaviour
{
    public Animator bite;
    int activeHash = Animator.StringToHash("hit");

    public float speed;
    public GameObject player, target;
    public bool eat;

    void Start()
    {
        eat = true;
        player = GameObject.Find("Player");
        target = GameObject.Find("Target");
    }


    void FixedUpdate()
    {
        Debug.Log(eat);

        if (eat == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.GetComponent<Transform>().position, speed * Time.deltaTime);
        }

        if(transform.position == target.transform.position)
        {
            Invoke("Away", 1f);
            bite.SetTrigger(activeHash);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        if(eat == false)
        {
            speed = 10;
            transform.position += Vector3.down * speed * Time.deltaTime;
            Invoke("Remove", 5f);
        }
    }

    void Away ()
    {
        eat = false;
    }

    void Remove ()
    {
        Destroy(gameObject);
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

    void Collider()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
