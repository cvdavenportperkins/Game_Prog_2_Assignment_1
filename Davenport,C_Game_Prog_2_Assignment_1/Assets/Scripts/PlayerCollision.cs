using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public GameManager gameManager;
    public List<GameObject> tailSegments = new List<GameObject>();
    public GameObject tailPrefab;
    public Transform tailParent;
    public float bounceBackDistance = 3f;
    public bool hasTail;

    private Rigidbody2D rb;
    private Vector2 lastMoveDirection;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))              //check for collision with food prefab
        {
            AddTailSegment();
            Destroy(collision.gameObject);                        //destroy food objects on collision 
                    
        }
        else if (collision.gameObject.CompareTag("Boundary"))
        {
            BounceOffBoundary();                                  //bounce back on boundary collision
        }
    }

    void AddTailSegment()                                          //add tail segments
    {
        Vector3 newPosition = tailSegments.Count == 0 ? transform.position :
        tailSegments[tailSegments.Count - 1].transform.position;
        
        GameObject newTailSegment = Instantiate(tailPrefab, newPosition, Quaternion.identity, tailParent);
        tailSegments.Add(newTailSegment);
        hasTail = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hasTail = false;
    }

    // Update is called once per frame
    void Update()
    {
        lastMoveDirection = rb.velocity.normalized;                //define last movement direction
        
    }

    void BounceOffBoundary()                                       //reverse last movement direction on collision with arena boundary 
    {
        rb.velocity = -lastMoveDirection * rb.velocity.magnitude;
        transform.position += (Vector3)(-lastMoveDirection * bounceBackDistance);
        
    }
}
