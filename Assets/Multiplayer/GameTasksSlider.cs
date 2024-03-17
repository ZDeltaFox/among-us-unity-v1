using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTasksSlider : MonoBehaviour
{

    //1-169
    //public float PosTest;
    public static float PosChange;
    public static float Position;
    public float Scale;
    public GameObject TaskCube;
    public GameObject Tasks;

    void Update()
    {
        Tasks.transform.localScale = new Vector3(1, Scale, 1);

        TaskCube.transform.localPosition = new Vector3(Position, 1000, 0);

        //if (PosTest != 0) {PosChange = PosTest;}

        //Position = PosChange;
        Scale = TaskCube.transform.position.x;
    }

    void Start()
    {
        if (LobbyNetworkManager.MyPlayerNumberCounter == 1)
        {
            TaskCube.transform.localPosition = new Vector3(Position, 1000, 0);
        }
    }
}
