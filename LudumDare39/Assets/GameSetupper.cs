using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetupper : MonoBehaviour
{

    void Start()
    {
        foreach (PlayerNumber playerNumber in GameInformation.Instance.ActivePlayers)
        {
            CreatePlayer(playerNumber);
        }
    }

    void Update()
    {

    }

    void CreatePlayer(PlayerNumber number)
    {
        GameObject player = Instantiate(Resources.Load("Prefabs/Player")) as GameObject;
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.playerNumber = number;
        Transform playerTransform = player.GetComponent<Transform>();
        playerTransform.position = new Vector2((int)number, -2 * (int)number);

        GameObject roomba = Instantiate(Resources.Load("Prefabs/_Roomba")) as GameObject;
        RoombaScript roombaScript = roomba.GetComponentInChildren<RoombaScript>();
        roombaScript.PlayerNumber = number;

        Transform roombaTransform = roomba.GetComponentInChildren<Transform>();
        roombaTransform.position = new Vector2((int)number, -2 * (int)number);


    }
}
