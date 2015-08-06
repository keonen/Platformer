using UnityEngine;
using System.Collections;

public class FollowingObject : MonoBehaviour {

	public Transform target;
	public float scale = 0.2f;

	private Vector3 targetPreviousPosition;

	void Start()
	{
		targetPreviousPosition = target.position;
	}

	// Update is called once per frame
	void LateUpdate () 
	{
		Vector3 targetMovement = target.position - targetPreviousPosition;

		Vector3 tempMovement = targetMovement;
		tempMovement.z = 0f;

		transform.position += new Vector3(targetMovement.x, targetMovement.y, 0f) * scale;

		targetPreviousPosition = target.position;
	}
}
