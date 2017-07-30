using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public Text[] texts = new Text[4];
    private float[] points = new float[4];

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void UpdateScore(int playerNumber)
    {
        points[playerNumber - 1] += 10;
        texts[playerNumber - 1].text = "P" + playerNumber.ToString() + ": " + points[playerNumber - 1].ToString();
    }

}
