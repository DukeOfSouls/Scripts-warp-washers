using UnityEngine;
using System.Collections;

public class RemoveScript : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "remover")
        {
            Destroy(gameObject);
        }
    }

}
