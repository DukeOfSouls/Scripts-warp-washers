using UnityEngine;
using System.Collections;

public class PaperScript : MonoBehaviour
{
    private float number;
    public float speed = 2f;
    public float waveSpeed;
    public float waveHeight;

	void Start ()
    {
	    
	}
	

	void FixedUpdate ()
    {
        number += waveSpeed;

        float wave = Mathf.Cos(number) * waveHeight;

        transform.position = new Vector3(transform.position.x + speed, transform.position.y + wave, transform.position.z);
	}

}
