using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavController : MonoBehaviour 
{

	//Declarlo la variable de tipo RigidBody que luego asociaremos a nuestro objeto
	private Rigidbody rb;
	
	//Declaro la variable publica velocidad para poder modificarla desde la Inspector window
	[Range(5,15)]
	public float velocidad = 10;

	//Limites del juego
    //Modificar estos ajustes para hacer el cuchillo
	float xMin = -5.8f;
	float xMax = 5.8f; 
	float zMin = -3.7f;
	float zMax = 13.5f;

	//Declaro la variable publica giro para poder modificarla desde la Inspector window
	[Range(-1,-10)]
	public float giro = -4;

	//Declaro la variable de tipo GameObject que luego asociaremos a nuestro prefab Disparos
	public GameObject disparo;

	//Declaro la variable de tipo Transform para la posicion del disparador
	public Transform disparador;

	//Declaro la variable de tipo float velocidadDisparo para la velocidad con la que puedo generar disparos
	[Range(0,1)]
	public float velocidadDisparo = 0.25f; //4 por segundo

	void Start () 
    {

		//Capturo el rigidbody del jugador al iniciar el juego
		rb = GetComponent<Rigidbody>();

	}

	//Esto lo ejecuta antes de actualizar el ultimo frame
	void Update () 
    {


		if (Input.GetButton("Fire1"))
        {
			//Instancio un nuevo disparo en esa posicion y con esa rotacion
			Instantiate(disparo, disparador.position, disparador.rotation);	

			//Reiniciar el cooldown de muerte
			ImpostorController.killTimer = 0f;		
		}

	}
	
	// Porque voy a utilizar la fisica para moverlo
	void FixedUpdate () 
    {

		//Capturo el movimiento en horizontal y vertical de nuestro teclado
		float movimientoH = Input.GetAxis("Horizontal");
		float movimientoV = Input.GetAxis("Vertical");	

		//Genero el vector de movimiento asociado, teniendo en cuenta la velocidad
		Vector3 movimiento = new Vector3(movimientoH * velocidad, 0.0f, movimientoV * velocidad);

		//Aplico ese movimiento al RigidBody de la nave
		rb.AddForce(movimiento);

		//Restrinjo la posicion de la nave a los limites del juego
		rb.position = new Vector3 
        (
            Mathf.Clamp (rb.position.x, xMin, xMax), 
            0.0f, 
            Mathf.Clamp (rb.position.z, zMin, zMax)
        );

		//Rotacion de la nave en Z en funcion de la velocidad en X
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * giro);
	}
}