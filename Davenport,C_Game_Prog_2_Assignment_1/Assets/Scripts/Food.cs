using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Food : MonoBehaviour
{
    public GameObject foodPrefab;                        //set food prefab variable
    public float spawnInterval = 3f;                     //set spawn interval variable
    public float timer;                                  //set time variable
    private List<GameObject> foodInstances = new List<GameObject>();  //set List object to count food instances
    public GameObject arena;
    private CircleCollider2D arenaCollider;
    public int maxFoodInstances = 4;
    public TextMeshPro gameOverText;



    // Start is called before the first frame update
    void Start()
    {
        arenaCollider = arena.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;                   //set timer update interval

        if (timer >= spawnInterval)                //if timer exceeded spawnInterval
        {
            if (foodInstances.Count < maxFoodInstances)           //check food instances
            {
                SpawnFood();                       //Spawn food
            }

            timer = 0;                             //Reset timer
        }

        if (foodInstances.Count >= 10)              //If food instances reach 10, game over
        {
            gameOverText.text = "Game Over";
            gameOverText.gameObject.SetActive(true);
        }
    }

       void SpawnFood()
    {

        Bounds bounds = arenaCollider.bounds;           //declare spawn bounds within arena collider boundary
        Vector2 foodPosition;


        do
        {

            foodPosition = new Vector2(Random.Range(bounds.min.x + 1, bounds.max.x - 1), Random.Range(bounds.min.y + 1, bounds.max.y - 1));   //set random food spawn position within boundary
        } while (!arenaCollider.OverlapPoint(foodPosition));


        GameObject newFood = Instantiate(foodPrefab, foodPosition, Quaternion.identity);    //instantiate food prefab  

        foodInstances.Add(newFood);                                                         //add new food instance to list object

        StartCoroutine(DestroyFoodAfterTime(newFood, 7f));                //attempt to make food profabs expire after set interval (does not work)
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