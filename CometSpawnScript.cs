using UnityEngine;
using System.Collections;

public class CometSpawnScript : MonoBehaviour
{
    public GameObject cometAlarm;
    public GameObject cometPrefab;
    public int wait;

    public void Begin()
    {
        StartCoroutine(SpawnComet());
    }
	
    IEnumerator SpawnComet ()
    {
        wait = 6;
        yield return new WaitForSeconds(wait);
        StartCoroutine("ALARM");
        Invoke("stopALARM", 1f);
        Instantiate(cometPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        StartCoroutine(SpawnComet());
    }

    IEnumerator ALARM()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            cometAlarm.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
            cometAlarm.GetComponent<SpriteRenderer>().enabled = false;
            yield return null;
        }
    }

    void stopALARM()
    {
        StopCoroutine("ALARM");
        cometAlarm.GetComponent<SpriteRenderer>().enabled = false;
    }
}
