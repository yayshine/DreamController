// Developed by Sophia Liu and Yay Shin
// 2014, Nov. 10 @ HackSC
// github.com/lentebloem/DreamController
// 
// Keyboard control to make objects and erase them

using UnityEngine;
using System.Collections;
using AOT;

public class treasure : MonoBehaviour {
	
	public KeyCode CommandKey = KeyCode.RightCommand;
	private int Commanding = 0;
	private bool SecondKeyOn = false;
	public string textInput = "";

	void CheckCommandFirst(){
		// check if 'command' is clicked
		if(Input.GetKeyDown(CommandKey) && Commanding == 0 && SecondKeyOn == false){
			Debug.LogWarning("First Command");
			Commanding = 1;
			textInput = textInput.Insert(textInput.Length, Input.inputString);
		}else if(Input.GetKeyUp(CommandKey) && (Commanding == 1 || Commanding == 2) && SecondKeyOn == false){
			Debug.LogWarning("First Button's off");
			Commanding = 2;
			SecondKeyOn = true;
			textInput = textInput.Insert(textInput.Length, Input.inputString);
			CheckCommandSecond();
		}else if(Commanding == 1 || Commanding == 2){
			Debug.LogWarning("Checking First Command: "+Commanding+", "+SecondKeyOn);
			textInput = textInput.Insert(textInput.Length, Input.inputString);
			CheckCommandSecond();
		}
	}
	
	void CheckCommandSecond(){
		// check if 'command' is clicked again
		if(Input.GetKeyDown(CommandKey) && Commanding == 2 && SecondKeyOn == true){
			textInput = textInput.Insert(textInput.Length, Input.inputString);
			Debug.LogWarning("Second Command");
			Commanding = 3;
			Debug.LogWarning(textInput);
			Commanding = 0;
			SecondKeyOn = false;
			textInput = "";
		}else{
			Debug.LogWarning("Checking Second Command: "+Commanding+", "+SecondKeyOn);
			textInput = textInput.Insert(textInput.Length, Input.inputString);
		}
	}
	

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//get the object's tag name
		CheckCommandFirst();
		
		var obj_name = "";
		
		if (Input.GetKeyDown(KeyCode.G)) {
			obj_name = "Ball";
		}
		
		if (Input.GetKeyDown(KeyCode.R)) {
			obj_name = "R";
			Debug.LogWarning("Rain");
		}		
		
		if (Input.GetKeyDown(KeyCode.S)) {
			obj_name = "S";
		}	
		
		if (Input.GetKeyDown(KeyCode.T)) {
			obj_name = "T";
		}

		if (Input.GetKeyDown(KeyCode.F)) {
			obj_name = "F";
		}	
		
		if (Input.GetKeyDown(KeyCode.E)) {
			obj_name = "E";
		}	
		
		if (textInput == "Hello" || textInput == "hello") {
			obj_name = "Ball";
		}
		
		var children = this.GetComponentsInChildren<MeshRenderer>();
		var order = 0;
		while (children.Length > order) {
			MeshRenderer current = children[order];
			if (current.name == obj_name) {
				current.enabled = !current.enabled;
				break;
			}
			if (obj_name == "R" || obj_name == "S" || obj_name =="T" ){
				current.particleSystem.renderer.enabled = !current.particleSystem.renderer.enabled;
				current.particleEmitter.renderer.enabled = !current.particleEmitter.renderer.enabled;
				
			}
			order += 1;
		}
	}
}