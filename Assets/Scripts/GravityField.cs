//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//
//public class GravityField : MonoBehaviour {
//
//	enum FieldType {point, area};
//	FieldType fieldType = FieldType.point;
//
//	public float forceMagnitude = 1f;
//	public Vector2 forceDirection = Vector2.zero;
//	public float distanceScale = 1f;
//
//	public List<Rigidbody2D> rigidbodies = new List<Rigidbody2D>();
//
//	public Vector2 GetGravityStrength (Vector2 targetPosition)
//	{
//		switch(fieldType)
//		{
//			case FieldType.point:
//				Vector2 forceVector = (Vector2)transform.position - targetPosition;
//				Vector2 direction = forceVector.normalized;
//				float distance = forceVector.magnitude;
//
//				return direction * forceMagnitude * (distance * distanceScale);
//			break;
//
//			case FieldType.Direction:
//
//				return formDirection * forceMagnitude;
//			break;
//
//			// transform.rotation += Quaternion.AngleAxis (angle, transform.forward);
//		}
//
//		return Vector2.zero;
//	}
//
//		void OnTriggerEnter2D(Collider2D collider)
//		{
//			Rigidbody2D rbody = collider.gameObject.GetComponent<Rigidbody2D>();
//	
//			if (rbody !=null)
//				rigidbodies.Add(rbody);
//		}
//	
//		void OnTriggerExit2D(Collider2D collider)
//		{
//			Rigidbody2D rbody = collider.gameObject.GetComponent<Rigidbody2D>();
//			
//			if (rbody !=null)
//				rigidbodies.Remove(rbody);
//
//		}
//	}
