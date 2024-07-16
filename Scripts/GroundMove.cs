using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    private float moveSpeed = -1f;
    private float width = 8.4f;
    
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);

        if(Mathf.Abs(transform.position.x - originalPosition.x) > width)
        {
            transform.position = new Vector2(9.6f, transform.position.y);
        }
    }

   
}
