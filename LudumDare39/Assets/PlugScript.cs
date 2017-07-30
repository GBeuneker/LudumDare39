using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugScript : MonoBehaviour
{
    private GameObject socket;
    private GameObject playerHoldingPlug;

    private void Start()
    {
    }

    /// <summary> Grab the plug and remember who grabbed it. </summary>
    public void Grab(GameObject player)
    {
        playerHoldingPlug = player;
        Debug.Log("GRAB!");
    }

    /// <summary> Plug the plug into a socket. </summary>
    public void PlugIn(GameObject socket)
    {
        PluggedIn = true;
        this.socket = socket;

        transform.position = socket.transform.position;
        transform.rotation = socket.transform.rotation;
        playerHoldingPlug = null;
    }

    /// <summary> Plug out the plug. </summary>
    public void PlugOut()
    {
        PluggedIn = false;
    }

    public bool PluggedIn
    {
        get; private set;
    }

    public GameObject PlayerHoldingPlug
    {
        get { return playerHoldingPlug; }
    }

}
