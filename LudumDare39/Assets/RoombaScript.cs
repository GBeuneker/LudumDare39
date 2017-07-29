using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaScript : MonoBehaviour
{
    [SerializeField]
    private PlugScript plugScript;

    // Use this for initialization
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (plugScript.PluggedIn && other.gameObject.CompareTag("Dust"))
        {
            Destroy(other.gameObject);
            IncreaseScore();
        }
    }

    private void IncreaseScore()
    {
        Debug.Log("+10 points!");
    }

    public PlugScript PlugScript
    {
        get { return plugScript; }
    }
}
