using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandPos : MonoBehaviour
{
    //float PosX;
    //float PosY;
    Vector3 SpawnPos;
    float RandomObject;

    
    void Start()
    {
        gameObject.transform.position = new Vector3(Random.Range(330, 480), Random.Range(130, 380), 0);
        gameObject.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        SpawnPos = gameObject.transform.position;
        RandomObject = Random.Range(1, 4);
    }

    void Update()
    {
        if (RandomObject == 3) {Destroy(gameObject);}
    }
}
