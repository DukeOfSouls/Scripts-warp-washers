using UnityEngine;
using System.Collections;

public class PaperSpawnScript: MonoBehaviour
{
    public GameObject paperAlarm;
    public GameObject paperPrefab;
    public int wait;

	public void Begin()
    {
        StartCoroutine(SpawnPaper());
    }

    IEnumerator SpawnPaper()
    {
        wait = 6;
        yield return new WaitForSeconds(wait);
        StartCoroutine("ALARM");
        Invoke("stopALARM", 1f);
        Instantiate(paperPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        StartCoroutine(SpawnPaper());
    }

    IEnumerator ALARM()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            paperAlarm.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
            paperAlarm.GetComponent<SpriteRenderer>().enabled = false;
            yield return null;
        }
    }

    void stopALARM()
    {
        StopCoroutine("ALARM");
        paperAlarm.GetComponent<SpriteRenderer>().enabled = false;
    }
}
