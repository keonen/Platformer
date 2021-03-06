﻿using UnityEngine;
using System.Collections;

public class PlayerMovementTesting : MonoBehaviour {

	public float Speed = 3f;
	public float MaxJumpTime = 2f;
	private float move = 0f;
	public float JumpForce = 2f; 
	public float JumpTime = 0f;
	public float playerVelocity;
	private bool CanJump;
	private bool playerOnTheGround;
	public Animator anim;

	public LayerMask groundCheckMask;
	
	public CircleCollider2D feetCollider;

	void OnCollisionStay2D (Collision2D col)
	{
		if(col.gameObject.tag == "Ground")
		{
			playerOnTheGround = true;
			//Debug.Log ("Pelaaja osuu maahan!");
		}
	}

	void OnCollisionExit2D (Collision2D col)
	{
		if(col.gameObject.tag == "Ground")
		{
			playerOnTheGround = false;
			//Debug.Log ("Pelaaja ei osu maahan!");
		}
	}

	bool GroundCheck()
	{
//		RaycastHit2D hit = Physics2D.Linecast (
//								transform.position,
//								groundCheck.position,
//								groundCheckMask.value);
//	
//		Vector2 direction = groundCheck.position - transform.position;

		RaycastHit2D hit = Physics2D.CircleCast (
								transform.position + transform.up * feetCollider.offset.y,
								feetCollider.radius,
								-transform.up,
								0.2f,
								groundCheckMask.value);

//		Debug.DrawLine (transform.position, groundCheck.position, Color.blue);

		if (hit.collider != null) 
		{
			return true;
		} else
			return false;

	}
		
	void Start()
	{
		// Get the Animator component from your gameObject
		anim = GetComponent<Animator>();


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

		if(Input.GetKeyDown(KeyCode.R))
		{
			Application.LoadLevel(Application.loadedLevel);
		}

		if(Input.GetKeyDown(KeyCode.E))
		{
			anim.SetBool ("isWaving", true);
		}

		if(Input.GetKeyUp(KeyCode.E))
		{
			anim.SetBool ("isWaving", false);
		}

		playerVelocity = Mathf.Abs(GetComponent<Rigidbody2D> ().velocity.x);

		// Sets the value
		anim.SetFloat ("speed", playerVelocity);


	}

	void FixedUpdate () {
		move = Input.GetAxis ("Horizontal");
		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * Speed, GetComponent<Rigidbody2D>().velocity.y);

		if (((Input.GetKeyDown (KeyCode.Space)) || (Input.GetKeyDown (KeyCode.W))) && CanJump && playerOnTheGround)
		{
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, JumpForce));

			CanJump = false;
			JumpTime = MaxJumpTime;
		}

		float checkDirection = Mathf.Sign(GetComponent<Rigidbody2D> ().velocity.x);

		if (Input.GetKey (KeyCode.A) && checkDirection == -1)
		{
			transform.localRotation = Quaternion.Euler(0, 180, 0);
		
			//transform.Rotate (Vector3.up * -180 * checkDirection);
			//Debug.Log(checkDirection);
		}

		if (Input.GetKey (KeyCode.D) && checkDirection == 1)
		{
			transform.localRotation = Quaternion.Euler(0, 0, 0);

			//transform.Rotate (Vector3.up * -180 * checkDirection);
			//Debug.Log(checkDirection);
		}

		if (Input.GetKeyDown (KeyCode.C))
		{

		}
	
	}
}
