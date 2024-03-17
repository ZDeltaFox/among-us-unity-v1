using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ImpostorSelectorLobby : MonoBehaviourPunCallbacks
{
    [Header ("Number")]
    public int[] Number = new int[2];
    public static int[] sNumber;

    [Header ("Time")]
    public float timer;
    public float Players;

    void Awake()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (PlayerCounter.SPlayerCounter == 10)
            {
                Number = new int[1];
                Number[0] = Random.Range(1, 10);
                Number[1] = Random.Range(1, 10);

                if (Number[0] == Number[1])
                {
                    if (Number[0] == 10)
                    {
                        Number[1]--;
                    }

                    else
                    {
                        Number[1]++;
                    }
                }
            }

            else
            {
                Number = new int[0];
                Number[0] = Random.Range(1, (int)Mathf.Round(PlayerCounter.SPlayerCounter));
            }

            GetComponent<PhotonView>().RPC("SetImpostor", RpcTarget.AllBuffered, Number);
        }
    }

    [PunRPC]
    void SetImpostor(int[] impostor)
    {
        Number = impostor;
        sNumber = Number;
    }
}

