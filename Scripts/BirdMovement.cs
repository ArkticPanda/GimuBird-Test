using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdMovement : MonoBehaviour
{
    private Rigidbody2D rb; 
    public float thrust ;
    private float rotateSpeed = 5.0f;

   private GameManager gameManager;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        gameManager = GameManager.instance;
    }

    
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began)
        {
            Fly();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Fly();
        }


    }

    public void Fly()
    {
        rb.velocity = Vector2.up * thrust;
        gameManager.PlayFlySound();
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    void Rotate()
    {
        transform.rotation = Quaternion.Euler(0,0, rb.velocity.y * rotateSpeed);
    }

   private void OnCollisionEnter2D(Collision2D other)
    {
     if (other.gameObject.CompareTag("Coin"))
        {
            FindObjectOfType<ScoreManager>().IncrementScore(1000);

            gameManager.PlayCoinSound();
        }
     else
        {
            GameManager.instance.GameOver();

        }
    }
}
