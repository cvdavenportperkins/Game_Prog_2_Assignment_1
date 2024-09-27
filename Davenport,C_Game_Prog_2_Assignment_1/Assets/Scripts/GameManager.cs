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
    public GameObject foodPrefab;                        //set food prefab variable
    public float spawnInterval = 2f;                     //set spawn interval variable
    public float timer;                                  //set time variable
    private List<GameObject> foodInstances = new List<GameObject>();  //set List object to count food instances
    public GameObject arena;
    private CircleCollider2D arenaCollider;
    public int maxFoodInstances = 3;
    


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
        arenaCollider = arena.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        gameTime -= Time.deltaTime;

        if (gameTime <= 0)
        {
            GameOver();
        }


        timer += Time.deltaTime;                   //set timer update interval

        if (timer >= spawnInterval)                //if timer exceeded spawnInterval
        {
            if (foodInstances.Count < maxFoodInstances)           //check food instances
            {
                SpawnFood();                       //Spawn food
            }

            timer = 0;                             //Reset timer
        }

        if (foodInstances.Count >= 4)              //If food instances reach 10, game over
        {
            gameOverText.text = "Game Over";
            gameOverText.gameObject.SetActive(true);
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
    void SpawnFood()
    {
        Vector2 foodPosition = new Vector2(Random.Range(-8f, 8f), Random.Range(-8f, 8f)); // Set random food spawn position

        GameObject newFood = Instantiate(foodPrefab, foodPosition, Quaternion.identity);    //instantiate food prefab 
        
        Bounds bounds = arenaCollider.bounds;           //declare spawn bounds within arena collider boundary
                
        newFood.transform.SetParent(arena.transform, false); // Set the parent after instantiation

        foodInstances.Add(newFood);                                                         //add new food instance to list object

        StartCoroutine(DestroyFoodAfterTime(newFood, 5f));                //attempt to make food profabs expire after set interval (does not work)
    }

    IEnumerator DestroyFoodAfterTime(GameObject food, float delay)        //set timer to despawn food Prefabs
    {
        yield return new WaitForSeconds(delay);
        if (foodInstances.Contains(food))
        {
            foodInstances.Remove(food);

            Destroy(food);
        }
    }

   




}
