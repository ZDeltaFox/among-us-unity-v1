using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace MultiplayerPlayerController
{
    public class SusPlayerMovement : MonoBehaviourPunCallbacks
    {
        [Header ("Audio")]
        public AudioSource KillAudio;
        public AudioSource WalkAudio;

        public float speed = 200;
        public Rigidbody rig;

        public Animator animator;

        //Actual

        public float Number;
        public float PNumber;

        public GameObject Cam;

        public GameObject Canvas;

        public GameObject ImpostorCanvas;

        public float PlayerCam;

        public float PlayerCounter;

        public PhotonView PV;

        public bool isWalking;

        public static bool isInMission;
        public static bool canMove;

        public bool isDeath = false;
        public static bool isSDeath;

        [Header ("Positions")]
        public float PosX;
        public float PosY;
        public float PosZ;
        public float DeathY = -101.7f;

        public static Vector3 Positions;

        public bool Impostor1 = false;
        public bool Impostor2 = false;

        public GameObject DeathScreen;

        //public GameObject DeathCam;

        void Start()
        {
            killTimer = 20;

            isInMission = false;
            PV = GetComponent<PhotonView>();

            transform.Rotate(new Vector3(-90, 0, 0));

            ImpostorCanvas.SetActive(false);

            lastKill = 0;

            isDeath = false;
            Impostor1 = false;
            Impostor2 = false;
        }
#region Movement
        void FixedUpdate()
        {           
            PNumber = LobbyNetworkManager.MyPlayerNumberCounter;

            PlayerCounter = LobbyNetworkManager.SPlayerCounter;

            if (PlayerCounter <= Number - 1) {Destroy(gameObject);}
            if (PV.IsMine)
            {
                isSDeath = isDeath;

                Positions = new Vector3(PosX, PosY, PosZ);
                if (!isInMission)
                {
                    if (canMove)
                    {
                        if (!isDeath)
                        {
                            PosX = transform.position.x;
                            PosY = transform.position.y;
                            PosZ = transform.position.z;

                            Canvas.SetActive(true);
                            if (!isDeath) {Cam.SetActive(true);}
                            //Movimiento
                            float t_hmove = Input.GetAxisRaw("Vertical");
                            float t_vmove = Input.GetAxisRaw("Horizontal");

                            Vector3 t_direction = new Vector3(t_hmove, t_vmove, 0);
                            t_direction.Normalize();

                            float t_adjustedSpeed = speed;

                            rig.velocity = transform.TransformDirection(t_direction) * speed * Time.deltaTime;

                            //Animaciones
                            //Input
                            if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")) {isWalking = true;}
                            else {isWalking = false;}
                            
                            if (Impostor1 || Impostor2) {ImpostorCanvas.SetActive(true);}
                            if (!Impostor1 && !Impostor2) {ImpostorCanvas.SetActive(false);}
                        }
                    }
                }

                else
                {
                    Canvas.SetActive(false);
                    ImpostorCanvas.SetActive(false);
                }

                if (isWalking)
                {
                    animator.SetBool("Walk", true);
                }

                else
                {
                    animator.SetBool("Walk", false);
                }

                if (ImpostorSelectorLobby.sNumber[0] == PNumber) {Impostor1 = true;}
                else {Impostor1 = false;}

                if (ImpostorSelectorLobby.sNumber[1] == PNumber) {Impostor2 = true;}
            }
//client impostor --> 
            if (PV.IsMine)
            {

                if (lastKill == PNumber) {Debug.Log("Player 1 is Death"); isDeath = true;}

                if (isDeath)
                {
                    transform.position = new Vector3(PosX, DeathY, PosZ);

                    DeathScreen.transform.localScale += new Vector3(25, 25, 0);
                    Cam.SetActive(false);
                    isSDeath = true;

                    //Instantiate(DeathCam);
                    StartCoroutine(ReturnLobby());
                }
            }

        
            isSDeath = isDeath;
        }
        #endregion
        #region Return To Lobby On Death
        public IEnumerator ReturnLobby()
        {
            yield return new WaitForSeconds(5f);
            PhotonNetwork.LeaveRoom();
            yield return new WaitForSeconds(0.25f);
            PhotonNetwork.Disconnect();
            yield return new WaitForSeconds(0.25f);
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.AutomaticallySyncScene = true;
            yield return new WaitForSeconds(0.25f);
            SceneManager.LoadScene("MainMenu");
        }
        #endregion
        #region SetPlayersKillable
        public static float lastKill;

        [Header ("Killed")]
        public float killable;
        float killTimer;
        float rKillTimer;
        public TMP_Text tKillTimer;
        float totalKilled;
        public static float sTotalKilled;


        [Header ("RayCasting")]
        public Camera camera;
        public Button killButton;
        public bool killAction = false;

        void Update()
        {
            sTotalKilled = totalKilled;

            rKillTimer = Mathf.Round(killTimer);
            killTimer -= Time.deltaTime;
            if (killTimer <= 0)
            {
                tKillTimer.text = "";

                if (Input.GetKeyDown("mouse 1"))
                {
                    if (killAction)
                    {
                        PV.RPC("KillPlayer", RpcTarget.All, killable);
                    }
                }

                float distance = 3;
                // Bit shift the index of the layer (8) to get a bit mask
                int layerMask = 1 << 8;

                // This would cast rays only against colliders in layer 8.
                // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
                layerMask = ~layerMask;

                    

                RaycastHit hit;
                // Does the ray intersect any objects excluding the player layer
                //derecha

                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            
                if (Physics.Raycast(ray, out hit, distance)) 
                {
                    #endregion                
                    #region When Player Is Killable
                    if (Impostor1 || Impostor2)
                    {
                        if (hit.transform.CompareTag("Player")) 
                        {
                            if (PNumber != 0)
                            {
                                killable = 0;
                                //Debug.Log("You can kill the player 0");
                                killButton.interactable = true;
                                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.blue);
                                killAction = true;
                            }
                        }

                        else if (hit.transform.CompareTag("Player1")) 
                        {
                            if (PNumber != 1)
                            {
                                killable = 1;
                                //Debug.Log("You can kill the player 1");
                                killButton.interactable = true;
                                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.red);
                                killAction = true;
                            }
                        }

                        else if (hit.transform.CompareTag("Player2")) 
                        {
                            if (PNumber != 2)
                            {
                                killable = 2;
                                //Debug.Log("You can kill the player 2");
                                killButton.interactable = true;
                                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.red);
                                killAction = true;
                            }
                        }

                        else if (hit.transform.CompareTag("Player3")) 
                        {
                            if (PNumber != 3)
                            {
                                killable = 3;
                                //Debug.Log("You can kill the player 3");
                                killButton.interactable = true;
                                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.red);
                                killAction = true;
                            }
                        }

                        else if (hit.transform.CompareTag("Player4")) 
                        {
                            if (PNumber != 4)
                            {
                                killable = 4;
                                //Debug.Log("You can kill the player 4");
                                killButton.interactable = true;
                                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.red);
                                killAction = true;
                            }
                        }

                        else if (hit.transform.CompareTag("Player5")) 
                        {
                            if (PNumber != 5)
                            {
                                killable = 5;
                                //Debug.Log("You can kill the player 5");
                                killButton.interactable = true;
                                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.red);
                                killAction = true;
                            }
                        }

                        else if (hit.transform.CompareTag("Player6")) 
                        {
                            if (PNumber != 6)
                            {
                                killable = 6;
                                //Debug.Log("You can kill the player 6");
                                killButton.interactable = true;
                                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.red);
                                killAction = true;
                            }
                        }

                        else if (hit.transform.CompareTag("Player7")) 
                        {
                            if (PNumber != 7)
                            {
                                killable = 7;
                                //Debug.Log("You can kill the player 7");
                                killButton.interactable = true;
                                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.red);
                                killAction = true;
                            }
                        }

                        else if (hit.transform.CompareTag("Player8")) 
                        {
                            if (PNumber != 8)
                            {
                                killable = 8;
                                //Debug.Log("You can kill the player 8");
                                killButton.interactable = true;
                                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.red);
                                killAction = true;
                            }
                        }
                        
                        else if (hit.transform.CompareTag("Player9")) 
                        {
                            if (PNumber != 9)
                            {
                                killable = 9;
                                //Debug.Log("You can kill the player 9");
                                killButton.interactable = true;
                                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.red);
                                killAction = true;
                            }
                        }

                        else if (hit.transform.CompareTag("Player10")) 
                        {
                            if (PNumber != 10)
                            {
                                killable = 10;
                                //Debug.Log("You can kill the player 10");
                                killButton.interactable = true;
                                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.red);
                                killAction = true;
                            }
                        }

                        else
                        {
                            killAction = false;
                            killButton.interactable = false;
                            //Debug.Log("You can't kill players");
                            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
                        }
                    }
                    #endregion
                    #region If the player isn't the impostor
                    else
                    {
                        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
                    }
                }
                #endregion

                else
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1, Color.white);
                }
            }

            else
            {
                killButton.interactable = false;
                tKillTimer.text = rKillTimer.ToString("0");
            }
        }
      
        public void KillBtn()
        {
            PV.RPC("KillPlayer", RpcTarget.All, killable);
        }

        [PunRPC]
        void KillPlayer(int playerKilled)
        {
            lastKill = playerKilled;
            if (playerKilled != 0) {killTimer = 30; totalKilled++;}
        }
    }
}