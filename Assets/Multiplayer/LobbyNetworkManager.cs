using UnityEngine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine.UI;
#if TMPro
using TMPro;
#endif
using UnityEngine.SceneManagement;

public class LobbyNetworkManager : MonoBehaviourPunCallbacks
{
    #region Room
    [Header ("Room")]
    [SerializeField] private InputField _roomInput;
    [SerializeField] private RoomItemUI _roomItemUIPrefab;
    [SerializeField] private Transform _roomListParent; 
    #endregion

    #region RoomSettings
    [Header ("Room Settings")]
    public bool isVisible = true;
    #if TMPro
    [SerializeField] private TMP_Text _isVisible;
    [SerializeField] private TMP_Text _minPlayers;
    [SerializeField] private TMP_Text _maxPlayers;
    #else
    [SerializeField] private Text _isVisible;
    [SerializeField] private Text _minPlayers;
    [SerializeField] private Text _maxPlayers;
    #endif
    public Button privateRoom;
    public Button addMaxPlayers;
    public Button substractMaxPlayers;
    public Button addMinPlayers;
    public Button substractMinPlayers;
    [Range(5, 10)] public byte MaxPlayers;
    public byte MinPlayers;

    #endregion

    #region Players
    [Header ("Players & Others")]
    public Text PlayerNumber;
    public Text PlayerCount;

    public static float MyPlayerNumberCounter;
    public static float PNC;

    public byte ActualNumberCounter;
    
    public byte PlayerCounter;
    public static float SPlayerCounter;
    public static float PlayerNumberCounter;

    float timer;
    float timerq;
    public float maxTime;
    
    public GameObject ErrorPrefab;
    #endregion

    #region PlayerList
    [Header("Player List")]
    [SerializeField] private GameObject _playerItemUIPrefab;
    [SerializeField] private Transform _playerListParent;
    #endregion

    #region ObjSettings
    [Header("ObjSettings")]
    [SerializeField] private Text _statusField;
    [SerializeField] private Text _currentLocationText;
    [SerializeField] private Button _leaveRoomButton;
    [SerializeField] private Button _createGameButton;
    [SerializeField] private Button _joinGameButton;
    [SerializeField] private Button _startGameButton;
    #endregion

    #region Windows
    [Header("Windows")]
    [SerializeField] private GameObject _roomListWindow;
    [SerializeField] private GameObject _playerListWindow;
    [SerializeField] private GameObject _createRoomWindow;
    
    private List<RoomItemUI> _roomList = new List<RoomItemUI>();
    private List<RoomItemUI> _playerList = new List<RoomItemUI>();
    #endregion

    void Start()
    {
        Connect();
        Initialize();
    }

    #region PhotonCallbacks

    private void Initialize()
    {
        _leaveRoomButton.interactable = false;
        _startGameButton.interactable = false;
        _createGameButton.interactable = true;
    }

    public override void OnConnectedToMaster() 
    {
        Debug.Log("Conectado al Servidor Master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomList(roomList);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        if (_statusField == null) {return;}
        _statusField.text = "Disconnected";
    }

    public override void OnJoinedLobby()
    {
        _currentLocationText.text = "Rooms";
    }

    public override void OnJoinedRoom()
    {
        _statusField.text = "Joined " + PhotonNetwork.CurrentRoom.Name;
        _currentLocationText.text = PhotonNetwork.CurrentRoom.Name;
        _leaveRoomButton.interactable = true;

        if (PhotonNetwork.IsMasterClient)
        {
            _createGameButton.interactable = false;
        }
        //UpdatePlayerList();
        ShowWindow(false);

        _startGameButton.interactable = false;
        _createGameButton.interactable = false;

        GameObject gameObj = PhotonNetwork.Instantiate(_playerItemUIPrefab.name, new Vector3(0, 0, 0), Quaternion.identity, 0, null);
        gameObj.transform.SetParent(_playerListParent);
    }

    public override void OnLeftRoom()
    {
        if (_statusField != null) 
        {
            _statusField.text = "Lobby";
        }

        if (_currentLocationText != null)
        {
            _currentLocationText.text = "Rooms";
        }

        _leaveRoomButton.interactable = false;
        _startGameButton.interactable = false;
        _createGameButton.interactable = true;
        //UpdatePlayerList();

        ShowWindow(true);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        //UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        //UpdatePlayerList();
        timerq = -1f;
        timer = -1f;

        if (PlayerNumberCounter >= PlayerCounter + 1)
        {
            PlayerNumberCounter--;
        }
    }
    #endregion

    private void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void UpdateRoomList(List<RoomInfo> roomList)
    {
        //Limpiar la lista de salas actual
        for (int i = 0; i < _roomList.Count; i++)
        {
            Destroy(_roomList[i].gameObject);
        }

        _roomList.Clear();
        //Generar una nueva lista con informacion actualizada
        for (int i = 0; i < roomList.Count; i++)
        {
            //Saltar salas vacias
            if (roomList[i].PlayerCount == 0) {continue;}

            RoomItemUI newRoomItem = Instantiate(_roomItemUIPrefab);
            newRoomItem.LobbyNetworkParent = this;
            newRoomItem.SetName(roomList[i].Name);
            newRoomItem.transform.SetParent(_roomListParent);

            _roomList.Add(newRoomItem);
        }
    }

    /*private void UpdatePlayerList()
    {
        //Limpiar la lista de jugadores actual
        for (int i = 0; i < _playerList.Count; i++)
        {
            Destroy(_playerList[i].gameObject);
        }

        _playerList.Clear();

        if (PhotonNetwork.CurrentRoom == null) {return;}
        //Generar una nueva lista de jugadores
        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            GameObject gameObj = PhotonNetwork.Instantiate(_playerItemUIPrefab.name, new Vector3(0, 0, 0), Quaternion.identity, 0, null);

            gameObj.transform.SetParent(_playerListParent);

            //_playerList.Add(gameObj);
        }
    }*/

    private void ShowWindow (bool isRoomList)
    {
        _roomListWindow.SetActive(isRoomList);
        _playerListWindow.SetActive(!isRoomList);
        _createRoomWindow.SetActive(isRoomList);
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(_roomInput.text) == false)
        {
            PhotonNetwork.CreateRoom(_roomInput.text, new RoomOptions() {MaxPlayers = MaxPlayers, IsVisible = isVisible}, null);
        }

        timer = -1f;
    }

    public void JoinPrivateRoom()
    {
        if (string.IsNullOrEmpty(_roomInput.text) == false)
        {
            PhotonNetwork.JoinRoom(_roomInput.text);
        }
        timer = -1f;
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
        timer = -1f;
        timerq = -1f;
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        _startGameButton.interactable = false;
    }

    public void OnBackToMainMenuPressed()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("MainMenu");
    }

    public void OnReloadPressed()
    {
        StartCoroutine(ReloadRooms());
    }

    public IEnumerator ReloadRooms()
    {
        Buttons.chatActived = false;
        PhotonNetwork.LeaveRoom();
        yield return new WaitForSeconds(0.25f);
        PhotonNetwork.Disconnect();
        yield return new WaitForSeconds(0.25f);
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void OnStartGamePressed()
    {
        if (PlayerCounter >= MinPlayers)
        {
            PhotonNetwork.LoadLevel("Game");

            Buttons.isInLoad = true;
        }

        else
        {
            Instantiate(ErrorPrefab);
            Error.stError = "Faltan  <size=96><b>" + (MinPlayers - PlayerCounter) + "<size=72><b> jugadores";
        }
    }

    private void FixedUpdate() 
    {
        PlayerNumberCounter = PhotonNetwork.LocalPlayer.ActorNumber;
        if (PhotonNetwork.CurrentRoom != null)
        {
            PlayerCounter = PhotonNetwork.CurrentRoom.PlayerCount;
            SPlayerCounter = PlayerCounter;
        }

        if (timer <= maxTime) 
        {
            PlayerNumber.text = "Player: " + PlayerNumberCounter;
            MyPlayerNumberCounter = PlayerNumberCounter;
        }        
        
        if (timerq <= maxTime) {PlayerNumberCounter = PlayerCounter;}

        if (PlayerNumberCounter == 1 && PhotonNetwork.InRoom) {_startGameButton.interactable = true;}

        timer += Time.deltaTime;

        PlayerCount.text = "Players: " + PlayerCounter + " / " + MaxPlayers;
        
        ActualNumberCounter = PlayerCounter;

        if (Buttons.stimer >= Buttons.smaxTime)
        {
            PhotonNetwork.Disconnect();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        _minPlayers.text = "Min Players: " + MinPlayers + "/2";
        _maxPlayers.text = "Max Players: " + MaxPlayers + "/10";

        if (PhotonNetwork.InRoom)
        {
            addMaxPlayers.interactable = false;
            addMinPlayers.interactable = false;
            substractMaxPlayers.interactable = false;
            substractMinPlayers.interactable = false;
            privateRoom.interactable = false;
            _createGameButton.interactable = false;
            _joinGameButton.interactable = false;
        }

        else
        {
            addMaxPlayers.interactable = true;
            addMinPlayers.interactable = true;
            substractMaxPlayers.interactable = true;
            substractMinPlayers.interactable = true;
            privateRoom.interactable = true;
            _createGameButton.interactable = true;
            _joinGameButton.interactable = true;
            _startGameButton.interactable = false;
        }

        if (!isVisible) {_isVisible.text = "Private";}
        else {_isVisible.text = "Public";}
    }

    public void MPButtons(int ID) 
    {
        if (ID == 0) {if (MinPlayers > 1) {MinPlayers--;}}
        if (ID == 1) {if (MinPlayers < 10) {MinPlayers++;}}
        if (ID == 2) {if (MaxPlayers > 5) {MaxPlayers--;}}
        if (ID == 3) {if (MaxPlayers < 10) {MaxPlayers++;}}
    }

    public void PrivateRoom()
    {
        isVisible = !isVisible;
    }
}