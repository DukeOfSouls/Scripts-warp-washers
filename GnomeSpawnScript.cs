using UnityEngine;
using System.Collections;

public class GnomeSpawnScript : MonoBehaviour
{
    public GameObject gnomeAlarm;
    public GameObject gnomePrefab;
    public int wait;

    public void Begin()
    {
        StartCoroutine(SpawnGnome());
    }

    IEnumerator SpawnGnome()
    {
        wait = 7;
        yield return new WaitForSeconds(wait);
        StartCoroutine("ALARM");
        Invoke("stopALARM", 1f);
        Instantiate(gnomePrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        StartCoroutine(SpawnGnome());
    }

    IEnumerator ALARM()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            gnomeAlarm.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
            gnomeAlarm.GetComponent<SpriteRenderer>().enabled = false;
            yield return null;
        }
    }

    void stopALARM()
    {
        StopCoroutine("ALARM");
        gnomeAlarm.GetComponent<SpriteRenderer>().enabled = false;
    }
}
