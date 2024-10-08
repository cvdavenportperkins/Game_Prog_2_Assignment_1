using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCollision : MonoBehaviour
{

    public PlayerCollision playerCollision;
    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D collision)                //trigger goal collision behavior
    {
        if (collision.gameObject.CompareTag("Player"))        //check if the player collision condition exists
        {
            int segmentsDeposited = playerCollision.tailSegments.Count;         
            int points = 0;

            for (int i = 0; i < segmentsDeposited; i++)
            {
                points += 100;
                if (i % 2 == 1)
                {
                    points *= 2;
                }
            }

            gameManager.AddScore(points);                                   //game amanger add point to total
            foreach (GameObject segment in playerCollision.tailSegments)    //player goal collosion remove tail segments
            {
                Destroy(segment);
            }

            playerCollision.tailSegments.Clear();
            playerCollision.hasTail = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
