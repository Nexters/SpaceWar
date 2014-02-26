using UnityEngine;
using System.Collections;

public class FirstCameraRotate : MonoBehaviour {

	// Use this for initialization
	float accTime = 0.0f; 
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		accTime += Time.deltaTime/5.0f;
		float size = Mathf.Lerp(1,10,accTime);
		camera.orthographicSize = size;	
	}
}
