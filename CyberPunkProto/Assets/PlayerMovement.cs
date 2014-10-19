using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	bool canMove;

	void OnEnable()
	{
		canMove = true;
	}

	public void MovePlayer(Vector3 direction)
	{
		if (canMove)
		{
			Vector3 movement = direction * 5f * Time.deltaTime; //The '5f' should be replaced with a function that accelerates at start of movement and decelerates at end.
			rigidbody.MovePosition(rigidbody.position + movement);
		}
	}

	public void RotatePlayer(Vector3 direction)
	{
		if (canMove)
		{
			Quaternion rotation = Quaternion.Slerp(rigidbody.rotation,Quaternion.LookRotation(direction - rigidbody.position), 5f * Time.deltaTime);
			rigidbody.MoveRotation(rotation);
		}
	}
}
