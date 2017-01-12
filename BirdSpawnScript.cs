using UnityEngine;
using System.Collections;

public class BirdSpawnScript : MonoBehaviour
{

    public GameObject birdAlarm;
    public GameObject birdPrefab;
    public int wait;

    public void Begin()
    {
        StartCoroutine(SpawnBird());
        Debug.Log("im working");
    }

    IEnumerator SpawnBird()
    {
        wait = 5;
        yield return new WaitForSeconds(wait);
        StartCoroutine("ALARM");
        Invoke("stopALARM", 1f);
        Instantiate(birdPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(birdPrefab, transform.position + new Vector3 (0f, 3f, 0f), Quaternion.identity);
        Instantiate(birdPrefab, transform.position + new Vector3(0f, -3f, 0f), Quaternion.identity);
        yield return new WaitForSeconds(2f);
        StartCoroutine(SpawnBird());
    }

    IEnumerator ALARM()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            birdAlarm.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
            birdAlarm.GetComponent<SpriteRenderer>().enabled = false;
            yield return null;
        }
    }

    void stopALARM()
    {
        StopCoroutine("ALARM");
        birdAlarm.GetComponent<SpriteRenderer>().enabled = false;
    }
}
