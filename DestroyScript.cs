using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Outerwalls")
        {
            Destroy(gameObject);
        }
    }
}
