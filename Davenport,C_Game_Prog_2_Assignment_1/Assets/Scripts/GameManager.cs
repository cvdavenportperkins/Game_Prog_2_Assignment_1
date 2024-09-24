using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI youWinText;
    public int score = 0;
    public int health = 3;
    public float gameTime = 45f;
    public int points;
    
    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
        if (score >= 3000)
        {

            YouWin();

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        youWinText.gameObject.SetActive(false);
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        gameTime -= Time.deltaTime;

        if (gameTime <= 0)
        {
            GameOver();
        }

    }

     

     void TakeDamage()
        {
            health--;
            if (health <= 0)
            {
                GameOver();
            }
        }

    void GameOver()
        {
            gameOverText.gameObject.SetActive(true);
            Time.timeScale = 0f;

        }

    void YouWin()
        {
            youWinText.gameObject.SetActive(true);
            
        }

    void UpdateScoreText()
        {
            scoreText.text = "Score: " + score;
        }





    
}
