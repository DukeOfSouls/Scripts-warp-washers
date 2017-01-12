using UnityEngine;
using System.Collections;

public class CloudScript : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject player, cart, background;

	void Start ()
    {
        mainCamera = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");
        cart = GameObject.Find("Cart");
        background = GameObject.Find("Background");
        Debug.Log("should be a cloud");
    }

    void startStartSpawn ()
    {
        mainCamera.GetComponent<SpawnScript>().StartSpawn();
    }

    void OnTriggerEnter (Collider col)
    {
        if(col.CompareTag("cart"))
        {
            background.GetComponent<BackgroundScript>().timeZone++;
            mainCamera.GetComponent<SpawnScript>().enabled = true;
            cart.layer = 8;
            player.GetComponent<BoxCollider>().enabled = true;
            player.GetComponent<HealthScript>().hearths = 3;
            player.GetComponent<ControlsScript>().enabled = true;
            mainCamera.GetComponent<MoveScript>().speed = 5f;
            mainCamera.GetComponent<BuildingScript>().wait = 1.09f;
            Invoke("startStartSpawn", 0.5f);
        }
    }
}
