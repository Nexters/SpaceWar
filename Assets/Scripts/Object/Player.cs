using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject MissleObj;
	public GameObject jetObj;
	public float FireTime = 0.3f;
	public float accFireTime = 0.0f;

	private bool isFire = true;
	public bool IsFire{
		get{
			return isFire;
		}
		set{
			isFire = value;
		}
	}

	void Start () {
		SubscribeEvent();
		jetObj = GameObject.Find("EnginePlayer");
	}

	void Update () {
		accFireTime+=Time.deltaTime;
		if(accFireTime >= FireTime && isFire){
			GameObject m = Instantiate (MissleObj, transform.position + transform.forward.normalized, transform.rotation) as GameObject;
			m.rigidbody.AddForce(transform.forward*1000);
			accFireTime = 0.0f;
			Destroy(m,2);
		}
	}

	void FixedUpdate ()
	{
	
	}
	void OnDisable(){
		UnsubscribeEvent();
	}
	
	void OnDestroy(){
		UnsubscribeEvent();
	}
	
	void SubscribeEvent(){
		InputManager.DragStartHandler += On_DragStart;
		InputManager.DragHandler += On_Drag;
		InputManager.DragEndHadler += On_DragEnd;

		InputManager.JoystickMoveStartHandler += On_JoystickStart;
		InputManager.JoystickMoveHandler += On_JoystickMove;
		InputManager.JoystickMoveEndHandler += On_JoystickMoveEnd;

		InputManager.TiltMoveHandler += On_TiltMove;
	}
	void UnsubscribeEvent(){
		InputManager.DragStartHandler -= On_DragStart;
		InputManager.DragHandler -= On_Drag;
		InputManager.DragEndHadler -= On_DragEnd;

		InputManager.JoystickMoveStartHandler -= On_JoystickStart;
		InputManager.JoystickMoveHandler -= On_JoystickMove;
		InputManager.JoystickMoveEndHandler -= On_JoystickMoveEnd;

		InputManager.TiltMoveHandler -= On_TiltMove;
	}

	void On_DragStart(Gesture gesture){

	}

	void On_Drag(Gesture gesture){ 
		Vector3 lookVec = gesture.GetTouchToWordlPoint(transform.position.z,true);
		lookVec = new Vector3(lookVec.x,transform.position.y,lookVec.z);
		transform.LookAt(lookVec);
		jetObj.transform.LookAt(lookVec);

		Vector3 velVec = new Vector3(lookVec.x-transform.position.x,0,lookVec.z-transform.position.z);
		rigidbody.velocity = velVec;

		transform.RotateAround(transform.position,transform.forward,rigidbody.velocity.x*10);
	}

	void On_DragEnd(Gesture gesture){

	}

	void On_JoystickStart(MovingJoystick move){

	}
	
	void On_JoystickMove(MovingJoystick move){

		Vector3 newPos = new Vector3(move.joystickAxis.x/10.0f,0,move.joystickAxis.y/10.0f);
		this.transform.position += newPos;
		Vector3 lookVec = new Vector3(transform.position.x + move.joystickAxis.normalized.x*100,transform.position.y,transform.position.z+move.joystickAxis.normalized.y*100);
		transform.LookAt(lookVec);

		transform.RotateAround(transform.position,transform.forward,move.joystickAxis.x*30);
		/*
		float arct = Mathf.Atan(move.joystickAxis.normalized.y/move.joystickAxis.normalized.x);
		Debug.Log ("arct : " + arct*Mathf.Rad2Deg);
		Debug.Log("arct : " + Quaternion.AngleAxis(arct*Mathf.Rad2Deg, Vector3.up));
		transform.rotation = Quaternion.AngleAxis(arct*Mathf.Rad2Deg, Vector3.up);
		*/
	}
	void On_JoystickMoveEnd(MovingJoystick move){

	}

	void On_TiltMove(Vector3 vec){
		Vector3 newPos = new Vector3(vec.x/3.0f,0,vec.y/3.0f);
		this.transform.position += newPos;

		Vector3 lookVec = new Vector3(transform.position.x + vec.x*100,transform.position.y,transform.position.z+vec.y*100);
		transform.LookAt(lookVec);

	}
}
