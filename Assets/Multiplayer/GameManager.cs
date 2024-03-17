using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    [Header ("Players")]
    public GameObject Player;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;
    public GameObject Player5;
    public GameObject Player6;
    public GameObject Player7;
    public GameObject Player8;
    public GameObject Player9;

    [Header ("Pos X")]
    public float MinX;
    public float MaxX;
    [Header ("Pos Y")]
    public float PosY = 0.35f;
    [Header ("Pos Z")]
    public float MinZ;
    public float MaxZ;
    [Header ("Spawn Pos")]
    public Vector3 SpawnPos;

    public float PNumber;

    void Start()
    {
        SpawnPos = new Vector3(Random.Range(MinX, MaxX), PosY, Random.Range(MinZ, MaxZ));

        PNumber = LobbyNetworkManager.MyPlayerNumberCounter;

        StartCoroutine(OnInitialized());
    }

    private IEnumerator OnInitialized()
    {
        yield return new WaitForSeconds(0.2f);
        if (CloseRoom.sTimeToClose <= CloseRoom.sMaxTime)
        {
            if (PNumber == 1) {GameObject gameObject = PhotonNetwork.Instantiate(Player.name, SpawnPos, Quaternion.identity, 0, null);}
            if (PNumber == 2) {GameObject gameObject1 = PhotonNetwork.Instantiate(Player1.name, SpawnPos, Quaternion.identity, 0, null);}
            if (PNumber == 3) {GameObject gameObject2 = PhotonNetwork.Instantiate(Player2.name, SpawnPos, Quaternion.identity, 0, null);}
            if (PNumber == 4) {GameObject gameObject3 = PhotonNetwork.Instantiate(Player3.name, SpawnPos, Quaternion.identity, 0, null);}
            if (PNumber == 5) {GameObject gameObject4 = PhotonNetwork.Instantiate(Player4.name, SpawnPos, Quaternion.identity, 0, null);}
            if (PNumber == 6) {GameObject gameObject5 = PhotonNetwork.Instantiate(Player5.name, SpawnPos, Quaternion.identity, 0, null);}
            if (PNumber == 7) {GameObject gameObject6 = PhotonNetwork.Instantiate(Player6.name, SpawnPos, Quaternion.identity, 0, null);}
            if (PNumber == 8) {GameObject gameObject7 = PhotonNetwork.Instantiate(Player7.name, SpawnPos, Quaternion.identity, 0, null);}
            if (PNumber == 9) {GameObject gameObject8 = PhotonNetwork.Instantiate(Player8.name, SpawnPos, Quaternion.identity, 0, null);}
            if (PNumber == 10) {GameObject gameObject9 = PhotonNetwork.Instantiate(Player9.name, SpawnPos, Quaternion.identity, 0, null);}
        }

        else
        {
            PhotonNetwork.LeaveRoom();
            yield return new WaitForSeconds(0.1f);
            PhotonNetwork.Disconnect();
            yield return new WaitForSeconds(0.1f);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
