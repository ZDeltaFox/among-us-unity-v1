using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersAlive : MonoBehaviour
{
    public float totalPlayers;
    public static float sTotalPlayers;
    public float actualPlayers;
    public static float sActualPlayers;
    public float playersAlive;
    public float deathPlayers;
    float posX;
    public static float sPosX;
    float posZ;
    public static float sPosZ;
    public string finalText;
    public static string sFinalText;

    void Update()
    {
        if (LobbyNetworkManager.MyPlayerNumberCounter == 1)
        {
            deathPlayers = MultiplayerPlayerController.SusPlayerMovement.sTotalKilled;

            if (CloseRoom.sTimeToClose <= CloseRoom.sMaxTime)
            {
                totalPlayers = LobbyNetworkManager.SPlayerCounter;
            }

            playersAlive = PlayerCounter.SPlayerCounter;

            gameObject.transform.position = new Vector3(playersAlive, 1000, deathPlayers);

            if (playersAlive <= 2.2)
            {
                finalText = "Victoria";
            }
        }

        else
        {
            if (playersAlive <= 2.2)
            {
                finalText = "Derrota";
            }
        }

        actualPlayers = LobbyNetworkManager.SPlayerCounter;

        sFinalText = finalText;

        posX = gameObject.transform.position.x;
        sPosX = posX;

        posZ = gameObject.transform.position.z;
        sPosZ = posZ;

        sTotalPlayers = totalPlayers;
        sActualPlayers = actualPlayers;
    }
}
