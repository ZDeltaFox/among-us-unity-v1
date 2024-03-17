using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActivation : MonoBehaviour
{
    [Header ("Crewmate")]
    [SerializeField] private Button _useButton;
    [SerializeField] private Button _reportButton;

    [Header ("Impostor")]
    [SerializeField] private Button _sabotageButton;
    [SerializeField] private Button _killButton;
    [SerializeField] private Button _ventButton;



    void Start()
    {
        _useButton.interactable = false;
        _reportButton.interactable = false;
    }

    private void OnTriggerEnter(Collider collision)
    {   
        if (collision.gameObject.CompareTag("DeathBody"))
        {
            _reportButton.interactable = true;
        }

        else 
        {
            _reportButton.interactable = false;
        }


    }
}
