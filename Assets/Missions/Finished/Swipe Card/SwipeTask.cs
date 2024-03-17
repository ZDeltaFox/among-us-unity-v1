using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SwipeTask : MonoBehaviour
{
    [Header ("Audio")]
    public AudioSource MissionClear;

    [Header ("Mission")]
    public List<SwipePoint> _swipePoints = new List<SwipePoint>();
    public float _countdownMax = 1f;
    public float _countdownMin = 0.1f;
    private int _currentSwipePointIndex = 0;
    public float _countdown = 0;
    public TMP_Text Text;

    public static bool Finished;

    void Start()
    {
        MissionClear = GetComponent<AudioSource>();
        MultiplayerPlayerController.SusPlayerMovement.isInMission = true;
    }

    private void Update()
    {
        _countdown += Time.deltaTime;

        //if (_currentSwipePointIndex != 0 && _countdown >= _countdownMax)
        //{
            //if (_currentSwipePointIndex <= _swipePoints.Count)
            //{
                //_currentSwipePointIndex = 0;
                //Text.text = "Demasiado lento. Reintentar";
                //StartCoroutine(FinishTask(false));
            //}
        //}

        //if (_currentSwipePointIndex == 8 && _countdown >= _countdownMin)
        //{
            //if (_currentSwipePointIndex <= _swipePoints.Count)
            //{
                //_currentSwipePointIndex = 0;
                //Text.text = "Demasiado deprisa. Reintentar";
                //StartCoroutine(FinishTask(false));
            //}
        //}

        //if (_currentSwipePointIndex == 1)
        //{
            //_countdown = 0;
        //}

        if (SwipeCard.xMS <= 5 && SwipeCard.xMS >= 1)
        {
            _currentSwipePointIndex = 0;
            Text.text = "Demasiado lento. Reintentar";
            StartCoroutine(FinishTask(false));
        }


        if (SwipeCard.xMS >= 400)
        {
            _currentSwipePointIndex = 0;
            Text.text = "Demasiado deprisa. Reintentar";
            StartCoroutine(FinishTask(false));
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject);
            MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
        }

        if (Finished) {Destroy(gameObject);}
    }

    public void SwipePointTrigger(SwipePoint swipePoint)
    {
        if (swipePoint == _swipePoints[_currentSwipePointIndex])
        {
            _currentSwipePointIndex++;
            _countdown = 0;
            SwipeCard.timer = 0;
        }

        if (_currentSwipePointIndex >= _swipePoints.Count)
        {
            _currentSwipePointIndex = 0;
            
            Debug.Log ("Finished");
            StartCoroutine(FinishTask(true));
        }
    }

    private IEnumerator FinishTask(bool wasSuccessful)
    {
        if (wasSuccessful)
        {
            Text.text = "Tarjeta aceptada.";
            MissionClear.Play();
            yield return new WaitForSeconds(1f);
            GameTasksSlider.Position += 7;
            MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
            Finished = true;
            Destroy(gameObject);
        }

        yield return new WaitForSeconds(1.5f);
        Text.text = "Pasa la tarjeta.";
    }

    public void Esc()
    {
        Destroy(gameObject);
        MultiplayerPlayerController.SusPlayerMovement.isInMission = false;
    }
}
