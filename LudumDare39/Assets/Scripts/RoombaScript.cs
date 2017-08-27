using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaScript : MonoBehaviour
{
    [SerializeField]
    private PlugScript plugScript;
    [SerializeField]
    private PlayerNumber playerNumber;
    [SerializeField]
    private ScoreScript scoreScript;

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
        Debug.Log(playerNumber + " +10 points!");
        scoreScript.UpdateScore((int)playerNumber);
    }

    public PlugScript PlugScript
    {
        get { return plugScript; }
    }

    public PlayerNumber PlayerNumber
    {
        get { return playerNumber; }
        set { playerNumber = value; }
    }

    public ScoreScript ScoreScript
    {
        get { return scoreScript; }
    }
}
