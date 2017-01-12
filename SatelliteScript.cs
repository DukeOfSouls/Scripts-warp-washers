using UnityEngine;
using System.Collections;

public class SatelliteScript : MonoBehaviour
{
    private float spinSpeed = -80f;
    private float moveSpeed = 4f;
    private float fallSpeed = -4f;

    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * spinSpeed);
        transform.position += Vector3.right * Time.deltaTime * moveSpeed;
        transform.position += Vector3.up * Time.deltaTime * fallSpeed;
    }
}
