using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public delegate void DragStart(Gesture gesture);
	public delegate void Drag(Gesture gesture);
	public delegate void DragEnd(Gesture gesture);
	public delegate void JoystickMoveStart(MovingJoystick gesture);
	public delegate void JoystickMove(MovingJoystick gesture);
	public delegate void JoystickMoveEnd(MovingJoystick gesture);
	public delegate void TiltMove(Vector3 vec);

	public static event DragStart DragStartHandler;
	public static event Drag DragHandler;
	public static event DragEnd DragEndHadler;
	public static event JoystickMoveStart JoystickMoveStartHandler;
	public static event JoystickMove JoystickMoveHandler;
	public static event JoystickMoveEnd JoystickMoveEndHandler;
	public static event TiltMove TiltMoveHandler;

	public enum InputType{
		JOYSTICK,
		TOUCH,
		TILT
	}
	private InputType inputType = InputType.JOYSTICK;
	EasyJoystick joyStick;
	void OnEnable () {
		SubscribeEvent();
	}
	void Start() {
		joyStick = GameObject.Find("JoyStick").GetComponent<EasyJoystick>();
	}
	
	void Update () {
		if(inputType == InputType.TILT){
			TiltMoveHandler(Input.acceleration);
		}
	}
	public void TouchModeChange(InputType type){
		inputType = type;
		switch(inputType){
		case InputType.JOYSTICK:
			joyStick.enabled = true;
			break;
		case InputType.TOUCH:
			joyStick.enabled = false;
			break;
		case InputType.TILT:
			joyStick.enabled = false;
			break;
		}
	}

	void OnDisable(){
		UnsubscribeEvent();
	}
	
	void OnDestroy(){
		UnsubscribeEvent();
	}

	void SubscribeEvent(){
		EasyTouch.On_Drag += On_Drag;
		EasyTouch.On_DragStart += On_DragStart;
		EasyTouch.On_DragEnd += On_DragEnd;

		EasyJoystick.On_JoystickMoveStart += On_JoystickStart;
		EasyJoystick.On_JoystickMove += On_JoystickMove;
		EasyJoystick.On_JoystickMoveEnd += On_JoystickMoveEnd;
	}
	void UnsubscribeEvent(){
		EasyTouch.On_Drag -= On_Drag;
		EasyTouch.On_DragStart -= On_DragStart;
		EasyTouch.On_DragEnd -= On_DragEnd;

		EasyJoystick.On_JoystickMoveStart -= On_JoystickStart;
		EasyJoystick.On_JoystickMove -= On_JoystickMove;
		EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
	}

	void On_DragStart(Gesture gesture){
		if(inputType == InputType.TOUCH){
			DragStartHandler(gesture);
		}
	}

	void On_Drag(Gesture gesture){
		if(inputType == InputType.TOUCH){
			float dragAngle = gesture.GetSwipeOrDragAngle();
			DragHandler(gesture);
		}
	}
	
	void On_DragEnd(Gesture gesture){
		if(inputType == InputType.TOUCH){
			DragEndHadler(gesture);
		}
	}

	void On_JoystickStart(MovingJoystick move){
		if(inputType == InputType.JOYSTICK){
			JoystickMoveStartHandler(move);
		}
	}
	
	void On_JoystickMove(MovingJoystick move){
		if(inputType == InputType.JOYSTICK){
			JoystickMoveHandler(move);
		}
	}

	void On_JoystickMoveEnd(MovingJoystick move){
		if(inputType == InputType.JOYSTICK){
			JoystickMoveEndHandler(move);
		}
	}
}
