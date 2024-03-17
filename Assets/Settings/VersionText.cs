using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VersionText : MonoBehaviour
{
    public TMP_Text Version;
    
    void Update()
    {
        Version.text = "Version: " + DownloadGame.sActualVersion + " ";
    }
}
