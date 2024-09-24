using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public GameManager gameManager;
    public List<GameObject> tailSegments = new List<GameObject>();
    public GameObject tailPrefab;
    public Transform tailParent;
    public float bounceBackDistance = 0.5f;

    private Rigidbody2D rb;
    private Vector2 lastMoveDirection;

    void OnTrigger2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))              //check for collision with food prefab
        {
            AddTailSegment();
            Destroy(collision.gameObject);                        //destroy food objects on collision 

        }
    }

    void AddTailSegment()                                          //add tail segments
    {
        Vector3 newPosition = tailSegments.Count == 0 ? transform.position :
        tailSegments[tailSegments.Count - 1].transform.position;
        
        GameObject newTailSegment = Instantiate(tailPrefab, newPosition, Quaternion.identity, tailParent);
        tailSegments.Add(newTailSegment);   
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lastMoveDirection = rb.velocity.normalized;
    }

    void BounceOffBoundary()
    {
        rb.velocity = -lastMoveDirection * rb.velocity.magnitude;
        transform.position += (Vector3)(-lastMoveDirection * bounceBackDistance);
    }
}
