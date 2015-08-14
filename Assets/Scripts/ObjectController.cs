//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//
//public class ObjectController : MonoBehaviour {
//
//	public bool camClimb;
//
//	public List<GravityField> gravityFields = new List<GravityField>();
//
//	public Vector2 gravityForce;
//	// Use this for initialization
//	void Start () 
//	{
//	
//	}
//	
//	// Update is called once per frame
//	protected virtual void Update () 
//	{
//		gravityForce = Vector2.zero;
//
//		foreach(GravityField gravityField in gravityFields)
//		{
//			gravityForce += gravityField.GetGravityStrength(transform.position);
//		}
//	}
//}
