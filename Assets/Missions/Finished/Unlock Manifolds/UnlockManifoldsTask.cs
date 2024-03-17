using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockManifoldsTask : MonoBehaviour
{
    [SerializeField] private List<UnlockManifoldsButton> _buttonList = new List<UnlockManifoldsButton>();

    private int currentValue;

    private void OnEnable() 
    {
        List<int> numbers = new List<int>();

        for (int i = 0; i < _buttonList.Count; i++) 
        { 
            numbers.Add(i + 1);
        }

        for (int i = 0; i < _buttonList.Count; i++)
        {
            int pickedNumber = numbers[Random.Range(0, numbers.Count)];
            _buttonList[i].Initialize(pickedNumber, this);
            numbers.Remove(pickedNumber);
        }

        currentValue = 1;
    }

    private void ResetButtons()
    {
        foreach (UnlockManifoldsButton button in _buttonList)
        {
            button.ToggleButton(true);
        }
    }

    public void OnButtonPressed(int buttonID, UnlockManifoldsButton currentButton)
    {
        if (currentValue >= _buttonList.Count)
        {
            StartCoroutine(DestroyGO());
        }
        //Check if the correct button
        if (currentValue == buttonID)
        {
            currentValue++;
            currentButton.ToggleButton(false);
        }

        else
        {
            //Wrong Button
            currentValue = 1;
            ResetButtons();
        }
    }

    public void Esc()
    {
        currentValue = 1;
        ResetButtons();

        Destroy(gameObject);
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
    }

    private IEnumerator DestroyGO()
    {
        MissionClear.Play();
        yield return new WaitForSeconds(1f);
        Finished = true;
        Destroy(gameObject);
        GameTasksSlider.Position += 7;
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            currentValue = 1;
            ResetButtons();
            Destroy(gameObject);
            MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
        }
    }

    [HideInInspector]
    public AudioSource MissionClear;
    public static bool Finished;

    void Start()
    {
        MultiplayerPlayerController.SusPlayerMovement.isInMission = true;
        MissionClear.GetComponent<AudioSource>();
    }
}
