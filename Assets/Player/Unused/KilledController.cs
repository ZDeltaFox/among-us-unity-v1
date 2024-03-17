using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KilledController : MonoBehaviour
{
    public GameObject crewmate;
    public GameObject deathCrewmate;
    public GameObject ghost;

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Shoot")
        {
            crewmate.SetActive(false);
            deathCrewmate.SetActive(true);
            ghost.SetActive(true);
        }
    }
}