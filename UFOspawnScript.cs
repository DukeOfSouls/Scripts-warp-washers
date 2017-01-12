using UnityEngine;
using System.Collections;

public class UFOspawnScript : MonoBehaviour
{
    public GameObject UFOalarm;
    public GameObject UFOprefab;
    public int wait;

    public void Begin ()
    {
        StartCoroutine("SpawnUFO");
    }

    IEnumerator SpawnUFO()
    {
        wait = 15;
        yield return new WaitForSeconds(wait);
        StartCoroutine("ALARM");
        Invoke("stopALARM", 1f);
        Instantiate(UFOprefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        StartCoroutine(SpawnUFO());
    }

    IEnumerator ALARM()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            UFOalarm.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
            UFOalarm.GetComponent<SpriteRenderer>().enabled = false;
            yield return null;
        }
    }

    void stopALARM()
    {
        StopCoroutine("ALARM");
        UFOalarm.GetComponent<SpriteRenderer>().enabled = false;
    }
}
