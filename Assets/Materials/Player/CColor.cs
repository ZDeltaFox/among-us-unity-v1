using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CColor : MonoBehaviour
{
    public Material material1;
    public Material material2;
    public Material material3;
    public Material material4;
    public Material material5;
    public Material material6;
    public Material material7;
    public Material material8;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject player5;
    public GameObject player6;
    public GameObject player7;
    public GameObject player8;

    float setColor1;
    float setColor2;
    float setColor3;
    float setColor4;
    float setColor5;
    float setColor6;
    float setColor7;
    float setColor8;

    public float colorPlayer1;
    public float colorPlayer2;
    public float colorPlayer3;
    public float colorPlayer4;
    public float colorPlayer5;
    public float colorPlayer6;
    public float colorPlayer7;
    public float colorPlayer8;

    //public void RandomColorMaterial()
    //{
        //material.color = Random.ColorHSV();
        //setColor = -1;
        //PlayerPrefs.SetFloat("actualColor", setColor);
    //}

    //public void DefaultColor(){setColor = 0; PlayerPrefs.SetFloat("actualColor", setColor);}
    //public void RedColor(){setColor = 1; PlayerPrefs.SetFloat("actualColor", setColor);}
    //public void YellowColor(){setColor = 2; PlayerPrefs.SetFloat("actualColor", setColor);}
    //public void CianColor(){setColor = 3; PlayerPrefs.SetFloat("actualColor", setColor);}
    //public void BlueColor(){setColor = 4; PlayerPrefs.SetFloat("actualColor", setColor);}
    //public void GreenColor(){setColor = 5; PlayerPrefs.SetFloat("actualColor", setColor);}
    //public void PinkColor(){setColor = 6; PlayerPrefs.SetFloat("actualColor", setColor);}

    void Update()
    {
        StartCoroutine(RepeatedColors());
#region MoveBlocks
        if (LobbyNetworkManager.MyPlayerNumberCounter == 1)
        {
            player1.transform.position = new Vector3(setColor1, 1000, 0);
            player2.transform.position = new Vector3(setColor2, 1000, 1);
            player3.transform.position = new Vector3(setColor3, 1000, 2);
            player4.transform.position = new Vector3(setColor4, 1000, 3);
            player5.transform.position = new Vector3(setColor5, 1000, 4);
            player6.transform.position = new Vector3(setColor6, 1000, 5);
            player7.transform.position = new Vector3(setColor7, 1000, 6);
            player8.transform.position = new Vector3(setColor8, 1000, 7);
        }
#endregion
#region Color Player1
        //Black
        if (colorPlayer1 == 1){material1.color = new Color(0, 0, 0);}
        //Blue
        if (colorPlayer1 == 2){material1.color = new Color(0, 0, 255);}
        //Brown
        if (colorPlayer1 == 3){material1.color = new Color(0, 204, 102);}
        //Cian
        if (colorPlayer1 == 4){material1.color = new Color(0, 255, 255);}
        //Green
        if (colorPlayer1 == 5){material1.color = new Color(255, 255, 255);}
        //Lime
        if (colorPlayer1 == 6){material1.color = new Color(0, 255, 0);}
        //Orange
        if (colorPlayer1 == 7){material1.color = new Color(255, 150, 0);}
        //Pink
        if (colorPlayer1 == 8){material1.color = new Color(255, 0, 255);}
        //Purple
        //if (colorPlayer1 == 9){material1.color = new Color(255, 255, 0);}
        //Red
        if (colorPlayer1 == 9){material1.color = new Color(128, 128, 128);}
#endregion
#region Color Player2
        //Black
        if (colorPlayer2 == 1){material2.color = new Color(0, 0, 0);}
        //Blue
        if (colorPlayer2 == 2){material2.color = new Color(0, 0, 255);}
        //Brown
        if (colorPlayer2 == 3){material2.color = new Color(0, 204, 102);}
        //Cian
        if (colorPlayer2 == 4){material2.color = new Color(0, 255, 255);}
        //Green
        if (colorPlayer2 == 5){material2.color = new Color(255, 255, 255);}
        //Lime
        if (colorPlayer2 == 6){material2.color = new Color(0, 255, 0);}
        //Orange
        if (colorPlayer2 == 7){material2.color = new Color(255, 150, 0);}
        //Pink
        if (colorPlayer2 == 8){material2.color = new Color(255, 0, 255);}
        //Purple
        //if (colorPlayer2 == 9){material2.color = new Color(255, 255, 0);}
        //Red
        if (colorPlayer2 == 9){material2.color = new Color(128, 128, 128);}
#endregion
#region Color Player3
        //Black
        if (colorPlayer3 == 1){material3.color = new Color(0, 0, 0);}
        //Blue
        if (colorPlayer3 == 2){material3.color = new Color(0, 0, 255);}
        //Brown
        if (colorPlayer1 == 3){material3.color = new Color(0, 204, 102);}
        //Cian
        if (colorPlayer3 == 4){material3.color = new Color(0, 255, 255);}
        //Green
        if (colorPlayer3 == 5){material3.color = new Color(255, 255, 255);}
        //Lime
        if (colorPlayer3 == 6){material3.color = new Color(0, 255, 0);}
        //Orange
        if (colorPlayer3 == 7){material3.color = new Color(255, 150, 0);}
        //Pink
        if (colorPlayer3 == 8){material3.color = new Color(255, 0, 255);}
        //Purple
        //if (colorPlayer3 == 9){material3.color = new Color(255, 255, 0);}
        //Red
        if (colorPlayer3 == 9){material3.color = new Color(128, 128, 128);}
#endregion
#region Color Player4
        //Black
        if (colorPlayer4 == 1){material4.color = new Color(0, 0, 0);}
        //Blue
        if (colorPlayer4 == 2){material4.color = new Color(0, 0, 255);}
        //Brown
        if (colorPlayer4 == 3){material4.color = new Color(0, 204, 102);}
        //Cian
        if (colorPlayer4 == 4){material4.color = new Color(0, 255, 255);}
        //Green
        if (colorPlayer4 == 5){material4.color = new Color(255, 255, 255);}
        //Lime
        if (colorPlayer4 == 6){material4.color = new Color(0, 255, 0);}
        //Orange
        if (colorPlayer4 == 7){material4.color = new Color(255, 150, 0);}
        //Pink
        if (colorPlayer4 == 8){material4.color = new Color(255, 0, 255);}
        //Purple
        //if (colorPlayer4 == 9){material4.color = new Color(255, 255, 0);}
        //Red
        if (colorPlayer4 == 9){material4.color = new Color(128, 128, 128);}
#endregion
#region Color Player5
        //Black
        if (colorPlayer5 == 1){material5.color = new Color(0, 0, 0);}
        //Blue
        if (colorPlayer5 == 2){material5.color = new Color(0, 0, 255);}
        //Brown
        if (colorPlayer5 == 3){material5.color = new Color(0, 204, 102);}
        //Cian
        if (colorPlayer5 == 4){material5.color = new Color(0, 255, 255);}
        //Green
        if (colorPlayer5 == 5){material5.color = new Color(255, 255, 255);}
        //Lime
        if (colorPlayer5 == 6){material5.color = new Color(0, 255, 0);}
        //Orange
        if (colorPlayer5 == 7){material5.color = new Color(255, 150, 0);}
        //Pink
        if (colorPlayer5 == 8){material5.color = new Color(255, 0, 255);}
        //Purple
        //if (colorPlayer5 == 9){material5.color = new Color(255, 255, 0);}
        //Red
        if (colorPlayer5 == 9){material5.color = new Color(128, 128, 128);}
#endregion
#region Color Player6
        //Black
        if (colorPlayer6 == 1){material6.color = new Color(0, 0, 0);}
        //Blue
        if (colorPlayer6 == 2){material6.color = new Color(0, 0, 255);}
        //Brown
        if (colorPlayer6 == 3){material6.color = new Color(0, 204, 102);}
        //Cian
        if (colorPlayer6 == 4){material6.color = new Color(0, 255, 255);}
        //Green
        if (colorPlayer6 == 5){material6.color = new Color(255, 255, 255);}
        //Lime
        if (colorPlayer6 == 6){material6.color = new Color(0, 255, 0);}
        //Orange
        if (colorPlayer6 == 7){material6.color = new Color(255, 150, 0);}
        //Pink
        if (colorPlayer6 == 8){material6.color = new Color(255, 0, 255);}
        //Purple
        //if (colorPlayer6 == 9){material6.color = new Color(255, 255, 0);}
        //Red
        if (colorPlayer6 == 9){material6.color = new Color(128, 128, 128);}
#endregion
#region Color Player7
        //Black
        if (colorPlayer7 == 1){material7.color = new Color(0, 0, 0);}
        //Blue
        if (colorPlayer7 == 2){material7.color = new Color(0, 0, 255);}
        //Brown
        if (colorPlayer7 == 3){material7.color = new Color(0, 204, 102);}
        //Cian
        if (colorPlayer7 == 4){material7.color = new Color(0, 255, 255);}
        //Green
        if (colorPlayer7 == 5){material7.color = new Color(255, 255, 255);}
        //Lime
        if (colorPlayer7 == 6){material7.color = new Color(0, 255, 0);}
        //Orange
        if (colorPlayer7 == 7){material7.color = new Color(255, 150, 0);}
        //Pink
        if (colorPlayer7 == 8){material7.color = new Color(255, 0, 255);}
        //Purple
        //if (colorPlayer7 == 9){material7.color = new Color(255, 255, 0);}
        //Red
        if (colorPlayer7 == 9){material7.color = new Color(128, 128, 128);}
#endregion
#region Color Player8
        //Black
        if (colorPlayer8 == 1){material8.color = new Color(0, 0, 0);}
        //Blue
        if (colorPlayer8 == 2){material8.color = new Color(0, 0, 255);}
        //Brown
        if (colorPlayer8 == 3){material8.color = new Color(0, 204, 102);}
        //Cian
        if (colorPlayer8 == 4){material8.color = new Color(0, 255, 255);}
        //Green
        if (colorPlayer8 == 5){material8.color = new Color(255, 255, 255);}
        //Lime
        if (colorPlayer8 == 6){material8.color = new Color(0, 255, 0);}
        //Orange
        if (colorPlayer8 == 7){material8.color = new Color(255, 150, 0);}
        //Pink
        if (colorPlayer8 == 8){material8.color = new Color(255, 0, 255);}
        //Purple
        //if (colorPlayer8 == 9){material8.color = new Color(255, 255, 0);}
        //Red
        if (colorPlayer8 == 9){material8.color = new Color(128, 128, 128);}
#endregion

#region Change Color With Block Position
        colorPlayer1 = Mathf.Round(player1.transform.position.x);
        colorPlayer2 = Mathf.Round(player2.transform.position.x);
        colorPlayer3 = Mathf.Round(player3.transform.position.x);
        colorPlayer4 = Mathf.Round(player4.transform.position.x);
        colorPlayer5 = Mathf.Round(player5.transform.position.x);
        colorPlayer6 = Mathf.Round(player6.transform.position.x);
        colorPlayer7 = Mathf.Round(player7.transform.position.x);
        colorPlayer8 = Mathf.Round(player8.transform.position.x);
#endregion
    }

    void Start()
    {
        //if (setColor == -1)
        //{
            //material.color = Random.ColorHSV();
        //}

        //setColor = PlayerPrefs.GetFloat("actualColor");

        StartCoroutine(RepeatedColors());
    }

    public IEnumerator RepeatedColors()
    {
        if (LobbyNetworkManager.MyPlayerNumberCounter == 1)
        {
#region SetColor
        if (setColor1 == 0)
        {
            setColor1 = Mathf.Round(Random.Range(1, 9));
            setColor2 = Mathf.Round(Random.Range(1, 9));
            setColor3 = Mathf.Round(Random.Range(1, 9));
            setColor4 = Mathf.Round(Random.Range(1, 9));
            setColor5 = Mathf.Round(Random.Range(1, 9));
            setColor6 = Mathf.Round(Random.Range(1, 9));
            setColor7 = Mathf.Round(Random.Range(1, 9));
            setColor8 = Mathf.Round(Random.Range(1, 9));
        }
#endregion
        yield return new WaitForSeconds(0.001f);
#region SetColor2
        if (setColor2 == setColor1) {setColor2 = Mathf.Round(Random.Range(1, 9));}
#endregion
        yield return new WaitForSeconds(0.001f);
#region SetColor3
        if (setColor3 == setColor1) {setColor3 = Mathf.Round(Random.Range(1, 9));}

        if (setColor3 == setColor2) {setColor3 = Mathf.Round(Random.Range(1, 9));}
#endregion
        yield return new WaitForSeconds(0.001f);
#region SetColor4
        if (setColor4 == setColor1) {setColor4 = Mathf.Round(Random.Range(1, 9));}

        if (setColor4 == setColor2) {setColor4 = Mathf.Round(Random.Range(1, 9));}

        if (setColor4 == setColor3) {setColor4 = Mathf.Round(Random.Range(1, 9));}
#endregion
        yield return new WaitForSeconds(0.001f);
#region SetColor5
        if (setColor5 == setColor1) {setColor5 = Mathf.Round(Random.Range(1, 9));}

        if (setColor5 == setColor2) {setColor5 = Mathf.Round(Random.Range(1, 9));}

        if (setColor5 == setColor3) {setColor5 = Mathf.Round(Random.Range(1, 9));}

        if (setColor5 == setColor4) {setColor5 = Mathf.Round(Random.Range(1, 9));}
#endregion
        yield return new WaitForSeconds(0.001f);
#region SetColor6
        if (setColor6 == setColor1) {setColor6 = Mathf.Round(Random.Range(1, 9));}

        if (setColor6 == setColor2) {setColor6 = Mathf.Round(Random.Range(1, 9));}

        if (setColor6 == setColor3) {setColor6 = Mathf.Round(Random.Range(1, 9));}

        if (setColor6 == setColor4) {setColor6 = Mathf.Round(Random.Range(1, 9));}

        if (setColor6 == setColor5) {setColor6 = Mathf.Round(Random.Range(1, 9));}
#endregion
        yield return new WaitForSeconds(0.001f);
#region SetColor7
        if (setColor7 == setColor1) {setColor7 = Mathf.Round(Random.Range(1, 9));}

        if (setColor7 == setColor2) {setColor7 = Mathf.Round(Random.Range(1, 9));}

        if (setColor7 == setColor3) {setColor7 = Mathf.Round(Random.Range(1, 9));}

        if (setColor7 == setColor4) {setColor7 = Mathf.Round(Random.Range(1, 9));}

        if (setColor7 == setColor5) {setColor7 = Mathf.Round(Random.Range(1, 9));}

        if (setColor7 == setColor6) {setColor7 = Mathf.Round(Random.Range(1, 9));}
#endregion
        yield return new WaitForSeconds(0.001f);
#region SetColor8
        if (setColor8 == setColor1) {setColor8 = Mathf.Round(Random.Range(1, 9));}

        if (setColor8 == setColor2) {setColor8 = Mathf.Round(Random.Range(1, 9));}

        if (setColor8 == setColor3) {setColor8 = Mathf.Round(Random.Range(1, 9));}

        if (setColor8 == setColor4) {setColor8 = Mathf.Round(Random.Range(1, 9));}

        if (setColor8 == setColor5) {setColor8 = Mathf.Round(Random.Range(1, 9));}

        if (setColor8 == setColor6) {setColor8 = Mathf.Round(Random.Range(1, 9));}

        if (setColor8 == setColor7) {setColor8 = Mathf.Round(Random.Range(1, 9));}
#endregion
        }
    }
}
