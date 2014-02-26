using UnityEngine;
using System.Collections;

public class AirRotate : PlayerEffect {

	// Use this for initialization
	Transform rotateTrans;
	float rotateAngle; 
	float rotateSpeed;
	protected override void _Start () {
		rotateTrans = this.transform.Find("AirRotate");
		rotateSpeed = 100.0f;
		rotateAngle = 0.0f;
		player.IsFire = false;
	}
	
	// Update is called once per frame
	protected override void _Update () {
		rotateAngle += rotateSpeed*Time.deltaTime;

		transform.RotateAround(rotateTrans.transform.position,rotateTrans.forward,rotateSpeed*Time.deltaTime);
		if(rotateAngle >= 360){
			//transform.rotation = new Quaternion(270,0,0,0);
			Destroy(this);
			player.IsFire = true;
		}
	}
}
