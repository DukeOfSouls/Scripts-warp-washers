using UnityEngine;
using System.Collections;

public class SharkSpawnScript : MonoBehaviour
{
    public GameObject sharkPrefab;
    public GameObject sharkAlarm;
    private int wait;

	public void Begin ()
    {
        StartCoroutine(SpawnShark());
	}
	
    IEnumerator SpawnShark()
    {
        wait = Random.Range(10, 20);
        yield return new WaitForSeconds(wait);
        StartCoroutine("ALARM");
        Invoke("stopALARM", 1f);
        yield return new WaitForSeconds(2f);
        Instantiate(sharkPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        StartCoroutine(SpawnShark());
    }

    IEnumerator ALARM()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            sharkAlarm.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
            sharkAlarm.GetComponent<SpriteRenderer>().enabled = false;
            yield return null;
        }
    }

    void stopALARM()
    {
        StopCoroutine("ALARM");
        sharkAlarm.GetComponent<SpriteRenderer>().enabled = false;
    }
}
