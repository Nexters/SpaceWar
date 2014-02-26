using UnityEngine;
using System.Collections;

public class PlayerBoundary : MonoBehaviour {

	// Use this for initialization
	GameObject player;

	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(player.transform.position.x,0,player.transform.position.z);
	}
}
