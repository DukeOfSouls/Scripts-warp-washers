using UnityEngine;
using System.Collections;

public class BirdScript : MonoBehaviour
{

    private float speed = 8f;

    void FixedUpdate()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
        transform.position += Vector3.up * Time.deltaTime * 4f;
    }
}
