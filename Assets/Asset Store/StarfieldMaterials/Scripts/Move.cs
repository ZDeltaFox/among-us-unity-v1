using UnityEngine; 
using System.Collections;

public class Move : MonoBehaviour
{
    float Target;

	[Header ("Velocity")]
	public float Vel;

	bool isDirForward;
	[Header ("Direction")]
	public float forward;
	public float back;

	void Update()
	{
        Target += Time.deltaTime / 10000;

		if (transform.position.z >= forward) {if (transform.position.z >= back) {isDirForward = false;}}

		if (transform.position.z <= back) {if (transform.position.z <= forward) {isDirForward = true;}}

		if (isDirForward) {transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, Target), Vel / 10);}
		if (!isDirForward) {transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, Target), -Vel / 10);}
	}
}