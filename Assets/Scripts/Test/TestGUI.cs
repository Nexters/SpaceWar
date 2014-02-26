using UnityEngine;
using System.Collections;

public class TestGUI : MonoBehaviour {

	// Use this for initialization
	private bool inputSelected;
	void Start () {
		inputSelected = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		if(GUI.Button(new Rect(10, 10, 50, 50), "1")){
			GameObject.Find("Player").AddComponent<AirRotate>();
		}
		if(GUI.Button(new Rect(70, 10, 50, 50), "2")){
			GameObject.Find("Player").AddComponent<FlipRotate>();
		}
		if(GUI.Button(new Rect(130, 10, 50, 50), "3")){
			Transform tran = GameObject.Find("Player").transform;
			Instantiate (Resources.Load("Particles/ExplosionPlayer"), new Vector3(tran.position.x,3,tran.position.z), Quaternion.identity);
		}
		if(GUI.Button(new Rect(190, 10, 50, 50), "4")){
			inputSelected = !inputSelected;
		}

		if(inputSelected){
			if(GUI.Button(new Rect(10, Screen.height-70, 50, 50), "1")){
				GameObject.Find("EasyTouch").GetComponent<InputManager>().TouchModeChange(InputManager.InputType.JOYSTICK);
			}
			if(GUI.Button(new Rect(70, Screen.height-70, 50, 50), "2")){
				GameObject.Find("EasyTouch").GetComponent<InputManager>().TouchModeChange(InputManager.InputType.TOUCH);
			}
			if(GUI.Button(new Rect(130, Screen.height-70, 50, 50), "3")){
				GameObject.Find("EasyTouch").GetComponent<InputManager>().TouchModeChange(InputManager.InputType.TILT);
			}
		}
		GUI.Label(new Rect(10, 70, Screen.width - 10*2, 200), "TestButton");
	}
}
