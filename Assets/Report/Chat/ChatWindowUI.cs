using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class ChatWindowUI : MonoBehaviourPun
{
    [SerializeField] private ChatItemUI _chatItemPrefab;
    [SerializeField] private Transform _context;

    [SerializeField] private TMP_InputField _inputText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            SendMessage();
        }

        sendF = LobbyNetworkManager.MyPlayerNumberCounter;
    }

    private void InstantiateChatItem(string text, float sendC) 
    {
        ChatItemUI newChatItem = Instantiate(_chatItemPrefab);

        newChatItem.transform.SetParent(_context);
        newChatItem.transform.position = Vector3.zero;
        newChatItem.transform.localScale = Vector3.one;

        newChatItem.Initialize(text, sendC);
    }

    private void SendMessage()
    {
        sendC = sendF;
        //Do not send empty messages
        if (string.IsNullOrEmpty(_inputText.text)) {return;}

        //InstantiateChatItem(_inputText.text);
        //StartCoroutine(ResetText());

        photonView.RPC("ReceiveMessageRPC", RpcTarget.All, _inputText.text, sendC);
        _inputText.ActivateInputField();
        _inputText.text = string.Empty;
    }

    //private IEnumerator ResetText() 
    //{
        //yield return new WaitForSeconds(0.1f);
        //_inputText.text = string.Empty;
    //}

    public void OnSendButtonPressed()
    {
        SendMessage();
    }

    [PunRPC]
    public void ReceiveMessageRPC(string text, float sendC)
    {
        InstantiateChatItem(text, sendC);
    }

    private void OnEnable() 
    {
        _inputText.text = string.Empty;
    }

    float sendF;
    float sendC;
}
