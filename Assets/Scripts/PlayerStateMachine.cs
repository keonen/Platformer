using UnityEngine;
using System.Collections;

public class PlayerStateMachine : MonoBehaviour {
	
	public float Speed = 3f;
	public float MaxJumpTime = 2f;
	private float move = 0f;
	public float JumpForce = 2f; 
	public float JumpTime = 0f;
	public float playerVelocity;
	private bool CanJump;
	private bool playerOnTheGround;
	public Animator anim;
	enum CharacterState {OnGround, InAir, Climbing};
	CharacterState characterState = CharacterState.OnGround;
	
	void OnCollisionStay2D (Collision2D col)
	{
		if(col.gameObject.tag == "Ground")
		{
			playerOnTheGround = true;
			Debug.Log ("Pelaaja osuu maahan!");
		}
	}
	
	void OnCollisionExit2D (Collision2D col)
	{
		if(col.gameObject.tag == "Ground")
		{
			playerOnTheGround = false;
			Debug.Log ("Pelaaja ei osu maahan!");
		}
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
		
		playerVelocity = Mathf.Abs(GetComponent<Rigidbody2D> ().velocity.x);
		
		// Sets the value
		anim.SetFloat ("velocity", playerVelocity);
		
		switch (characterState)
		{
		case CharacterState.OnGround:
			float horizontal = Input.GetAxis("Horizontal");
			
			anim.SetFloat("velocity", Mathf.Abs(horizontal));
			break;
		case CharacterState.InAir:
			break;
		case CharacterState.Climbing:
			break;
			
		}
		
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
			Debug.Log(checkDirection);
		}
		
		if (Input.GetKey (KeyCode.D) && checkDirection == 1)
		{
			transform.localRotation = Quaternion.Euler(0, 0, 0);
			
			//transform.Rotate (Vector3.up * -180 * checkDirection);
			Debug.Log(checkDirection);
		}
		
	}
}
