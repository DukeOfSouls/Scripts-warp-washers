using UnityEngine;
using System.Collections;

public class PlantSpawnScript : MonoBehaviour
{
    public GameObject plantPrefab;
    public GameObject plantAlarm;
    private int wait;

    public void Begin ()
    {
        StartCoroutine(SpawnPlant());
    }

    IEnumerator SpawnPlant()
    {
        wait = Random.Range(10, 20);
        yield return new WaitForSeconds(wait);
        StartCoroutine("ALARM");
        Invoke("stopALARM", 1f);
        yield return new WaitForSeconds(2f);
        Instantiate(plantPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        StartCoroutine(SpawnPlant());
    }

    IEnumerator ALARM()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            plantAlarm.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
            plantAlarm.GetComponent<SpriteRenderer>().enabled = false;
            yield return null;
        }
    }

    void stopALARM()
    {
        StopCoroutine("ALARM");
        plantAlarm.GetComponent<SpriteRenderer>().enabled = false;
    }
}
