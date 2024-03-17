using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetKilled : MonoBehaviour
{
    public int[] kills;
    public static int[] kill = new int[11];
    void Update()
    {
        kills = kill;
        kill[(int)MultiplayerPlayerController.SusPlayerMovement.lastKill] = 1;
    }
}