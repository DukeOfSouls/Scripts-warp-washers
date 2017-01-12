using UnityEngine;
using System.Collections;

public class PlaneSpawnScript : MonoBehaviour
{
    public GameObject planeAlarm;
    public GameObject planePrefab;
    public int wait;

    public void Begin ()
    {
        StartCoroutine(SpawnPlane());
    }

    IEnumerator SpawnPlane ()
    {
        wait = 10;
        yield return new WaitForSeconds(wait);
        StartCoroutine("ALARM");
        Invoke("stopALARM", 1f);
        Instantiate(planePrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        StartCoroutine(SpawnPlane());
        
    }

    IEnumerator ALARM()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            planeAlarm.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
            planeAlarm.GetComponent<SpriteRenderer>().enabled = false;
            yield return null;
        }
    }

    void stopALARM()
    {
        StopCoroutine("ALARM");
        planeAlarm.GetComponent<SpriteRenderer>().enabled = false;
    }
}
