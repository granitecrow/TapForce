using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {

    float highScore;
    float playerScore;
    public Text scoreText;
    public Text highScoreText;

    public Canvas gameOverScreen;
    public Canvas highScoreScreen;

	// Use this for initialization
	void Start () {
        gameOverScreen.enabled = false;
        highScoreScreen.enabled = false;

        highScore = PlayerPrefs.GetFloat("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;
        playerScore = 0;
        UpdateScore();
    }

    // Update is called once per frame
    void Update () {
        if (playerScore > highScore)
        {
            highScoreText.text = "High Score: " + playerScore;
        }
    }

    public void IncreaseScore(int amount)
    {
        playerScore += amount;
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = playerScore.ToString();
    }

    public void HighScore()
    {
        if(playerScore > highScore)
        {
            PlayerPrefs.SetFloat("HighScore", playerScore);
            // show high score screen
            highScoreScreen.enabled = true;
            gameOverScreen.enabled = false;
        }
        else
        {
            // show game over screen
            highScoreScreen.enabled = false;
            gameOverScreen.enabled = true;
        }
    }

    public void EnableGameOverScreen()
    {
        // show game over screen
        highScoreScreen.enabled = false;
        gameOverScreen.enabled = true;
    }
}
