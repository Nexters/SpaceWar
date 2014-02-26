using UnityEngine;
using System.Collections;

[System.Serializable]
public class CameraBoundary 
{
	public float xMin, xMax, zMin, zMax;
}
public class FollowCamera : MonoBehaviour {

	public CameraBoundary boundary;
	Transform playerTrans;
	void Start () {
		playerTrans = GameObject.Find("Player").transform;
	}
	
	void Update () {
		//playerTrans.position;
		transform.position = new Vector3(
			Mathf.Clamp (playerTrans.position.x,boundary.xMin, boundary.xMax), 
			transform.position.y, 
			Mathf.Clamp (playerTrans.position.z, boundary.zMin, boundary.zMax)
			);
	}
}
