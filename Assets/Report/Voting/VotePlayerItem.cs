using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Realtime;

public class VotePlayerItem : MonoBehaviour
{
    public Button voteButton;

    public static float yourVote;

    public static bool setInteractable;

    public void VoteButton(float Number)
    {
        MultiplayerPlayerController.SusPlayerMovement.isInMission = true;
        yourVote = Number;

        StartCoroutine(CheckVote());
    }

    IEnumerator CheckVote()
    {
        setInteractable = true;
        yield return new WaitForSeconds(0.1f);
    }

    void Update() 
    {
        voteButton.interactable = !setInteractable;
    }

    void Start()
    {
        setInteractable = false;
    }
}
