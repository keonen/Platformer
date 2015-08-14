//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//
//public class GravityFieldIndependent : MonoBehaviour {
//	
//	public float forceMagnitude = 1f;
//	public Vector2 forceDirection = Vector2.zero;
//	public float distanceScale = 1f;
//
//	public List<Rigidbody2D> rigidbodies = new List<Rigidbody2D>();
//
//	void FixedUpdate()
//	{
//		foreach (Rigidbody2D rbody in rigidbodies)
//		{
//			Vector2 force = GetGravityStrength(rbody.position);
//
//			rbody.AddForce(force, ForceMode2D.Force);
//		}
//	}
//
//	public Vector2 GetGravityStrength (Vector2 targetPosition)
//	{
//		Vector2 forceVector = transform.position - targetPosition;
//		Vector2 direction = forceVector.normalized;
//		float distance = forceVector.magnitude;
//		
//		return direction * forceMagnitude * (distance * distanceScale);
//	}
//
//	
//
//	void OnTriggerEnter2D(Collider2D collider)
//	{
//		Rigidbody2D rbody = collider.gameObject.GetComponent<Rigidbody2D>();
//
//		if (rbody !=null)
//			rigidbodies.Add(rbody);
//	}
//
//	void OnTriggerExit2D(Collider2D collider)
//	{
//		Rigidbody2D rbody = collider.gameObject.GetComponent<Rigidbody2D>();
//		
//		if (rbody !=null)
//			rigidbodies.Remove(rbody);
//	}
//	
//}
