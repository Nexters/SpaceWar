using UnityEngine;
using System.Collections;

public class DestroyDistance : MonoBehaviour {

	// Use this for initialization
	Transform playerTrans;
	public float DistroyDistance = 20.0f;
	void Start () {
		playerTrans = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		float dis = Vector3.Distance(transform.position,playerTrans.position);
		if(dis > DistroyDistance){
			Destroy(gameObject);
		}
	}
}
