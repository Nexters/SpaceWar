using UnityEngine;
using System.Collections;

public class JoystickManager : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
		SubscribeEvent();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDisable(){
		UnsubscribeEvent();
	}
	
	void OnDestroy(){
		UnsubscribeEvent();
	}
	
	void SubscribeEvent(){
		EasyJoystick.On_JoystickMoveStart += On_JoystickStart;
		EasyJoystick.On_JoystickMove += On_JoystickMove;
		EasyJoystick.On_JoystickMoveEnd += On_JoystickMoveEnd;

	}
	void UnsubscribeEvent(){
		EasyJoystick.On_JoystickMoveStart -= On_JoystickStart;
		EasyJoystick.On_JoystickMove -= On_JoystickMove;
		EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
	}
	void On_JoystickStart(MovingJoystick move){
		Debug.Log("On_JoystickStart : " + move.joystickAxis.x);
	}
	
	void On_JoystickMove(MovingJoystick move){
		Debug.Log("On_JoystickMove : " + move.joystickAxis.x);
		Debug.Log("On_JoystickMove : " + move.joystickAxis.y);
	}
	void On_JoystickMoveEnd(MovingJoystick move){
	}
}
