using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Geo_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    private string Var2 = "Hello ";
    Rigidbody2D rb;
    int Var3 = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(Var2 + "World");
        Var2 = "Goodbye";
        Debug.Log(Var2 + "TEXT");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-1, rb.velocity.y);
        Debug.Log(Var3);
        Var3++;

        // Continuous movement along the X axis
        transform.position += new Vector3(0.005f, 0, 0);

        // WASD Movement Controls
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
    }
}