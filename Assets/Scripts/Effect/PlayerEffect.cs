using UnityEngine;
using System.Collections;

public class PlayerEffect : MonoBehaviour {

	protected GameObject playerObj;
	protected Player player;
	protected virtual void _Start(){}
	protected virtual void _Update(){}
	void Start () {
		playerObj = GameObject.Find("Player");
		player = playerObj.GetComponent<Player>();
		_Start();
	}
	
	void Update () {
		_Update();
	}
}
