using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour 
{
	public Transform playerObject;
	PlayerMovement playerMovement;
	bool canMovePlayer;

	void OnEnable()
	{
		playerMovement = playerObject.GetComponent<PlayerMovement>();
	}

	void Start()
	{
		canMovePlayer = true;
		StartCoroutine("InputCheck");
	}

	IEnumerator InputCheck()
	{
		while (canMovePlayer)
		{
			CheckRotation();

			CheckMovement();

			yield return 0;
		}
	}

	void CheckMovement()
	{
		if (Input.anyKey)
		{
			Vector3 direction = Vector3.zero;

			if (Input.GetAxis("Horizontal") != 0)
			{
				direction.x = Input.GetAxisRaw ("Horizontal");
			}
			if (Input.GetAxis("Vertical") != 0)
			{
				direction.z = Input.GetAxisRaw ("Vertical");
			}
			playerMovement.MovePlayer(direction.normalized); //Make movement camera relative?
		}
	}

	void CheckRotation()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			if (Vector3.Distance(playerObject.position, hit.point) > 1.0f)
			{
				playerMovement.RotatePlayer(hit.point);
			}
		}
	}
}
