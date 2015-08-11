using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float Speed = 3f;
	public float MaxJumpTime = 2f;
	private float move = 0f;
	public float JumpForce = 2f; 
	public float JumpTime = 0f;
	public float playerVelocity;
	private bool CanJump;
	private bool playerOnTheGround;
	public Animator anim;
	public bool canClimb = false;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Ladder") {
			canClimb = true;
			GetComponent<Rigidbody2D>().gravityScale = 0;
			GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, -0.01f);
			Debug.Log("Laddder trigger -> canClimb true.");
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Ladder") {
			canClimb = false;
			GetComponent<Rigidbody2D>().gravityScale = 1;
			Debug.Log("Laddder trigger -> canClimb false.");
		}
	}

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

		if (Input.GetKey(KeyCode.W))
		{
			if (canClimb)
			{
				anim.SetBool ("isClimbing", true);
				GetComponent<Rigidbody2D>().velocity = new Vector2 (0f, 2f);
			}
		}
		if (Input.GetKeyUp(KeyCode.W))
		{
				anim.SetBool ("isClimbing", false);
				GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}

		if (Input.GetKey(KeyCode.S))
		{
			if (canClimb)
			{
				anim.SetBool ("isClimbing", true);
				GetComponent<Rigidbody2D>().velocity = new Vector2 (0f, -2f);
			}
		}
		if (Input.GetKeyUp(KeyCode.S))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0f, 0f);
			anim.SetBool ("isClimbing", false);
		}

		playerVelocity = Mathf.Abs(GetComponent<Rigidbody2D> ().velocity.x);

		// Sets the value
		anim.SetFloat ("speed", playerVelocity);


	}

	void FixedUpdate () {
		move = Input.GetAxis ("Horizontal");
		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * Speed, GetComponent<Rigidbody2D>().velocity.y);

		if (Input.GetKeyDown (KeyCode.Space) && CanJump && playerOnTheGround)
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
			anim.SetBool ("isClimbing", false);
		}

		if (Input.GetKey (KeyCode.D) && checkDirection == 1)
		{
			transform.localRotation = Quaternion.Euler(0, 0, 0);

			//transform.Rotate (Vector3.up * -180 * checkDirection);
			//Debug.Log(checkDirection);
			anim.SetBool ("isClimbing", false);
		}

	
	}
}
