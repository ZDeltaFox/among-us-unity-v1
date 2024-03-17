using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AsteroidDirection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    float RandomDirX;
    float RandomDirY;

    float RandomRotZ;

    bool isEntered;

    public GameObject Root;
    
    void Start()
    {
        
        gameObject.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));

        gameObject.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        RandomDirX = Random.Range(-2.5f, 2.5f);
        RandomDirY = Random.Range(-2.5f, 2.5f);
        RandomRotZ = Random.Range(-2.5f, 2.5f);
    }

    void Update()
    {
        gameObject.transform.position += new Vector3(RandomDirX, RandomDirY, 0);
        gameObject.transform.eulerAngles += new Vector3(0, 0, RandomRotZ);

        if (Input.GetKeyDown("mouse 0"))
        {
            if (isEntered)
            {
                SpawnAsteroids.sPoints++;
                Destroy(Root);
            }
        }

        if (SpawnAsteroids.Destroy) {Destroy(Root);}
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isEntered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isEntered = false;
    }
}
