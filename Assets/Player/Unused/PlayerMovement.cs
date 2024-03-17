using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

namespace MultiplayerPlayerController
{
    public class PlayerMovement : MonoBehaviour
    {
        public float Number;
        public float PNumber;

        public GameObject Cam;
        public float PlayerCam;

        public float PlayerCounter;

        //public PhotonView PV;

        //Animaciones
        [SerializeField] private Animator animator;

        public bool isCrouching;
        public bool isWalking;
        public bool isCrawling;
        public bool idle;

        public bool isDeath;

        //Movimiento
        public CharacterController cc;
        public float Velocidad = 12;

        public float Gravedad = -9.81f;
        public Vector3 velocity;


        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public LayerMask floorMask;
        bool isGrounded;

        public float Timer = 1f;
        public float ChangeAnimation;

        public float ActualActionVel;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;

            //PV = GetComponent<PhotonView>();

            //transform.Rotate(new Vector3(-90, 0, 0));

            isCrawling = false;
            isWalking = false;
            isCrouching = false;
            idle = true;
        }

        void FixedUpdate()
        {
            PNumber = LobbyNetworkManager.MyPlayerNumberCounter;

            PlayerCounter = LobbyNetworkManager.SPlayerCounter;

            if (PlayerCounter <= Number - 1) {Destroy(gameObject);}
#region Movimiento
            //if (PV.IsMine)
            //{
                if (!isDeath)
                {
                    Cam.SetActive(true);
                    //Movimiento
                    isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, floorMask);

                    if (isGrounded && velocity.y < 0)
                    {
                        velocity.y = -2f;
                    }

                    if (Input.GetButtonDown("Jump") && isGrounded)
                    {
                        velocity.y = Mathf.Sqrt(3 * -2 * Gravedad);
                    }

                    float x = Input.GetAxis("Horizontal");
                    float z = Input.GetAxis("Vertical");

                    if (!isCrawling)
                    {
                        Vector3 move = transform.right * x + transform.forward * z;
                        cc.Move(move * Velocidad * ActualActionVel * Time.deltaTime);
                    }

                    else
                    {
                        Vector3 move = transform.forward * 1;
                        cc.Move(move * Velocidad * ActualActionVel * Time.deltaTime);
                    }


                    velocity.y += Gravedad * Time.deltaTime;
                    cc.Move(velocity * Time.deltaTime);

    #endregion
    #region Animaciones
                    //Animaciones
                    //Input
                    //Walking Input
                    if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")) {isWalking = true;}
                    else {isWalking = false;}

                    //Crouching Input;
                    if (Input.GetKeyDown("left shift") || Input.GetKeyDown("right shift"))
                    {
                        if (ChangeAnimation >= Timer)
                        {
                            if (isCrouching) {isCrouching = false;}
                            else {isCrouching = true; isCrawling = false;}
                            ChangeAnimation = 0f;
                        }
                    }
                    else 
                    {
                        ChangeAnimation += Time.deltaTime;
                    }

                    //Crawling Input
                    if (Input.GetKeyDown("left ctrl") || Input.GetKeyDown("right ctrl"))
                    {
                        if (ChangeAnimation >= Timer)
                        {
                            if (isCrawling) {isCrawling = false;}
                            else {isCrawling = true; isCrouching = false;}
                            ChangeAnimation = 0f;
                        }
                    }
                    else 
                    {
                        ChangeAnimation += Time.deltaTime;
                    }
                    
                    //Controlar Animaciones
                    //Walk Animator Controller
                    if (isWalking)
                    {
                        animator.SetBool("Idle", false);
                        animator.SetBool("Walk", true);
                    }

                    else
                    {
                        animator.SetBool("Walk", false);
                    }

                    //Crouch Animator Controller
                    if (isCrouching) 
                    {
                        animator.SetBool("Crouch", true);
                        ActualActionVel = 0.6f;
                    }

                    else
                    {
                        animator.SetBool("Crouch", false);

                        if (!isCrawling)
                        {
                            ActualActionVel = 1f;
                        }
                    }

                    //Crawl Animator Controller
                    if (isCrawling) 
                    {
                        animator.SetBool("Crawl", true);
                        animator.SetBool("Idle", false);
                        animator.SetBool("Crouch", false);
                        animator.SetBool("Walk", false);

                        ActualActionVel = 0.2f;
                    }

                    else 
                    {
                        animator.SetBool("Crawl", false);
                    }

                    if (!isWalking)
                    {
                        if (!isCrawling)
                        {
                            animator.SetBool("Idle", true);
#endregion
                        }
                    }
                }
            //}
        }
    }
}