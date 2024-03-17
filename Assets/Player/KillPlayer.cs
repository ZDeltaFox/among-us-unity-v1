using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
#region Players
    [Header ("Players")]
    public bool player1;
    public bool player2;
    public bool player3;
    public bool player4;
    public bool player5;
    public bool player6;
    public bool player7;
    public bool player8;
    public bool player9;
    public bool player10;
#endregion
#region Killed
    [Header ("Killed")]
    public float p1;
    public float p2;
    public float p3;
    public float p4;
    public float p5;
    public float p6;
    public float p7;
    public float p8;
    public float p9;
    public float p10;

    public static float sp1;
    public static float sp2;
    public static float sp3;
    public static float sp4;
    public static float sp5;
    public static float sp6;
    public static float sp7;
    public static float sp8;
    public static float sp9;
    public static float sp10;
#endregion
#region Void Update
    void Update()
    {
        sp1 = p1;
        sp2 = p2;
        sp3 = p3;
        sp4 = p4;
        sp5 = p5;
        sp6 = p6;
        sp7 = p7;
        sp8 = p8;
        sp9 = p9;
        sp10 = p10;
    }
#endregion
#region Button
    public void KillBtn()
    {
        if (player1) p1 = 1;
        if (player2) p2 = 1;
        if (player3) p3 = 1;
        if (player4) p4 = 1;
        if (player5) p5 = 1;
        if (player6) p6 = 1;
        if (player7) p7 = 1;
        if (player8) p8 = 1;
        if (player9) p9 = 1;
        if (player10) p10 = 1;
    }
#endregion

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player") {p1 = 1;}
        else {player1 = false;}

        if (other.gameObject.tag == "Player1") {p2 = 1;}
        else {player2 = false;}

        if (other.gameObject.tag == "Player2") {p3 = 1;}
        else {player3 = false;}

        if (other.gameObject.tag == "Player3") {p4 = 1;}
        else {player4 = false;}

        if (other.gameObject.tag == "Player4") {p5 = 1;}
        else {player5 = false;}

        if (other.gameObject.tag == "Player5") {p6 = 1;}
        else {player6 = false;}


        if (other.gameObject.tag == "Player6") {p7 = 1;}
        else {player7 = false;}

        if (other.gameObject.tag == "Player7") {p8 = 1;}
        else {player8 = false;}

        if (other.gameObject.tag == "Player8") {p9 = 1;}
        else {player9 = false;}

        if (other.gameObject.tag == "Player9") {p10 = 1;}
        else {player10 = false;}
    } 
}
