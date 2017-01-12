using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{
    public ScoreScript scoreScript;

    public GameObject birdSpawn, cometSpawn, cowSpawn, gnomeSpawn, paperSpawn, planeSpawn, plantSpawn, satelliteSpawn, sharkSpawn, storkSpawn, UFOspawn;

    private void Start()
    {
        Invoke("StartSpawn", 1f);
    }

    public void StartSpawn ()
    {
        Debug.Log("doing it");
        if (scoreScript.scoreCount <= 10)
        {
            sharkSpawn.GetComponent<SharkSpawnScript>().Begin();
            birdSpawn.GetComponent<BirdSpawnScript>().Begin();
            paperSpawn.GetComponent<PaperSpawnScript>().Begin();
        }

        if (scoreScript.scoreCount >= 11 && scoreScript.scoreCount <= 20)
        {
            storkSpawn.GetComponent<StorkSpawnScript>().Begin();
            sharkSpawn.GetComponent<SharkSpawnScript>().Begin();
            birdSpawn.GetComponent<BirdSpawnScript>().Begin();
            paperSpawn.GetComponent<PaperSpawnScript>().Begin();
        }

        if (scoreScript.scoreCount >= 21 && scoreScript.scoreCount <= 40)
        {
            storkSpawn.GetComponent<StorkSpawnScript>().Begin();
            birdSpawn.GetComponent<BirdSpawnScript>().Begin();
            sharkSpawn.GetComponent<SharkSpawnScript>().Begin();
            planeSpawn.GetComponent<PlaneSpawnScript>().Begin();
            gnomeSpawn.GetComponent<GnomeSpawnScript>().Begin();
        }

        if (scoreScript.scoreCount >= 41 && scoreScript.scoreCount <= 60)
        {
            gnomeSpawn.GetComponent<GnomeSpawnScript>().Begin();
            paperSpawn.GetComponent<PaperSpawnScript>().Begin();
            sharkSpawn.GetComponent<SharkSpawnScript>().Begin();
            plantSpawn.GetComponent<PlantSpawnScript>().Begin();
            cometSpawn.GetComponent<CometSpawnScript>().Begin();

        }

        if (scoreScript.scoreCount >= 61 && scoreScript.scoreCount <= 80)
        {
            storkSpawn.GetComponent<StorkSpawnScript>().Begin();
            birdSpawn.GetComponent<BirdSpawnScript>().Begin();
            sharkSpawn.GetComponent<SharkSpawnScript>().Begin();
            plantSpawn.GetComponent<PlantSpawnScript>().Begin();
            gnomeSpawn.GetComponent<GnomeSpawnScript>().Begin();
        }

        if (scoreScript.scoreCount >= 81)
        {
            satelliteSpawn.GetComponent<SatelliteSpawnScript>().Begin();
            UFOspawn.GetComponent<UFOspawnScript>().Begin();
            cowSpawn.GetComponent<CowSpawnScript>().Begin();
            sharkSpawn.GetComponent<SharkSpawnScript>().Begin();
            plantSpawn.GetComponent<PlantSpawnScript>().Begin();
            cometSpawn.GetComponent<CometSpawnScript>().Begin();
        }
    }

	void Update ()
    {

	    if(scoreScript.scoreCount <= 10)
        {
            birdSpawn.SetActive(true);
            paperSpawn.SetActive(true);
            sharkSpawn.SetActive(true);
        }

        if(scoreScript.scoreCount >= 11 && scoreScript.scoreCount <= 20)
        {
            storkSpawn.SetActive(true);
            birdSpawn.SetActive(true);
            paperSpawn.SetActive(true);
            sharkSpawn.SetActive(true);
        }

        if (scoreScript.scoreCount >= 21 && scoreScript.scoreCount <= 40)
        {
            storkSpawn.SetActive(true);
            birdSpawn.SetActive(true);
            gnomeSpawn.SetActive(true);
            planeSpawn.SetActive(true);
            sharkSpawn.SetActive(true);
        }

        if (scoreScript.scoreCount >= 41 && scoreScript.scoreCount <= 60)
        {
            gnomeSpawn.SetActive(true);
            paperSpawn.SetActive(true);
            plantSpawn.SetActive(true);
            sharkSpawn.SetActive(true);
            cometSpawn.SetActive(true);
        }

        if (scoreScript.scoreCount >= 61 && scoreScript.scoreCount <= 80)
        {
            storkSpawn.SetActive(true);
            birdSpawn.SetActive(true);
            plantSpawn.SetActive(true);
            sharkSpawn.SetActive(true);
            gnomeSpawn.SetActive(true);
        }

        if (scoreScript.scoreCount >= 81)
        {
            plantSpawn.SetActive(true);
            sharkSpawn.SetActive(true);
            cometSpawn.SetActive(true);
            planeSpawn.SetActive(true);
            satelliteSpawn.SetActive(true);
            UFOspawn.SetActive(true);
            cowSpawn.SetActive(true);
        }




    }
}
