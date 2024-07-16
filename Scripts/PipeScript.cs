using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    private float movespeed = 3.0f;

    // Update is called once per frame
    void Update()
    {

        transform.position += Vector3.left * movespeed * Time.deltaTime;

    }

   void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("End"))
    {
        Destroy(collision.gameObject);
    }
}

}
