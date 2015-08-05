using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float Speed = 3f;
	public float MaxJumpTime = 2f;
	private float move = 0f;
	public float JumpForce = 2f; 
	private float JumpTime = 0f;
	private bool CanJump;


	void Start () {

	}
	
	
	void Update ()
	{
		if (!CanJump)
			JumpTime  -= Time.deltaTime;
		if (JumpTime <= 0)
		{
			CanJump = true;
			JumpTime  = MaxJumpTime;
		}

	}
	
	void FixedUpdate () {
		move = Input.GetAxis ("Horizontal");
		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * Speed, GetComponent<Rigidbody2D>().velocity.y);

		if (Input.GetKeyDown (KeyCode.Space) && CanJump) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, JumpForce));

			CanJump = false;
			JumpTime = MaxJumpTime;
		}

		float checkDirection = Mathf.Sign(GetComponent<Rigidbody2D> ().velocity.x);

		if (Input.GetKeyDown (KeyCode.A) && checkDirection == -1)
		{
			transform.Rotate (Vector3.up * -180 * checkDirection);
			Debug.Log(checkDirection);
		}

		if (Input.GetKeyDown (KeyCode.D) && checkDirection == 1)
		{
			transform.Rotate (Vector3.up * -180 * checkDirection);
			Debug.Log(checkDirection);
		}
	
	}
}
