using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShoot : MonoBehaviour 
{

    //Al salir de la colision
	void OnTriggerExit(Collider other)
    {

        //Destruyo el objeto
        Destroy(other.gameObject);

    }
}