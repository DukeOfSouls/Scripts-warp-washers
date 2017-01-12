using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour
{
    public float speed;

	void Start ()
    {
	
	}
	
	void FixedUpdate ()
    {
        transform.position += Vector3.up * Time.deltaTime * speed;
    }
}
