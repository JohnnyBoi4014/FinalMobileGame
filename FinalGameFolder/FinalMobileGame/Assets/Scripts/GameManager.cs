using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public int score = 0;

    public CameraTargetScript cts;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;

        if (cts.currentHealth <= 0)
        {
            ResetGame();
        }
    }

    public void IncreaseScore()
    {
        score += 100;
    }
    public void DecreaseScore()
    {
        score -= 10;
    }

    private void ResetGame()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(sceneName);
    }
}
