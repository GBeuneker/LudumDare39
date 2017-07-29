using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb2d;
    public float speed;
    float plugcount;


    // Use this for initialization
    void Start()
    {
        BoxCollider2D[] boxes = GetComponents<BoxCollider2D>();
        BoxCollider2D plugtrigger = boxes[0];
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    /// <summary> Handles input and controls the player. </summary>
    private void HandleInput()
    {
        Moving();
        PlugHandler();



    }

    private void Moving()
    {
        float x, y;
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        rb2d.AddForce(new Vector2(x * speed, y * speed));

        //Drag
        rb2d.velocity = new Vector2((rb2d.velocity.x * 0.3f),(rb2d.velocity.y * 0.3f));
    }

    private void PlugHandler()
    {
        if (plugcount >= 1 || Input.GetButtonDown("Jump"))
        {
            //pick up plugs
        }
    
    }

    private void OnTriggerEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Plug"))
            plugcount++;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Plug"))
            plugcount--;
    }
}
