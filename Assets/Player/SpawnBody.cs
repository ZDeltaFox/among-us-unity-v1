using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnBody : MonoBehaviourPunCallbacks
{
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

    public Vector3 SpawnVector;

    public float PNumber;

    void Start() 
    {
        PNumber = LobbyNetworkManager.MyPlayerNumberCounter;
    }

    void Update()
    {
        SpawnVector = MultiplayerPlayerController.SusPlayerMovement.Positions;

        if (MultiplayerPlayerController.SusPlayerMovement.isSDeath)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        if (PNumber == 1) {GameObject gameObject = PhotonNetwork.Instantiate(Player.name, SpawnVector, Quaternion.identity, 0, null);}
        if (PNumber == 2) {GameObject gameObject1 = PhotonNetwork.Instantiate(Player1.name, SpawnVector, Quaternion.identity, 0, null);}
        if (PNumber == 3) {GameObject gameObject2 = PhotonNetwork.Instantiate(Player2.name, SpawnVector, Quaternion.identity, 0, null);}
        if (PNumber == 4) {GameObject gameObject3 = PhotonNetwork.Instantiate(Player3.name, SpawnVector, Quaternion.identity, 0, null);}
        if (PNumber == 5) {GameObject gameObject4 = PhotonNetwork.Instantiate(Player4.name, SpawnVector, Quaternion.identity, 0, null);}
        if (PNumber == 6) {GameObject gameObject5 = PhotonNetwork.Instantiate(Player5.name, SpawnVector, Quaternion.identity, 0, null);}
        if (PNumber == 7) {GameObject gameObject6 = PhotonNetwork.Instantiate(Player6.name, SpawnVector, Quaternion.identity, 0, null);}
        if (PNumber == 8) {GameObject gameObject7 = PhotonNetwork.Instantiate(Player7.name, SpawnVector, Quaternion.identity, 0, null);}
        if (PNumber == 9) {GameObject gameObject8 = PhotonNetwork.Instantiate(Player8.name, SpawnVector, Quaternion.identity, 0, null);}
        if (PNumber == 10) {GameObject gameObject9 = PhotonNetwork.Instantiate(Player9.name, SpawnVector, Quaternion.identity, 0, null);}
    }
}
