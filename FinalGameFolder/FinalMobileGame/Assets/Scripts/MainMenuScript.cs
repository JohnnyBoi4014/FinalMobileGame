using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    public int MenuScore;
    
    // Start is called before the first frame update
    void Start()
    {
        if (scoreText != null)
        {
            MenuScore = PlayerPrefs.GetInt("score");
            scoreText.text = "Score: " + MenuScore;

            highscoreText.text = "Score: " + PlayerPrefs.GetInt("highscore").ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGameComp()
    {
        SceneManager.LoadScene(1);
    }
    public void StartGameMobile()
    {
        SceneManager.LoadScene(2);
    }
    public void loadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void resetScore()
    {
        PlayerPrefs.SetInt("score", 0);
    }
}
