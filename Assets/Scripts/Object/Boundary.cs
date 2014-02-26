using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.tag == "Missile"){
			Destroy(other.gameObject);
		}
		if(other.gameObject.tag == "Obstacle"){
			Destroy(other.gameObject);
		}
	}
	
	void OnCollisionEnter(Collision collision)
	{
	}
}
