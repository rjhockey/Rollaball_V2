using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{

	// Before rendering each frame. Use FixedUpdate when applying physics
	// Use void Update() for all other
	void FixedUpdate()
	{
		// Rotate the game object that this script is attached to by 15 in the X axis,
		// 30 in the Y axis and 45 in the Z axis, multiplied by deltaTime in order to 
		// make it per second rather than per frame.

		// to speed up and change direction, hard to control
		//transform.Rotate(new Vector3(0, 0, Mathf.PingPong(Time.time, 60) - 20));

		// * Time.deltaTime adjusts for the varying frame rates between diff computers
		transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime * 4);
		//GameObject.Find("PickUp").transform.Rotate(new Vector3(45, 30, 15) * Time.deltaTime);
	}

}