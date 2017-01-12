using UnityEngine;
using System.Collections;

public class SphereOverlapScript : MonoBehaviour
{
    public float sphereSize;
    public bool onStain;
    public GameObject currentStain;

    void Start()
    {
        currentStain = null;
    }

    void Update ()
    {
        checkOverlap(transform.position, sphereSize);
    }

    void checkOverlap(Vector3 center, float radius)
    {
       Collider[] col = Physics.OverlapSphere(center, radius);

        onStain = false;

        foreach(Collider c in col)
        {
            if (c.transform.CompareTag("stain"))
            {
                onStain = true;
                currentStain = c.gameObject;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0.5f, 0f, 0f, 0.5f);
        Gizmos.DrawSphere(transform.position, sphereSize);
    }

}
