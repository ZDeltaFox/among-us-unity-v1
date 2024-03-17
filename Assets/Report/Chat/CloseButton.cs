using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public GameObject chatWindow;
    
    public void CloseButtonPress()
    {
        Buttons.chatActived = false;
    }

    void Update()
    {
        if (Buttons.chatActived) {chatWindow.transform.localScale = new Vector3(1, 1, 1);}
        else {chatWindow.transform.localScale = new Vector3(1, 0, 1);}
    }
}
