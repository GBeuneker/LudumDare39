using UnityEngine;
using System.Collections.Generic;

public class GameInformation : MonoBehaviour
{
    private static GameInformation gameInformation;

    public List<PlayerNumber> ActivePlayers = new List<PlayerNumber>();

    public static GameInformation Instance
    {
        get
        {
            if (gameInformation == null)
            {
                GameObject newObject = new GameObject();
                newObject.name = "GameInformation";
                newObject.AddComponent<GameInformation>();
                DontDestroyOnLoad(newObject);

                gameInformation = newObject.GetComponent<GameInformation>();
            }

            return gameInformation;
        }
    }
}
