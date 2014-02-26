using UnityEngine;
using System.Collections;

public class ObstacleLauncher : MonoBehaviour {

	// Use this for initialization
	float fireTime = 2.0f;
	float accFireTime = 0.0f;
	public GameObject obstacleObj;
	Transform playerTrans;
	void Start () {
		playerTrans = GameObject.Find("Player").transform;
		fireTime = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		accFireTime += Time.deltaTime;
		if(accFireTime >= fireTime){
			GameObject m = Instantiate (obstacleObj, transform.position + transform.forward*2, transform.rotation) as GameObject;
			m.transform.LookAt(playerTrans.position);
			m.rigidbody.AddForce(m.transform.forward*100);
			m.rigidbody.angularVelocity = Random.insideUnitSphere * 10;
			accFireTime = 0.0f;;
		}
		float t = Mathf.PingPong(Time.time*10,30.0f)-15.0f;
		this.transform.position = new Vector3(transform.position.x,transform.position.y,t);
	}
}
