using UnityEngine;
using System.Collections;

public class CowSpawnScript : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject cowAlarm;
    public GameObject cowPrefab;
    public int wait;

    public void Begin()
    {
        StartCoroutine("SpawnCow");
    }

    IEnumerator SpawnCow()
    {
        wait = 15;
        yield return new WaitForSeconds(wait);
        StartCoroutine("ALARM");
        Invoke("stopALARM", 1f);
        Instantiate(cowPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        StartCoroutine(SpawnCow());
    }

    IEnumerator ALARM()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            cowAlarm.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
            cowAlarm.GetComponent<SpriteRenderer>().enabled = false;
            yield return null;
        }
    }

    void stopALARM()
    {
        StopCoroutine("ALARM");
        cowAlarm.GetComponent<SpriteRenderer>().enabled = false;
    }
}
