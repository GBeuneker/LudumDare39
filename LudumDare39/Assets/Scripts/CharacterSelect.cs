﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public bool IsReady;

    [SerializeField]
    private PlayerNumber playerNumber;
    [SerializeField]
    private Text playerText;
    [SerializeField]
    private Image playerImage;

    private string cachedText;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Grab_" + (int)playerNumber))
            ReadyPlayer();
        else if (Input.GetButton("Cancel_" + (int)playerNumber))
            UnReadyPlayer();
    }

    public void ReadyPlayer()
    {
        if (IsReady)
            return;

        cachedText = playerText.text;
        playerText.text = "Ready!";

        IsReady = true;
        playerImage.gameObject.SetActive(IsReady);
    }

    public void UnReadyPlayer()
    {
        if (!IsReady)
            return;

        IsReady = false;
        playerText.text = cachedText;
        playerImage.gameObject.SetActive(IsReady);
    }

    public PlayerNumber PlayerNumber
    {
        get { return playerNumber; }
    }
}