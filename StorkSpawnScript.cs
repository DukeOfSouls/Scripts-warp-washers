using UnityEngine;
using System.Collections;

public class StorkSpawnScript: MonoBehaviour
{
    public GameObject storkAlarm;
    public GameObject storkPrefab;
    public int wait;

	public void Begin ()
    {
        StartCoroutine(SpawnStork());
	}

    IEnumerator SpawnStork ()
    {
        wait = 8;
        yield return new WaitForSeconds(wait);
        StartCoroutine("ALARM");
        Invoke("stopALARM", 1f);
        Instantiate(storkPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        StartCoroutine(SpawnStork());
    }

    IEnumerator ALARM ()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            storkAlarm.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
            storkAlarm.GetComponent<SpriteRenderer>().enabled = false;
            yield return null;
        }
    }

    void stopALARM ()
    {
        StopCoroutine("ALARM");
        storkAlarm.GetComponent<SpriteRenderer>().enabled = false;
    }

    

}
