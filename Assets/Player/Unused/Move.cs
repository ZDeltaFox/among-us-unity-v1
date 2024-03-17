using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace MultiplayerPlayerController
{
    public class Move : MonoBehaviour
    {
        public float speed;
        public Rigidbody rig;
        PhotonView PV;

        void Start()
        {
            PV = GetComponent<PhotonView>();
        }

        void FixedUpdate()
        {
            if (PV.IsMine)
            {
                float t_hmove = Input.GetAxisRaw("Vertical");
                float t_vmove = Input.GetAxisRaw("Horizontal");

                Vector3 t_direction = new Vector3(t_hmove, t_vmove, 0);
                t_direction.Normalize();

                float t_adjustedSpeed = speed;

                rig.velocity = transform.TransformDirection(t_direction) * speed * Time.deltaTime;
            }
        }
    }
}
