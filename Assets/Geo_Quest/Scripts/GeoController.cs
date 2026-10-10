using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Geo_Controller : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed = 5;

    //start
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    { switch (collision.tag) { 
            case "Death":
            {
                    string thisLevel = SceneManager.GetActiveScene().name;
                    Debug.Log("Player Has Died");
                break;
            }
        }
    }









/*
        // Example: If you want continuous velocity to the left, keep this. 
        // Note: If you want full WASD control, you might want to remove or adjust this line.
        rb.velocity = new Vector2(-1, rb.velocity.y);

        // Continuous movement along the X axis
        transform.position += new Vector3(0.005f, 0, 0);

        // WASD Movement Controls (Using GetKeyDown for single-step movement)
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += new Vector3(0, 1, 0);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += new Vector3(0, -1, 0);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0);
        }
    }*/
}