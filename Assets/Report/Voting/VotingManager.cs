using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class VotingManager : MonoBehaviour
{
    [Header ("Time")]
    public float timer;

    [Header ("Most voted player")]
    public string mostVoted;

    [Header ("Total votes")]
    public string Votes;
    public static string sVotes;
    float votes;

    [Header ("Number of player votes")]
    public float Skiped;
    public int[] Player;

    public static bool voted;

    public static float sTimer;

    private PhotonView pv;

    void Update()
    {
        sVotes = Votes;
        Votes = votes + "/" + LobbyNetworkManager.SPlayerCounter;
        timer = Mathf.Round(sTimer);

        if (SetReporting.sIsVoting != 0) {sTimer -= Time.deltaTime;}
        else {sTimer = 90;}

        if (sTimer <= 0)
        {
            if (VotePlayerItem.yourVote == 0)
            {
                VotePlayerItem.yourVote = 11;
            }
        }

        if (votes >= PlayerCounter.SPlayerCounter)
        {
            sTimer = 0;
        }

        if (!voted)
        {
            if (VotePlayerItem.yourVote != 0)
            {
                voted = true;
                CheckVote();
            }
        }

        if (SetReporting.isReported)
        {
            
        }
    }

    void CheckVote()
    {
        if (VotePlayerItem.yourVote != 11)
        {
            pv.RPC("SendVote", RpcTarget.All, VotePlayerItem.yourVote);
        }
    }

    [PunRPC]
    void SendVote(int vote) 
    {
        Player[vote - 1]++;
    }

    void Start()
    {
        StartCoroutine(Loops());
        sTimer = 90;
        pv = GetComponent<PhotonView>();
    }

    public IEnumerator Loops()
    {
        #region Skiped
        if (Skiped >= Player[0])
        {
            if (Skiped >= Player[1])
            {
                if (Skiped >= Player[2])
                {
                    if (Skiped >= Player[3])
                    {
                        if (Skiped >= Player[4])
                        {
                            if (Skiped >= Player[5])
                            {
                                if (Skiped >= Player[6])
                                {
                                    if (Skiped >= Player[7])
                                    {
                                        if (Skiped >= Player[8])
                                        {
                                            if (Skiped >= Player[9])
                                            {
                                                mostVoted = "Skiped";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region Player[0]
        if (Player[0] >= Skiped)
        {
            if (Player[0] >= Player[1])
            {
                if (Player[0] >= Player[2])
                {
                    if (Player[0] >= Player[3])
                    {
                        if (Player[0] >= Player[4])
                        {
                            if (Player[0] >= Player[5])
                            {
                                if (Player[0] >= Player[6])
                                {
                                    if (Player[0] >= Player[7])
                                    {
                                        if (Player[0] >= Player[8])
                                        {
                                            if (Player[0] >= Player[9])
                                            {
                                                mostVoted = "Player[0]";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region Player[1]
        if (Player[1] >= Skiped)
        {
            if (Player[1] >= Player[0])
            {
                if (Player[1] >= Player[2])
                {
                    if (Player[1] >= Player[3])
                    {
                        if (Player[1] >= Player[4])
                        {
                            if (Player[1] >= Player[5])
                            {
                                if (Player[1] >= Player[6])
                                {
                                    if (Player[1] >= Player[7])
                                    {
                                        if (Player[1] >= Player[8])
                                        {
                                            if (Player[1] >= Player[9])
                                            {
                                                mostVoted = "Player[1]";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region Player[2]
        if (Player[2] >= Skiped)
        {
            if (Player[2] >= Player[0])
            {
                if (Player[2] >= Player[1])
                {
                    if (Player[2] >= Player[3])
                    {
                        if (Player[2] >= Player[4])
                        {
                            if (Player[2] >= Player[5])
                            {
                                if (Player[2] >= Player[6])
                                {
                                    if (Player[2] >= Player[7])
                                    {
                                        if (Player[2] >= Player[8])
                                        {
                                            if (Player[2] >= Player[9])
                                            {
                                                mostVoted = "Player[2]";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region Player[3]
        if (Player[3] >= Skiped)
        {
            if (Player[3] >= Player[0])
            {
                if (Player[3] >= Player[1])
                {
                    if (Player[3] >= Player[2])
                    {
                        if (Player[3] >= Player[4])
                        {
                            if (Player[3] >= Player[5])
                            {
                                if (Player[3] >= Player[6])
                                {
                                    if (Player[3] >= Player[7])
                                    {
                                        if (Player[3] >= Player[8])
                                        {
                                            if (Player[3] >= Player[9])
                                            {
                                                mostVoted = "Player[3]";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region Player[4]
        if (Player[4] >= Skiped)
        {
            if (Player[4] >= Player[0])
            {
                if (Player[4] >= Player[1])
                {
                    if (Player[4] >= Player[2])
                    {
                        if (Player[4] >= Player[3])
                        {
                            if (Player[4] >= Player[5])
                            {
                                if (Player[4] >= Player[6])
                                {
                                    if (Player[4] >= Player[7])
                                    {
                                        if (Player[4] >= Player[8])
                                        {
                                            if (Player[4] >= Player[9])
                                            {
                                                mostVoted = "Player[4]";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region Player[5]
        if (Player[5] >= Skiped)
        {
            if (Player[5] >= Player[0])
            {
                if (Player[5] >= Player[1])
                {
                    if (Player[5] >= Player[2])
                    {
                        if (Player[5] >= Player[3])
                        {
                            if (Player[5] >= Player[4])
                            {
                                if (Player[5] >= Player[6])
                                {
                                    if (Player[5] >= Player[7])
                                    {
                                        if (Player[5] >= Player[8])
                                        {
                                            if (Player[5] >= Player[9])
                                            {
                                                mostVoted = "Player[5]";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region Player[6]
        if (Player[6] >= Skiped)
        {
            if (Player[6] >= Player[0])
            {
                if (Player[6] >= Player[1])
                {
                    if (Player[6] >= Player[2])
                    {
                        if (Player[6] >= Player[3])
                        {
                            if (Player[6] >= Player[4])
                            {
                                if (Player[6] >= Player[5])
                                {
                                    if (Player[6] >= Player[7])
                                    {
                                        if (Player[6] >= Player[8])
                                        {
                                            if (Player[6] >= Player[9])
                                            {
                                                mostVoted = "Player[6]";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region Player[7]
        if (Player[7] >= Skiped)
        {
            if (Player[7] >= Player[0])
            {
                if (Player[7] >= Player[1])
                {
                    if (Player[7] >= Player[2])
                    {
                        if (Player[7] >= Player[3])
                        {
                            if (Player[7] >= Player[4])
                            {
                                if (Player[7] >= Player[5])
                                {
                                    if (Player[7] >= Player[6])
                                    {
                                        if (Player[7] >= Player[8])
                                        {
                                            if (Player[7] >= Player[9])
                                            {
                                                mostVoted = "Player[7]";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region Player[8]
        if (Player[8] >= Skiped)
        {
            if (Player[8] >= Player[0])
            {
                if (Player[8] >= Player[1])
                {
                    if (Player[8] >= Player[2])
                    {
                        if (Player[8] >= Player[3])
                        {
                            if (Player[8] >= Player[4])
                            {
                                if (Player[8] >= Player[5])
                                {
                                    if (Player[8] >= Player[6])
                                    {
                                        if (Player[8] >= Player[7])
                                        {
                                            if (Player[8] >= Player[9])
                                            {
                                                mostVoted = "Player[8]";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region Player[9]
        if (Player[9] >= Skiped)
        {
            if (Player[9] >= Player[0])
            {
                if (Player[9] >= Player[1])
                {
                    if (Player[9] >= Player[2])
                    {
                        if (Player[9] >= Player[3])
                        {
                            if (Player[9] >= Player[4])
                            {
                                if (Player[9] >= Player[5])
                                {
                                    if (Player[9] >= Player[6])
                                    {
                                        if (Player[9] >= Player[7])
                                        {
                                            if (Player[9] >= Player[8])
                                            {
                                                mostVoted = "Player[9]";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Loops());
    }
}
