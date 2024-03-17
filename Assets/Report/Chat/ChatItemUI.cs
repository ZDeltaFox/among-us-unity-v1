using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChatItemUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    public CanvasRenderer color;
    public Material m1;
    public Material m2;
    public Material m3;
    public Material m4;
    public Material m5;
    public Material m6;
    public Material m7;
    public Material m8;
    public Material m9;
    public Material m10;

    public void Initialize(string text, float sendC)
    {
        _text.text = text;
        if (sendC == 1) {color.SetColor(m1.color);} 
        if (sendC == 2) {color.SetColor(m2.color);} 
        if (sendC == 3) {color.SetColor(m3.color);} 
        if (sendC == 4) {color.SetColor(m4.color);} 
        if (sendC == 5) {color.SetColor(m5.color);} 
        if (sendC == 6) {color.SetColor(m6.color);} 
        if (sendC == 7) {color.SetColor(m7.color);} 
        if (sendC == 8) {color.SetColor(m8.color);} 
        if (sendC == 9) {color.SetColor(m9.color);} 
        if (sendC == 10) {color.SetColor(m10.color);} 
    }
}
