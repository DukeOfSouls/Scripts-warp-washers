using UnityEngine;
using System.Collections;

public class BuildingScript : MonoBehaviour
{
    public GameObject birdSpawn, cometSpawn, cowSpawn, gnomeSpawn, paperSpawn, planeSpawn, plantSpawn, satelliteSpawn, sharkSpawn, storkSpawn, UFOspawn;

    public SpawnScript spawnScript;
    public MoveScript moveScript;
    public ScoreScript scoreScript;
    public GameObject cart;
    public GameObject player;

    private GameObject[] buildingPrefabs = new GameObject[12];
    public GameObject cloudPrefab, blockPrefab;
    public GameObject building1A, building1B, building2A, building2B, building3A, building3B, building4A, building4B, building5A, building5B, building6A, building6B;
    private GameObject[] stainPrefabs = new GameObject[6];
    public GameObject stain1, stain2, stain3, stain4, stain5, stain6;

    public float wait;
    private int index;
    private int lastIndex = -1;
    private bool whichBuilding = true;
    private float[] spots = new float[3];
    private int i = 0;
    private int infin = 100;
    private int randomNumber, randomPlace;
    private int lastNumber = -1;

    void Start()
    {

        spots[0] = -4.4f;
        spots[1] = 0f;
        spots[2] = 4.4f;

        buildingPrefabs[0] = building1A;
        buildingPrefabs[1] = building1B;
        buildingPrefabs[2] = building2A;
        buildingPrefabs[3] = building2B;
        buildingPrefabs[4] = building3A;
        buildingPrefabs[5] = building3B;
        buildingPrefabs[6] = building4A;
        buildingPrefabs[7] = building4B;
        buildingPrefabs[8] = building5A;
        buildingPrefabs[9] = building5B;
        buildingPrefabs[10] = building6A;
        buildingPrefabs[11] = building6B;

        stainPrefabs[0] = stain1;
        stainPrefabs[1] = stain2;
        stainPrefabs[2] = stain3;
        stainPrefabs[3] = stain4;
        stainPrefabs[4] = stain5;
        stainPrefabs[5] = stain6;

        StartCoroutine(BuildingSpawn());

        for(i = 0 ; i < 5 ; i++)
        {
            whichBuilding = !whichBuilding;

            if (whichBuilding == true)
            {
                 Instantiate(buildingPrefabs[0], new Vector3(0f, i * 5.5f, 25f), Quaternion.identity);
            }

            if (whichBuilding == false)
            {
                Instantiate(buildingPrefabs[1], new Vector3(0f, i * 5.5f, 25f), Quaternion.identity);
            }

            do
            {
                index = Random.Range(0, 3);
            }
            while (index == lastIndex);
            lastIndex = index;

                switch (index)
                {
                    case 0:
                    Instantiate(stainPrefabs[Random.Range(0, 6)], new Vector3(-4.4f, i * 5.5f, 19f), Quaternion.identity);
                    break;

                    case 1:
                    Instantiate(stainPrefabs[Random.Range(0, 6)], new Vector3(0f, i * 5.5f, 19f), Quaternion.identity);
                    break;

                    case 2:
                    Instantiate(stainPrefabs[Random.Range(0, 6)], new Vector3(4.4f, i * 5.5f, 19f), Quaternion.identity);
                    break;
                }
           

            if (i == 4) whichBuilding = false;
        }
    }

    public void StartBuildingSpawn()
    {
        StartCoroutine(BuildingSpawn());
    }

    IEnumerator BuildingSpawn()
    {
        for (i = 5 ; i < infin ; i++)
        {
            infin++;

            whichBuilding = ! whichBuilding;

            if (whichBuilding == true && scoreScript.scoreCount <= 10)
            {
                Instantiate(buildingPrefabs[0], new Vector3(0f, i * 5.5f, 25f), Quaternion.identity);
            }

            else if (whichBuilding == true && scoreScript.scoreCount >= 11  && scoreScript.scoreCount <= 20)
            {
                Instantiate(buildingPrefabs[2], new Vector3(0f, i * 5.5f, 25f), Quaternion.identity);
            }

            else if (whichBuilding == true && scoreScript.scoreCount >= 21 && scoreScript.scoreCount <= 40)
            {
                Instantiate(buildingPrefabs[4], new Vector3(0f, i * 5.5f, 25f), Quaternion.identity);
            }

            else if (whichBuilding == true && scoreScript.scoreCount >= 41 && scoreScript.scoreCount <= 60)
            {
                Instantiate(buildingPrefabs[6], new Vector3(0f, i * 5.5f, 25f), Quaternion.identity);
            }

            else if (whichBuilding == true && scoreScript.scoreCount >= 61 && scoreScript.scoreCount <= 80)
            {
                Instantiate(buildingPrefabs[8], new Vector3(0f, i * 5.5f, 25f), Quaternion.identity);
            }

            else if (whichBuilding == true && scoreScript.scoreCount >= 81)
            {
                Instantiate(buildingPrefabs[10], new Vector3(0f, i * 5.5f, 25f), Quaternion.identity);
            }

            if (whichBuilding == false && scoreScript.scoreCount <= 10)
            {
                Instantiate(buildingPrefabs[1], new Vector3(0f, i * 5.5f, 25f), Quaternion.identity);
            }

            else if (whichBuilding == false && scoreScript.scoreCount >= 11 && scoreScript.scoreCount <= 20)
            {
                Instantiate(buildingPrefabs[3], new Vector3(0f, i * 5.5f, 25f), Quaternion.identity);
            }

            else if (whichBuilding == false && scoreScript.scoreCount >= 21 && scoreScript.scoreCount <= 40)
            {
                Instantiate(buildingPrefabs[5], new Vector3(0f, i * 5.5f, 25f), Quaternion.identity);
            }

            else if (whichBuilding == false && scoreScript.scoreCount >= 41 && scoreScript.scoreCount <= 60)
            {
                Instantiate(buildingPrefabs[7], new Vector3(0f, i * 5.5f, 25f), Quaternion.identity);
            }

            else if (whichBuilding == false && scoreScript.scoreCount >= 61 && scoreScript.scoreCount <= 80)
            {
                Instantiate(buildingPrefabs[9], new Vector3(0f, i * 5.5f, 25f), Quaternion.identity);
            }

            else if (whichBuilding == false && scoreScript.scoreCount >= 81)
            {
                Instantiate(buildingPrefabs[11], new Vector3(0f, i * 5.5f, 25f), Quaternion.identity);
            }

            do
            {
                index = Random.Range(0, 3);
            }
            while (index == lastIndex);
            lastIndex = index;

            switch (index)
            {
                case 0:
                    Instantiate(stainPrefabs[Random.Range(0, 6)], new Vector3(-4.4f, i * 5.5f, 19f), Quaternion.identity);
                    break;

                case 1:
                    Instantiate(stainPrefabs[Random.Range(0, 6)], new Vector3(0f, i * 5.5f, 19f), Quaternion.identity);
                    break;

                case 2:
                    Instantiate(stainPrefabs[Random.Range(0, 6)], new Vector3(4.4f, i * 5.5f, 19f), Quaternion.identity);
                    break;
            }

           /* do
            {
                randomNumber = Random.Range(0, 3);
            }
            while (randomNumber == lastNumber);
            lastNumber = randomNumber;

            if (randomNumber == 2)
            {
                randomPlace = Random.Range(0, 7);

                switch (randomPlace)
                {
                    case 0:
                        Instantiate(blockPrefab, new Vector3(-4.23f,( i * 5.5f) -1.5f, 18.4f), Quaternion.identity);
                        break;

                    case 1:
                        Instantiate(blockPrefab, new Vector3(0.13f, (i * 5.5f) -1.5f, 18.4f), Quaternion.identity);
                        break;

                    case 2:
                        Instantiate(blockPrefab, new Vector3(4.32f, (i * 5.5f) -1.5f, 18.4f), Quaternion.identity);
                        break;
                }
            }*/

            yield return new WaitForSeconds(wait);
        }
    }

    void Update ()
    {
        if(scoreScript.scoreCount == 10 || scoreScript.scoreCount == 20 || scoreScript.scoreCount == 40 || scoreScript.scoreCount == 60 || scoreScript.scoreCount == 80)
        {
            spawnScript.enabled = false;

            storkSpawn.SetActive(false);
            birdSpawn.SetActive(false);
            paperSpawn.SetActive(false);
            gnomeSpawn.SetActive(false);
            plantSpawn.SetActive(false);
            sharkSpawn.SetActive(false);
            cometSpawn.SetActive(false);
            planeSpawn.SetActive(false);
            satelliteSpawn.SetActive(false);
            UFOspawn.SetActive(false);
            cowSpawn.SetActive(false);

            moveScript.speed = 10f;
            wait = 0.5f;
            cart.layer = 19;
            player.GetComponent<BoxCollider>().enabled = false;
            player.GetComponent<ControlsScript>().enabled = false;
            Instantiate(cloudPrefab, new Vector3(0f, i * 5.5f, 18f), Quaternion.identity);
            scoreScript.scoreCount += 1;
        }
    }



}