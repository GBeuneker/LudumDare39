using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text textTimer;
    float timer;

    // Use this for initialization
    void Start()
    {
        timer = 120; //playtime
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        textTimer.text = string.Format("{0}:{1}", (int)(timer / 60), ((int)timer % 60).ToString("00"));
        if (timer <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        
    }
}
