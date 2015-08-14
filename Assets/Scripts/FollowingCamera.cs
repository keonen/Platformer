//using UnityEngine;
//using System.Collections;
//
//public class FollowingCamera : MonoBehaviour {
//
//	public Transform target;
//
//	// Update is called once per frame
//	void LateUpdate () 
//	{
//
//		transform.position = new Vector2(
//								target.position.x,
//								target.position.y,
//								transform.position.z);
//
//		transform.rotation = Quaternion.Lerp (transform.rotation, target.rotation, 0.01f);
//
//		//transform.eulerAngles = Vector3.Lerp (transform.eulerAngles, target.eulerAngles, 0.01f);
//
//	}
//}