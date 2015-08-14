//using UnityEngine;
//using System.Collections;
//
//public class SpaceManController : ObjectController {
//	
//	public enum CharacterState {OnGround, InAir, Climbing};
//	public CharacterState characterState;
//	
//	Animator animator;
//	Rigidbody2D rbody;
//	
//	public Transform groundCheck;
//	
//	public float jumpSpeed = 5f;
//	
//	public float walkingSpeed = 5f;
//	public float climbingSpeed = 5f;
//	public float horizontalSpeed;
//	public float verticalSpeed;
//	
//	private float horizontalInput;
//	private float verticalInput;
//	private bool jumped;
//	public bool canClimb;
//	public Vector2 inputMovement;
//
//	public Vector2 surfaceNormal;
//	
//	//	public Collider2D otherCollider;
//	public CircleCollider2D feetCollider;
//	
//	public LayerMask groundCheckMask;
//	
//	void Start ()
//	{
//		animator = GetComponentInChildren<Animator>();
//		rbody = GetComponent<Rigidbody2D>();
//		
//		ChangeState(CharacterState.OnGround);
//	}
//
//	public Vector2 dropVelocity = Vector2.zero;
//	public Vector2 currentGravityForce = Vector2.zero;
//	
//	protected override void Update ()
//	{
//		base.Update ();
//
//		CheckInput();
//		CheckState();
//		
//		horizontalSpeed = 0f;
//		verticalSpeed = 0f;
//		//verticalSpeed = rbody.velocity.y;
//
//
//
//		//rbody.velocity += gravityForce * Time.deltaTime;
//
//
//		switch(characterState)
//		{
//		case CharacterState.OnGround:
//
//			dropVelocity += currentGravityForce * Time.deltaTime;
//
//			transform.up = -dropVelocity.normalized;
//			Vector3 rotation = new Vector3(0f, 0f, transform.eulerAngles.z);
//			transform.eulerAngles = rotation; 
//
//			if(jumped)
//			{
//				verticalSpeed += jumpSpeed;
//				dropVelocity += (Vector2)transform.up* jumpSpeed;
//			}
//			horizontalSpeed = horizontalInput * walkingSpeed;
//			
//			transform.localScale = new Vector3(Mathf.Sign(horizontalSpeed), 1f, 1f);
//			animator.SetFloat("speed", Mathf.Abs(horizontalSpeed));
//			break;
//		case CharacterState.InAir:
//			
//			horizontalSpeed = horizontalInput * walkingSpeed;
//			
//			break;
//		case CharacterState.Climbing:
//			
//			horizontalSpeed = horizontalInput * climbingSpeed;
//			verticalSpeed = verticalInput * climbingSpeed;
//			
//			break;
//		}
//		
//
//
//		dropVelocity += currentGravityForce * Time.deltaTime;
//		inputMovement += (Vector2)transform.right * horizontalSpeed + (Vector2)transform.up * verticalSpeed;
//
//		rbody.velocity = transform.right * horizontalSpeed + transform.up * verticalSpeed;
//	}
//	
//	void CheckState()
//	{
//		switch(characterState)
//		{
//		case CharacterState.OnGround:
//			GroundCheck();
//			CheckIfClimbing();
//			break;
//		case CharacterState.InAir:
//			GroundCheck();
//			CheckIfClimbing();
//			break;
//		case CharacterState.Climbing:
//			if(!canClimb)
//			{
//				GroundCheck();
//			}
//			break;
//		}
//	}
//	
//	void ChangeState(CharacterState nextState)
//	{
//		switch(nextState)
//		{
//		case CharacterState.OnGround:
//			Physics2D.IgnoreLayerCollision(
//				gameObject.layer, 
//				LayerMask.NameToLayer("Platform"), 
//				false);
//			//rbody.gravityScale = 1f;
//			break;
//		case CharacterState.InAir:
//			Physics2D.IgnoreLayerCollision(
//				gameObject.layer, 
//				LayerMask.NameToLayer("Platform"), 
//				false);
//			//rbody.gravityScale = 1f;
//			break;
//		case CharacterState.Climbing:
//			Physics2D.IgnoreLayerCollision(
//				gameObject.layer, 
//				LayerMask.NameToLayer("Platform"), 
//				true);
//			//rbody.gravityScale = 0f;
//			break;
//		}
//		
//		characterState = nextState;
//	}
//	
//	void CheckInput()
//	{
//		horizontalInput = Input.GetAxis("Horizontal");
//		verticalInput = Input.GetAxis ("Vertical");
//		
//		jumped = Input.GetKeyDown(KeyCode.Space);
//	}
//	
//	void CheckIfClimbing()
//	{
//		if(verticalInput != 0f && canClimb)
//			ChangeState(CharacterState.Climbing);
//	}
//	
//	void GroundCheck()
//	{
//		//		RaycastHit2D hit = Physics2D.Linecast(
//		//								transform.position, 
//		//								groundCheck.position, 
//		//								groundCheckMask.value);
//		
//		//		Vector2 direction = groundCheck.position - transform.position;
//
//		Vector2 startPosition = transform.position + transform.up * feetCollider.offset.y;
//		float radius = feetCollider.radius;
//		Vector2 direction = -transform.up;
//		float distance = Vector2.Distance(groundCheck.position, startPosition) - feetCollider.radius;
//
//		RaycastHit2D hit = Physics2D.Linecast (
//					transform.position,
//					groundCheck.position,
//					groundCheckMask.value);
//
////		RaycastHit2D hit = Physics2D.CircleCast(
////			transform.position + transform.up * feetCollider.offset.y,
////			feetCollider.radius,
////			-transform.up,
////			groundCheck.position.y - startPosition.y - feetCollider.radius,
////			groundCheckMask.value);
//		
//		if(hit.collider != null)
//		{
//			surfaceNormal = hit.normal;
//			ChangeState(CharacterState.OnGround);
//		}
//		else
//		{
//			ChangeState(CharacterState.InAir);
//		}
//	}
//
//	public bool onGround = false;
//
//	void OnTriggerStay2D(Collider2D collider)
//	{
//
//	}
//}
