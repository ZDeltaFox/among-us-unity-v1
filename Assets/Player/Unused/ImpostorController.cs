using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpostorController : MonoBehaviour
{
    public GameObject Knife;
    public GameObject Gun;

    public float actualGun;

    public static float killTimer;

    void Start()
    {
        Knife.SetActive(false);
        Gun.SetActive(false);
        killTimer = 0f;
    }

    void Update()
    {
        killTimer += Time.deltaTime;
        
        #region changeGun
        if (actualGun == 0)
        {
            Knife.SetActive(false);
            Gun.SetActive(false);
        }

        if (actualGun == 1)
        {
            Knife.SetActive(true);
            Gun.SetActive(false);
        }

        if (actualGun == 2)
        {
            Knife.SetActive(false);
            Gun.SetActive(true);
        }

        if (killTimer <= 30)
        {
            actualGun = 0;
        }

        if (Input.GetKey("1")) {actualGun = 0;}
        if (Input.GetKey("2")) {actualGun = 1;}
        if (Input.GetKey("3")) {actualGun = 2;}

        #endregion
    }

    public void ChangeGun()
    {
        if (actualGun == 0) {actualGun = 1;}
        if (actualGun == 1) {actualGun = 2;}
        if (actualGun == 2) {actualGun = 0;}
    }
}