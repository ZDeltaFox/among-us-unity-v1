using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class ActiveMission : MonoBehaviour
{
    #region GameObjects
    //Missions
    [HideInInspector]
    public GameObject ClearAsteroids;
    [HideInInspector]
    public GameObject Refuel1;
    [HideInInspector]
    public GameObject Refuel2;
    [HideInInspector]
    public GameObject UploadData1;
    [HideInInspector]
    public GameObject UploadData2;
    [HideInInspector]
    public GameObject UploadData3;
    [HideInInspector]
    public GameObject UploadData4;
    [HideInInspector]
    public GameObject UploadData5;
    [HideInInspector]
    public GameObject UploadData6;
    [HideInInspector]
    public GameObject DivertPower1;
    [HideInInspector]
    public GameObject DivertPower2;
    [HideInInspector]
    public GameObject DivertPower3;
    [HideInInspector]
    public GameObject DivertPower4;
    [HideInInspector]
    public GameObject DivertPower5;
    [HideInInspector]
    public GameObject DivertPower6;
    [HideInInspector]
    public GameObject DivertPower7;
    [HideInInspector]
    public GameObject DivertPower8;
    [HideInInspector]
    public GameObject CalibrateDistributor;
    [HideInInspector]
    public GameObject EmptyGarbage1;
    [HideInInspector]
    public GameObject EmptyGarbage2;
    [HideInInspector]
    public GameObject EmptyGarbage3;
    [HideInInspector]
    public GameObject PrimeShields;
    [HideInInspector]
    public GameObject RebootWifi1;
    [HideInInspector]
    public GameObject SwipeCard;
    [HideInInspector]
    public GameObject ChartCourse;
    [HideInInspector]
    public GameObject AlignEngineOutput1;
    [HideInInspector]
    public GameObject AlignEngineOutput2;
    [HideInInspector]
    public GameObject InspectSample;
    [HideInInspector]
    public GameObject UnlockManifolds;


    //Sabotage
    [HideInInspector]
    public GameObject Lights;
    [HideInInspector]
    public GameObject O2r1;
    [HideInInspector]
    public GameObject O2r2;


    //Report
    //[HideInInspector]
    public Button reportButton;
    bool canReport;

    [HideInInspector]
    public Camera camera;
    [HideInInspector]
    public Button useButton;
    public string ActualMission;
    bool isInteractable;

    private PhotonView pv;
    #endregion

    void Start()
    {
        pv = GetComponent<PhotonView>();
        ActualMission = "None";
        StartCoroutine(MissionSelector());
    }

    void Update()
    {
        reportButton.interactable = canReport;

        float distance = 2;
        int layerMask = 1 << 8;

        layerMask = ~layerMask;          

        RaycastHit hit;

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        useButton.interactable = isInteractable;

        if (Physics.Raycast(ray, out hit, distance)) 
        {          
            //Missions  
            #region Asteroids & Refuel
            if (hit.transform.CompareTag("Asteroids") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !SpawnAsteroids.Finished) 
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "Asteroids";
                isInteractable = true;
            }

            else if (hit.transform.CompareTag("Refuel1") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !Fuel.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "Refuel1";
                isInteractable = true;
            }

            else if (hit.transform.CompareTag("Refuel2") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !Fuel1.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "Refuel2";
                isInteractable = true;
            }
            #endregion
            #region Upload & Download Data
            else if (hit.transform.CompareTag("UploadData1") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !Download.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "UploadData1";
                isInteractable = true;
            }

            else if (hit.transform.CompareTag("UploadData2") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !Download1.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "UploadData2";
                isInteractable = true;
            }

            else if (hit.transform.CompareTag("UploadData3") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !Download2.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "UploadData3";
                isInteractable = true;
            }

            else if (hit.transform.CompareTag("UploadData4") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !Download3.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "UploadData4";
                isInteractable = true;
            }
        
            else if (hit.transform.CompareTag("UploadData5") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !Download4.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "UploadData5";
                isInteractable = true;
            }

            else if (hit.transform.CompareTag("UploadData6") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !Download5.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "UploadData6";
                isInteractable = true;
            }
            #endregion
            #region Divert Power
            else if (hit.transform.CompareTag("DivertPower1") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !Divert.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "DivertPower1";
                isInteractable = true;
            }

            else if (hit.transform.CompareTag("DivertPower2") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !Divert1.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "DivertPower2";
                isInteractable = true;
            }

            else if (hit.transform.CompareTag("DivertPower3") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !Divert2.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "DivertPower3";
                isInteractable = true;
            }

            else if (hit.transform.CompareTag("DivertPower4") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !Divert3.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "DivertPower4";
                isInteractable = true;
            }

            else if (hit.transform.CompareTag("DivertPower5") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !Divert4.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "DivertPower5";
                isInteractable = true;
            }

            else if (hit.transform.CompareTag("DivertPower6") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !Divert5.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "DivertPower6";
                isInteractable = true;
            }

            else if (hit.transform.CompareTag("DivertPower7") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !Divert6.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "DivertPower7";
                isInteractable = true;
            }

            else if (hit.transform.CompareTag("DivertPower8") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !Divert7.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "DivertPower8";
                isInteractable = true;
            }
            #endregion
            #region Calibrate Distribuitor & Empty Garbage
            else if (hit.transform.CompareTag("CalibrateDistributor") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !Calibrate.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "CalibrateDistributor";
                isInteractable = true;
            }

            else if (hit.transform.CompareTag("EmptyGarbage1") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !Garbage.EmptyGarbage.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "EmptyGarbage1";
                isInteractable = true;
            }

            else if (hit.transform.CompareTag("EmptyGarbage2") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !Garbage.EmptyGarbage1.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "EmptyGarbage2";
                isInteractable = true;
            }

            else if (hit.transform.CompareTag("EmptyGarbage3") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !Garbage.EmptyGarbage2.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "EmptyGarbage3";
                isInteractable = true;
            }
            #endregion
            #region Others
            else if (hit.transform.CompareTag("PrimeShields") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !ShieldButtons.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "PrimeShields";
                isInteractable = true;
            }

            else if (hit.transform.CompareTag("RebootWifi") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !RebootWifi.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "RebootWifi";
                isInteractable = true;
            }

            else if (hit.transform.CompareTag("SwipeCard") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !SwipeTask.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "SwipeCard";
                isInteractable = true;
            }

            else if (hit.transform.CompareTag("ChartCourse") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !Course.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "ChartCourse";
                isInteractable = true;
            }

            else if (hit.transform.CompareTag("AlignEngineOutput1") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !Align.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "AlignEngineOutput1";
                isInteractable = true;
            }
            
            else if (hit.transform.CompareTag("AlignEngineOutput2") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !Align1.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "AlignEngineOutput2";
                isInteractable = true;
            }

            else if (hit.transform.CompareTag("InspectSample") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !Inspect.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "InspectSample";
                isInteractable = true;
            }

            else if (hit.transform.CompareTag("UnlockManifolds") && !MultiplayerPlayerController.SusPlayerMovement.isInMission && !UnlockManifoldsTask.Finished)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "UnlockManifolds";
                isInteractable = true;
            }
            #endregion

            //Sabotage
            #region Sabotage
            else if (hit.transform.CompareTag("Lights") && !MultiplayerPlayerController.SusPlayerMovement.isInMission)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "Lights";
                isInteractable = true;
            }

            else if (hit.transform.CompareTag("O2r1") && !MultiplayerPlayerController.SusPlayerMovement.isInMission)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "O2r1";
                isInteractable = true;
            }

            else if (hit.transform.CompareTag("O2r2") && !MultiplayerPlayerController.SusPlayerMovement.isInMission)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                ActualMission = "O2r2";
                isInteractable = true;
            }
            #endregion
            else
            {
                ActualMission = "None";
                isInteractable = false;
            }

            //Report
            #region Report
            if (hit.transform.CompareTag("DeathBody") && !MultiplayerPlayerController.SusPlayerMovement.isInMission || hit.transform.CompareTag("ReportButton") && !MultiplayerPlayerController.SusPlayerMovement.isInMission)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.red);
                canReport = true;
            }

            else
            {
                canReport = false;
            }
            #endregion
        }

        #region Report
        if (Input.GetKey("r"))
        {
            if (Physics.Raycast(ray, out hit, distance)) 
            {  
                if (hit.transform.CompareTag("DeathBody") || hit.transform.CompareTag("ReportButton")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.blue);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        SetReporting.isReported = true;
                    }
                }
            }
        }
        #endregion

        if (Input.GetKey("e"))
        {
            if (Physics.Raycast(ray, out hit, distance)) 
            {         
                //Missions     
                #region Asteroids
                if (hit.transform.CompareTag("Asteroids")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!SpawnAsteroids.Finished)
                        {
                            Instantiate(ClearAsteroids);
                        }
                    }
                }
                #endregion
                #region Refuel1
                if (hit.transform.CompareTag("Refuel1")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!Fuel.Finished)
                        {
                            Instantiate(Refuel1);
                        }
                    }
                }
                #endregion
                #region Refuel2
                if (hit.transform.CompareTag("Refuel2")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!Fuel1.Finished)
                        {
                            Instantiate(Refuel2);
                        }
                    }
                }
                #endregion
                #region UploadData1
                if (hit.transform.CompareTag("UploadData1")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!Download.Finished)
                        {
                            Instantiate(UploadData1);
                        }
                    }
                }
                #endregion
                #region UploadData2
                if (hit.transform.CompareTag("UploadData2")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!Download1.Finished)
                        {
                            Instantiate(UploadData2);
                        }
                    }
                }
                #endregion
                #region UploadData3
                if (hit.transform.CompareTag("UploadData3")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!Download2.Finished)
                        {
                            Instantiate(UploadData3);
                        }
                    }
                }
                #endregion
                #region UploadData4
                if (hit.transform.CompareTag("UploadData4")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!Download3.Finished)
                        {
                            Instantiate(UploadData4);
                        }
                    }
                }
                #endregion
                #region UploadData5
                if (hit.transform.CompareTag("UploadData5")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!Download4.Finished)
                        {
                            Instantiate(UploadData5);
                        }
                    }
                }
                #endregion
                #region UploadData6
                if (hit.transform.CompareTag("UploadData6")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!Download5.Finished)
                        {
                            Instantiate(UploadData6);
                        }
                    }
                }
                #endregion
                #region DivertPower1
                if (hit.transform.CompareTag("DivertPower1")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!Divert.Finished)
                        {
                            Instantiate(DivertPower1);
                        }
                    }
                }
                #endregion
                #region DivertPower2
                if (hit.transform.CompareTag("DivertPower2")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!Divert1.Finished)
                        {
                            Instantiate(DivertPower2);
                        }
                    }
                }
                #endregion
                #region DivertPower3
                if (hit.transform.CompareTag("DivertPower3")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!Divert2.Finished)
                        {
                            Instantiate(DivertPower3);
                        }
                    }
                }
                #endregion
                #region DivertPower4
                if (hit.transform.CompareTag("DivertPower4")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!Divert3.Finished)
                        {
                            Instantiate(DivertPower4);
                        }
                    }
                }
                #endregion
                #region DivertPower5
                if (hit.transform.CompareTag("DivertPower5")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!Divert4.Finished)
                        {
                            Instantiate(DivertPower5);
                        }
                    }
                }
                #endregion
                #region DivertPower6
                if (hit.transform.CompareTag("DivertPower6")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!Divert5.Finished)
                        {
                            Instantiate(DivertPower6);
                        }
                    }
                }
                #endregion
                #region DivertPower7
                if (hit.transform.CompareTag("DivertPower7")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!Divert6.Finished)
                        {
                            Instantiate(DivertPower7);
                        }
                    }
                }
                #endregion
                #region DivertPower8
                if (hit.transform.CompareTag("DivertPower8")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!Divert7.Finished)
                        {
                            Instantiate(DivertPower8);
                        }
                    }
                }
                #endregion
                #region CalibrateDistributor
                if (hit.transform.CompareTag("CalibrateDistributor")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!Calibrate.Finished)
                        {
                            Instantiate(CalibrateDistributor);
                        }
                    }
                }
                #endregion
                #region EmptyGarbage1
                if (hit.transform.CompareTag("EmptyGarbage1")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!Garbage.EmptyGarbage.Finished)
                        {
                            Instantiate(EmptyGarbage1);
                        }
                    }
                }
                #endregion
                #region EmptyGarbage2
                if (hit.transform.CompareTag("EmptyGarbage2")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!Garbage.EmptyGarbage1.Finished)
                        {
                            Instantiate(EmptyGarbage2);
                        }
                    }
                }
                #endregion
                #region EmptyGarbage3
                if (hit.transform.CompareTag("EmptyGarbage3")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!Garbage.EmptyGarbage2.Finished)
                        {
                            Instantiate(EmptyGarbage3);
                        }
                    }
                }
                #endregion
                #region PrimeShields
                if (hit.transform.CompareTag("PrimeShields")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!ShieldButtons.Finished)
                        {
                            Instantiate(PrimeShields);
                        }
                    }
                }
                #endregion
                #region RebootWifi
                if (hit.transform.CompareTag("RebootWifi")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!RebootWifi.Finished)
                        {
                            Instantiate(RebootWifi1);
                        }
                    }
                }
                #endregion
                #region SwipeCard
                if (hit.transform.CompareTag("SwipeCard")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!SwipeTask.Finished)
                        {
                            Instantiate(SwipeCard);
                        }
                    }
                }
                #endregion
                #region ChartCourse
                if (hit.transform.CompareTag("ChartCourse")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!Course.Finished)
                        {
                            Instantiate(ChartCourse);
                        }
                    }
                }
                #endregion
                #region AlignEngineOutput1
                if (hit.transform.CompareTag("AlignEngineOutput1")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!Align.Finished)
                        {
                            Instantiate(AlignEngineOutput1);
                        }
                    }
                }
                #endregion
                #region AlignEngineOutput2
                if (hit.transform.CompareTag("AlignEngineOutput2")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!Align1.Finished)
                        {
                            Instantiate(AlignEngineOutput2);
                        }
                    }
                }
                #endregion
                #region InspectSample
                if (hit.transform.CompareTag("InspectSample")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!Inspect.Finished)
                        {
                            if (!Inspect.isOpen)
                            {
                                Instantiate(InspectSample);
                            }
                            
                            Inspect.isMenuActivedS = true;
                            MultiplayerPlayerController.SusPlayerMovement.isInMission = true;
                        }
                    }
                }
                #endregion
                #region UnlockManifolds
                if (hit.transform.CompareTag("UnlockManifolds")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        if (!UnlockManifoldsTask.Finished)
                        {
                            Instantiate(UnlockManifolds);
                        }
                    }
                }
                #endregion
                //Sabotage
                #region Lights
                if (hit.transform.CompareTag("Lights")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        Instantiate(Lights);
                    }
                }
                #endregion
                #region O2r1
                if (hit.transform.CompareTag("O2r1")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        Instantiate(O2r1);
                    }
                }
                #endregion
                #region O2r2
                if (hit.transform.CompareTag("O2r2")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                    if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
                    {
                        Instantiate(O2r2);
                    }
                }
                #endregion
            }
        }
    }

    #region Select
    public IEnumerator MissionSelector()
    {
        yield return new WaitForSeconds(1f);
        if (Random.Range(0, 2) == 1) {SpawnAsteroids.Finished = true;} else {SpawnAsteroids.Finished = false;}
        if (Random.Range(0, 2) == 1) {Fuel.Finished = true;} else {Fuel.Finished = false;}
        if (Random.Range(0, 2) == 1) {Fuel1.Finished = true;} else {Fuel1.Finished = false;}
        if (Random.Range(0, 2) == 1) {Download.Finished = true;} else {Download.Finished = false;}
        if (Random.Range(0, 2) == 1) {Download1.Finished = true;} else {Download1.Finished = false;}
        if (Random.Range(0, 2) == 1) {Download2.Finished = true;} else {Download2.Finished = false;}
        if (Random.Range(0, 2) == 1) {Download3.Finished = true;} else {Download3.Finished = false;}
        if (Random.Range(0, 2) == 1) {Download4.Finished = true;} else {Download4.Finished = false;}
        if (Random.Range(0, 2) == 1) {Download5.Finished = true;} else {Download5.Finished = false;}
        if (Random.Range(0, 2) == 1) {Divert.Finished = true;} else {Divert.Finished = false;}
        if (Random.Range(0, 2) == 1) {Divert1.Finished = true;} else {Divert1.Finished = false;}
        if (Random.Range(0, 2) == 1) {Divert2.Finished = true;} else {Divert2.Finished = false;}
        if (Random.Range(0, 2) == 1) {Divert3.Finished = true;} else {Divert3.Finished = false;}
        if (Random.Range(0, 2) == 1) {Divert4.Finished = true;} else {Divert4.Finished = false;}
        if (Random.Range(0, 2) == 1) {Divert5.Finished = true;} else {Divert5.Finished = false;}
        if (Random.Range(0, 2) == 1) {Divert6.Finished = true;} else {Divert6.Finished = false;}
        if (Random.Range(0, 2) == 1) {Divert7.Finished = true;} else {Divert7.Finished = false;}
        if (Random.Range(0, 2) == 1) {Calibrate.Finished = true;} else {Calibrate.Finished = false;}
        if (Random.Range(0, 2) == 1) {Garbage.EmptyGarbage.Finished = true;} else {Garbage.EmptyGarbage.Finished = false;}
        if (Random.Range(0, 2) == 1) {Garbage.EmptyGarbage1.Finished = true;} else {Garbage.EmptyGarbage1.Finished = false;}
        if (Random.Range(0, 2) == 1) {Garbage.EmptyGarbage2.Finished = true;} else {Garbage.EmptyGarbage2.Finished = false;}
        if (Random.Range(0, 2) == 1) {ShieldButtons.Finished = true;} else {ShieldButtons.Finished = false;}
        if (Random.Range(0, 2) == 1) {RebootWifi.Finished = true;} else {RebootWifi.Finished = false;}
        if (Random.Range(0, 2) == 1) {SwipeTask.Finished = true;} else {SwipeTask.Finished = false;}
        if (Random.Range(0, 2) == 1) {Course.Finished = true;} else {Course.Finished = false;}
        if (Random.Range(0, 2) == 1) {Align.Finished = true;} else {Align.Finished = false;}
        if (Random.Range(0, 2) == 1) {Align1.Finished = true;} else {Align1.Finished = false;}
        if (Random.Range(0, 2) == 1) {Inspect.Finished = true;} else {Inspect.Finished = false;}
        if (Random.Range(0, 2) == 1) {UnlockManifoldsTask.Finished = true;} else {UnlockManifoldsTask.Finished = false;}
    }
    #endregion
    public void ReportBody() {pv.RPC("ReportUsed", RpcTarget.All);}
    [PunRPC] void ReportUsed() {SetReporting.isReported = true;}
    #region Button
    public void ButtonMenuSelect()
    {
        //Missions
        if (ActualMission == "Asteroids") {Instantiate(ClearAsteroids);}
        if (ActualMission == "Refuel1") {Instantiate(Refuel1);}
        if (ActualMission == "Refuel2") {Instantiate(Refuel2);}
        if (ActualMission == "UploadData1") {Instantiate(UploadData1);}
        if (ActualMission == "UploadData2") {Instantiate(UploadData2);}
        if (ActualMission == "UploadData3") {Instantiate(UploadData3);}
        if (ActualMission == "UploadData4") {Instantiate(UploadData4);}
        if (ActualMission == "UploadData5") {Instantiate(UploadData5);}
        if (ActualMission == "UploadData6") {Instantiate(UploadData6);}
        if (ActualMission == "DivertPower1") {Instantiate(DivertPower1);}
        if (ActualMission == "DivertPower2") {Instantiate(DivertPower2);}
        if (ActualMission == "DivertPower3") {Instantiate(DivertPower3);}
        if (ActualMission == "DivertPower4") {Instantiate(DivertPower4);}
        if (ActualMission == "DivertPower5") {Instantiate(DivertPower5);}
        if (ActualMission == "DivertPower6") {Instantiate(DivertPower6);}
        if (ActualMission == "DivertPower7") {Instantiate(DivertPower7);}
        if (ActualMission == "DivertPower8") {Instantiate(DivertPower8);}
        if (ActualMission == "CalibrateDistributor") {Instantiate(CalibrateDistributor);}
        if (ActualMission == "EmptyGarbage1") {Instantiate(EmptyGarbage1);}
        if (ActualMission == "EmptyGarbage2") {Instantiate(EmptyGarbage2);}
        if (ActualMission == "EmptyGarbage3") {Instantiate(EmptyGarbage3);}
        if (ActualMission == "PrimeShields") {Instantiate(PrimeShields);}
        if (ActualMission == "RebootWifi") {Instantiate(RebootWifi1);}
        if (ActualMission == "SwipeCard") {Instantiate(SwipeCard);}
        if (ActualMission == "ChartCourse") {Instantiate(ChartCourse);}
        if (ActualMission == "AlignEngineOutput1") {Instantiate(AlignEngineOutput1);}
        if (ActualMission == "AlignEngineOutput2") {Instantiate(AlignEngineOutput2);}
        if (ActualMission == "InspectSample") 
        {if (!Inspect.isOpen) {Instantiate(InspectSample);}              
            Inspect.isMenuActivedS = true;
            MultiplayerPlayerController.SusPlayerMovement.isInMission = true;}
        if (ActualMission == "UnlockManifolds") {Instantiate(UnlockManifolds);}
        
        //Sabotage
        if (ActualMission == "Lights") {Instantiate(Lights);}
        if (ActualMission == "O2r1") {Instantiate(O2r1);}
        if (ActualMission == "O2r2") {Instantiate(O2r2);}
    }
    #endregion
}
