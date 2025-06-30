using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("score", highscore);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager != null)
        {
            getScore();

            PlayerPrefs.SetInt("score", highscore);
            PlayerPrefs.SetInt("highscore", REALhighscore);
        }
    }

    public GameManager gameManager;

    float score;
    int highscore;

    int REALhighscore;

    public float pScore;

    public void getScore()
    {
        if (gameManager != null)
        {
            this.score = gameManager.score;
        }
        highscore = (int)score;
        pScore = highscore;

        if (PlayerPrefs.GetInt("highscore") <= highscore)
        {
            REALhighscore = (int)highscore;
            PlayerPrefs.SetInt("highscore", REALhighscore);
        }
    }
}
