using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerNumber
{
    Player_1 = 1,
    Player_2,
    Player_3,
    Player_4
}

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float speed = 200.0f;
    public PlayerNumber playerNumber;
    private GameObject targetPlug, targetSocket;

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

    private void FixedUpdate()
    {
        Moving();
    }

    /// <summary> Handles input and controls the player. </summary>
    private void HandleInput()
    {
        if (Input.GetButtonDown("Grab" + PlayerSuffix))
            GrabPlug();
        if (Input.GetButton("Grab" + PlayerSuffix))
            MovePlug();
        if (Input.GetButtonUp("Grab" + PlayerSuffix))
            ReleasePlug();
    }

    private void Moving()
    {
        float x, y;
        x = Input.GetAxis("Horizontal" + PlayerSuffix);
        y = Input.GetAxis("Vertical" + PlayerSuffix);
        rb2d.AddForce(new Vector2(x * speed, y * speed));

        //Drag
        rb2d.velocity = new Vector2((rb2d.velocity.x * 0.3f), (rb2d.velocity.y * 0.3f));
    }

    /// <summary> Grab the plug. <summary>
    private void GrabPlug()
    {
        if (!targetPlug)
            return;

        // Tell the plug that we're holding it
        targetPlug.GetComponent<PlugScript>().Grab(gameObject);
        targetPlug.GetComponent<PlugScript>().PlugOut();
    }

    /// <summary> Move the plug around. <summary>
    private void MovePlug()
    {
        if (!targetPlug)
            return;

        if (targetPlug.GetComponent<PlugScript>().PlayerHoldingPlug == gameObject)
            targetPlug.transform.position = transform.position;
    }

    /// <summary> Release the plug we're holding. </summary>
    private void ReleasePlug()
    {
        if (!targetPlug)
            return;

        if (targetSocket != null)
        {
            // Double check if the plug is indeed still held by us
            if (targetPlug.GetComponent<PlugScript>().PlayerHoldingPlug == gameObject)
                targetPlug.GetComponent<PlugScript>().PlugIn(targetSocket);

            targetPlug = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If we encounter a plug
        if (other.gameObject.CompareTag("Plug"))
        {
            // Save it as the target plug
            if (targetPlug == null)
                targetPlug = other.gameObject;
        }

        // If we encounter a socket
        if (other.gameObject.CompareTag("Socket"))
        {
            // Save it as the target socket
            if (targetSocket == null)
                targetSocket = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // If a plug is out of range
        if (other.gameObject.CompareTag("Plug"))
        {
            // Remove the plug if it was our target plug
            if (targetPlug == other.gameObject)
                targetPlug = null;
        }

        // If a socket is out of range
        if (other.gameObject.CompareTag("Socket"))
        {
            // Remove the socket if it was our target socket
            if (targetSocket == other.gameObject)
                targetSocket = null;
        }
    }

    public string PlayerSuffix
    {
        get
        {
            return "_" + (int)playerNumber;
        }
    }
}
