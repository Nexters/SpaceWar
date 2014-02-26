using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	// Use this for initialization
	public GameObject destroyObj;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.tag == "Missile"){
			GameObject m = Instantiate (destroyObj, transform.position, transform.rotation) as GameObject;
			Destroy(m,2);
			Destroy(this.gameObject);
		}
	}
	
	void OnCollisionEnter(Collision collision)
	{
	}
}
