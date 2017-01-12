using UnityEngine;
using System.Collections;

public class SatelliteSpawnScript : MonoBehaviour
{
    public GameObject satelliteAlarm;
    public GameObject satellitePrefab;
    public int wait;

    public void Begin()
    {
        StartCoroutine("SpawnSatellite");
    }

    IEnumerator SpawnSatellite()
    {
        wait = 10;
        yield return new WaitForSeconds(wait);
        StartCoroutine("ALARM");
        Invoke("stopALARM", 1f);
        Instantiate(satellitePrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        StartCoroutine(SpawnSatellite());
    }

    IEnumerator ALARM()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            satelliteAlarm.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
            satelliteAlarm.GetComponent<SpriteRenderer>().enabled = false;
            yield return null;
        }
    }

    void stopALARM()
    {
        StopCoroutine("ALARM");
        satelliteAlarm.GetComponent<SpriteRenderer>().enabled = false;
    }
}
