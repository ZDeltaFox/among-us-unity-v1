using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("Camera-Control/Mouse Look")]

public class DeathCam : MonoBehaviour
{
	public float Sensibilidad;

    public Transform playerBody;

    public float xRotacion;

    void Update()
    {
        if (MultiplayerPlayerController.SusPlayerMovement.canMove)
        {
            if (!MultiplayerPlayerController.SusPlayerMovement.isInMission)
            {
                float mouseX = Input.GetAxis("Mouse X") * Sensibilidad * Time.deltaTime;
                float mouseY = Input.GetAxis("Mouse Y") * Sensibilidad * Time.deltaTime;

                playerBody.Rotate(Vector3.forward * mouseX);

                xRotacion -= mouseY;
                xRotacion = Mathf.Clamp(xRotacion, 45, 145);

                transform.localRotation = Quaternion.Euler(xRotacion, 0, 0);
            }
        }
    }
}
