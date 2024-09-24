using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 7f;
    public Vector2 vel = new Vector2(0,0);

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        vel = Vector2.zero;                                  //velocity is 0 without input

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -moveSpeed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = moveSpeed;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            vel.y = moveSpeed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            vel.y = -moveSpeed;
        }
    
        {
            transform.Translate(vel * Time.deltaTime);       
        }

        
    
    }
}
