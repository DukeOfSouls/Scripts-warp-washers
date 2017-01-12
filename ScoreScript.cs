using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour
{
    public TextMesh score;
    public int scoreCount;

	void Start ()
    {
        scoreCount = 0;
	}
	

	void Update ()
    {
        score.text = scoreCount.ToString() + "/10";
        if (scoreCount >= 10) score.text = scoreCount.ToString() + "/20";
        if (scoreCount >= 20) score.text = scoreCount.ToString() + "/40";
        if (scoreCount >= 40) score.text = scoreCount.ToString() + "/60";
        if (scoreCount >= 60) score.text = scoreCount.ToString() + "/80";
        //if (scoreCount >= 100) score.text = scoreCount.ToString();
    }
}
