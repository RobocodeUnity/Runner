using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScorePlayer : MonoBehaviour
{
    public Text scoreText;
    private int score;
    private float timeScore;
    public PlayerMotor playerMotor;
    private static int record;
    public Text textRecord;
    void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerMotor.isDead)
        {
            timeScore += Time.deltaTime * 10;
            score = (int)timeScore;
            scoreText.text = score.ToString();
        }
        else
        {

            if (record < timeScore)
            {
                record = score;
                textRecord.text = "Record: " + record.ToString();
            }
        }

    }
}
