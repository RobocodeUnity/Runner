using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScorePlayer : MonoBehaviour
{
    public Text scoreText;
    private int score;
    private float timeScore;
    void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeScore += Time.deltaTime * 10;
        score = (int)timeScore;
        scoreText.text = score.ToString();
      //  Debug.Log("time" + Time.time);

    }
}
