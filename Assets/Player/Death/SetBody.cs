using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBody : MonoBehaviour
{
    public GameObject Body1;
    public GameObject Body2;
    public GameObject Body3;
    public GameObject Body4;
    public GameObject Body5;
    public GameObject Body6;
    public GameObject Body7;
    public GameObject Body8;
    public GameObject Body9;
    public GameObject Body10;
    float PosY = -101.67f;

    float tries;

    void Update()
    {
        if (PlayerPos1.PosY <= -50) {Body1.transform.position = new Vector3(PlayerPos1.PosX, PosY, PlayerPos1.PosZ);}
        if (PlayerPos2.PosY <= -50) {Body2.transform.position = new Vector3(PlayerPos2.PosX, PosY, PlayerPos2.PosZ);}
        if (PlayerPos3.PosY <= -50) {Body3.transform.position = new Vector3(PlayerPos3.PosX, PosY, PlayerPos3.PosZ);}
        if (PlayerPos4.PosY <= -50) {Body4.transform.position = new Vector3(PlayerPos4.PosX, PosY, PlayerPos4.PosZ);}
        if (PlayerPos5.PosY <= -50) {Body5.transform.position = new Vector3(PlayerPos5.PosX, PosY, PlayerPos5.PosZ);}
        if (PlayerPos6.PosY <= -50) {Body6.transform.position = new Vector3(PlayerPos6.PosX, PosY, PlayerPos6.PosZ);}
        if (PlayerPos7.PosY <= -50) {Body7.transform.position = new Vector3(PlayerPos7.PosX, PosY, PlayerPos7.PosZ);}
        if (PlayerPos8.PosY <= -50) {Body8.transform.position = new Vector3(PlayerPos8.PosX, PosY, PlayerPos8.PosZ);}
        if (PlayerPos9.PosY <= -50) {Body9.transform.position = new Vector3(PlayerPos9.PosX, PosY, PlayerPos9.PosZ);}
        if (PlayerPos10.PosY <= -50) {Body10.transform.position = new Vector3(PlayerPos10.PosX, PosY, PlayerPos10.PosZ);}

        if (CloseRoom.sTimeToClose >= CloseRoom.sMaxTime)
        {
            StartCoroutine(addTries());
        }

        if (CloseRoom.sTimeToClose >= CloseRoom.sMaxTime && tries >= 10)
        {
            if (PlayersAlive.sTotalPlayers <= 9.2) {Destroy(Body10);}
            if (PlayersAlive.sTotalPlayers <= 8.2) {Destroy(Body9);}
            if (PlayersAlive.sTotalPlayers <= 7.2) {Destroy(Body8);}
            if (PlayersAlive.sTotalPlayers <= 6.2) {Destroy(Body7);}
            if (PlayersAlive.sTotalPlayers <= 5.2) {Destroy(Body6);}
            if (PlayersAlive.sTotalPlayers <= 4.2) {Destroy(Body5);}
            if (PlayersAlive.sTotalPlayers <= 3.2) {Destroy(Body4);}
            if (PlayersAlive.sTotalPlayers <= 2.2) {Destroy(Body3);}
            if (PlayersAlive.sTotalPlayers <= 1.2) {Destroy(Body2);}
        }
    }

    public IEnumerator addTries()
    {
        yield return new WaitForSeconds(0.1f);
        while (tries <= 12)
        {
            tries++;
        }
    }
}
