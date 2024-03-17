using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SetReporting : MonoBehaviour
{
    public static bool isReported;

    public bool isVoting;
    public static float sIsVoting;

    public GameObject Report;

    public GameObject[] Report1;

    int rVote;

    void Start()
    {
        isReported = false;
        ResetPos();
        sIsVoting = 0;
    }

    void Update()
    {
        if (isReported)
        {
            Report.transform.position = new Vector3(1, 1000, 0);
        }

        sIsVoting = Report.transform.position.x;
        if (sIsVoting == 1) {isVoting = true;}
        else {isVoting = false;}
        if (isVoting && PhotonNetwork.IsMasterClient) {GetComponent<PhotonView>().RPC("OpenReportScreen", RpcTarget.All, Random.Range(1, 10));}
    }

    void ResetPos()
    {
        Report.transform.position = new Vector3(0, 1000, 0);
        sIsVoting = 0;
    }

    [PunRPC]
    public void OpenReportScreen(int Vote)
    {
        rVote = Vote;
        ResetPos();
        isVoting = false;
        Instantiate(Report1[rVote - 1]);

    }
}
