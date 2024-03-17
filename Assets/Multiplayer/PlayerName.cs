using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

[RequireComponent (typeof (PhotonView))]

public class PlayerName : MonoBehaviour
{
    private PhotonView pv;
    public string name;
    [SerializeField] private TMP_Text player;
    void Start()
    {
        player = GetComponent<TMP_Text>();
        pv = GetComponent<PhotonView>();
        name = PlayerPrefs.GetString("Username");

        // Encuentra el objeto "_playerItemUIPrefab(Clone)" en la escena
        GameObject playerItemUI = GameObject.Find("_playerItemUIPrefab(Clone)");

        // Encuentra el objeto "Player" hijo del "_playerItemUIPrefab(Clone)"
        Transform playerTransform = playerItemUI.transform.Find("Player");

        // Encuentra el objeto "Text (TMP)" hijo del objeto "Player"
        player = playerTransform.GetComponentInChildren<TMP_Text>();
        if (pv.IsMine)
        {
            pv.RPC("SetName", RpcTarget.AllBuffered, name);
        }
    }

    void Update()
    {
        player.text = PlayerPrefs.GetString("Username");
    }

    [PunRPC]
    void SetName(string user)
    {
        GetName(user);
    }

    void GetName(string user)
    {
        player.text = user;
    }
}