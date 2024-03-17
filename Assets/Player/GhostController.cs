using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public CharacterController cc;
    public float Velocidad = 48;

    public float Gravedad = -9.81f;
    public Vector3 velocity;

    public float maxX;
    public float maxY;
    public float maxZ;
    public float minX;
    public float minY;
    public float minZ;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (transform.position.y <= maxY)
        {
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(3 * -2 * Gravedad);
            }
        }

        if (transform.position.y >= minY)
        {
            if (Input.GetKey("left shift"))
            {
                velocity.y = Mathf.Sqrt(-3 * -2 * Gravedad);
            }
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        cc.Move(move * Velocidad * Time.deltaTime);
            
        cc.Move(velocity * Time.deltaTime);

        //if (Velocidad <= 140)
        //{
            //if (Input.GetKey("mouse 0"))
            //{
                //if (timer >= 0.3)
                //{
                    //Velocidad += 4;
                    //timer = 0;
                //}
            //}
        //}

        //if (Velocidad >= 8)
        //{
            //if (Input.GetKey("mouse 1"))
            //{
                //if (timer >= 0.3)
                //{
                    //Velocidad -= 4;
                    //timer = 0;
                //}
            //}
        //}
    }
}