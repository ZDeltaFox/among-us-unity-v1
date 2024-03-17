using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDelete : MonoBehaviour
{
    #region GameObjects
    [HideInInspector]
    public GameObject ClearAsteroids;
    [HideInInspector]
    public GameObject Refuel1;
    [HideInInspector]
    public GameObject Refuel2;
    [HideInInspector]
    public GameObject UploadData1;
    [HideInInspector]
    public GameObject UploadData2;
    [HideInInspector]
    public GameObject UploadData3;
    [HideInInspector]
    public GameObject UploadData4;
    [HideInInspector]
    public GameObject UploadData5;
    [HideInInspector]
    public GameObject UploadData6;
    [HideInInspector]
    public GameObject DivertPower1;
    [HideInInspector]
    public GameObject DivertPower2;
    [HideInInspector]
    public GameObject DivertPower3;
    [HideInInspector]
    public GameObject DivertPower4;
    [HideInInspector]
    public GameObject DivertPower5;
    [HideInInspector]
    public GameObject DivertPower6;
    [HideInInspector]
    public GameObject DivertPower7;
    [HideInInspector]
    public GameObject DivertPower8;
    [HideInInspector]
    public GameObject CalibrateDistributor;
    [HideInInspector]
    public GameObject EmptyGarbage1;
    [HideInInspector]
    public GameObject EmptyGarbage2;
    [HideInInspector]
    public GameObject EmptyGarbage3;
    [HideInInspector]
    public GameObject PrimeShields;
    [HideInInspector]
    public GameObject RebootWifi1;
    [HideInInspector]
    public GameObject SwipeCard;
    [HideInInspector]
    public GameObject ChartCourse;
    [HideInInspector]
    public GameObject AlignEngineOutput1;
    [HideInInspector]
    public GameObject AlignEngineOutput2;
    [HideInInspector]
    public GameObject InspectSample;
    [HideInInspector]
    public GameObject UnlockManifolds;
    #endregion

    void Update()
    {
        if (SpawnAsteroids.Finished == true) {Destroy(ClearAsteroids);}
        if (Fuel.Finished == true) {Destroy(Refuel1);}
        if (Fuel1.Finished == true) {Destroy(Refuel2);}
        if (Download.Finished == true) {Destroy(UploadData1);}
        if (Download1.Finished == true) {Destroy(UploadData2);}
        if (Download2.Finished == true) {Destroy(UploadData3);}
        if (Download3.Finished == true) {Destroy(UploadData4);}
        if (Download4.Finished == true) {Destroy(UploadData5);}
        if (Download5.Finished == true) {Destroy(UploadData6);}
        if (Divert.Finished == true) {Destroy(DivertPower1);}
        if (Divert1.Finished == true) {Destroy(DivertPower2);}
        if (Divert2.Finished == true) {Destroy(DivertPower3);}
        if (Divert3.Finished == true) {Destroy(DivertPower4);}
        if (Divert4.Finished == true) {Destroy(DivertPower5);}
        if (Divert5.Finished == true) {Destroy(DivertPower6);}
        if (Divert6.Finished == true) {Destroy(DivertPower7);}
        if (Divert7.Finished == true) {Destroy(DivertPower8);}
        if (Calibrate.Finished == true) {Destroy(CalibrateDistributor);}
        if (Garbage.EmptyGarbage.Finished == true) {Destroy(EmptyGarbage1);}
        if (Garbage.EmptyGarbage1.Finished == true) {Destroy(EmptyGarbage2);}
        if (Garbage.EmptyGarbage2.Finished == true) {Destroy(EmptyGarbage3);}
        if (ShieldButtons.Finished == true) {Destroy(PrimeShields);}
        if (RebootWifi.Finished == true) {Destroy(RebootWifi1);}
        if (SwipeTask.Finished == true) {Destroy(SwipeCard);}
        if (Course.Finished == true) {Destroy(ChartCourse);}
        if (Align.Finished == true) {Destroy(AlignEngineOutput1);}
        if (Align1.Finished == true) {Destroy(AlignEngineOutput2);}
        if (Inspect.Finished == true) {Destroy(InspectSample);}
        if (UnlockManifoldsTask.Finished == true) {Destroy(UnlockManifolds);}
    }
}
