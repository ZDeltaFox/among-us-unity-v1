using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Fuel2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //      GraphicRaycaster m_Raycaster;
    //      PointerEventData m_PointerEventData;
    //      EventSystem m_EventSystem;

    public float refuel;
    public GameObject Root;
    public bool isEntered;

    public static bool Finished;

    void Start() 
    {
        MultiplayerPlayerController.SusPlayerMovement.isInMission = true;
        refuel = 0;
        MissionClear = GetComponent<AudioSource>();
        ////    Fetch the Raycaster from the GameObject (the Canvas)
        //      m_Raycaster = GetComponent<GraphicRaycaster>();
        ////    Fetch the Event System from the Scene
        //      m_EventSystem = GetComponent<EventSystem>();
        isEntered = false;
    }

    //public void Refuel()
    //{
        //refuel++;
    //}

    public Image refuelI;


    void Update()
    {     
        if (Finished) {Destroy(gameObject);}
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(Root);
        }          

        refuelI.fillAmount = refuel / 500;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject);
            MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
        }

        if (refuel >= 500)   
        {
            GameTasksSlider.Position += 7;
            StartCoroutine(DestroyGO());
        } 

        //      Check if the left Mouse button is clicked
        //      if (Input.GetKey(KeyCode.Mouse0))
        //      {
            ////    Set up the new Pointer Event
            //      m_PointerEventData = new PointerEventData(m_EventSystem);
            ////    Set the Pointer Event Position to that of the mouse position
            //      m_PointerEventData.position = this.transform.localPosition;

            ////    Create a list of Raycast Results
            //      List<RaycastResult> results = new List<RaycastResult>();

            ////    Raycast using the Graphics Raycaster and mouse click position
            //      m_Raycaster.Raycast(m_PointerEventData, results);

            ////    For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            //      foreach (RaycastResult result in results)
            //      {
                //      Debug.Log("Hit " + result.gameObject.name);
                ///     if (m_Raycaster.transform.CompareTag("Mission")) {refuel++;}
                ///     if (result.CompareTag("Mission")) {refuel++;}
                ///     if (result.gameObject.name == Button) {refuel++;}
                ///     if (results[0].gameObject.layer == LayerMask.NameToLayer("Mission"))
                ///     {
                    ///     refuel++;
                ///     }
            ///     }
        ///     }

        if (isEntered) {if (Input.GetKey("mouse 0")) {refuel++;}}
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isEntered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isEntered = false;
    }

    public AudioSource MissionClear;

    public IEnumerator DestroyGO()
    {
        MissionClear.Play();
        yield return new WaitForSeconds(1f);
        Destroy(Root);
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
        Finished = true;
    }

    public void Quit()
    {
        Destroy(Root);
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
    }
}
