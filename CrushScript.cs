using UnityEngine;
using System.Collections;

public class CrushScript : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCamera;

    void OnTriggerEnter (Collider col)
    {
        if(col.CompareTag("remover"))
        {
            player.GetComponent<HealthScript>().hearths = 0;
        }
    }
}
