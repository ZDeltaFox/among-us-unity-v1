using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteObj : MonoBehaviour
{
    public int playerNumber;
    public CanvasRenderer playerImage;
    public Material[] m;

    void Update()
    {
        if (SetKilled.kill[playerNumber] == 1) {Destroy(gameObject);}
        playerImage.SetColor(m[playerNumber].color);
    }
}
