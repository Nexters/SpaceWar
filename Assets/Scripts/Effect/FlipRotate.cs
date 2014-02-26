using UnityEngine;
using System.Collections;

public class FlipRotate : MonoBehaviour {

	Transform rotateTrans;
	float rotateAngle; 
	float rotateSpeed;
	void Start () {
		rotateTrans = this.transform.Find("FlipRotate");
		rotateSpeed = 200.0f;
		rotateAngle = 0.0f;
	}
	
	void Update () {
		rotateAngle += rotateSpeed*Time.deltaTime;
		
		transform.RotateAround(rotateTrans.transform.position,rotateTrans.forward,rotateSpeed*Time.deltaTime);
		if(rotateAngle >= 360){
			//transform.rotation = new Quaternion(270,0,0,0);
			Destroy(this);
		}
	}
}
