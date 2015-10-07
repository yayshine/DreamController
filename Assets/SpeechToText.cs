// Developed by Sophia Liu and Yay Shin
// 2014, Nov. 10 @ HackSC
// github.com/lentebloem/DreamController
// 
// Under Progress: Implementing Apple's Dictation for Voice Control

using UnityEngine;
using System.Collections;

public class SpeechToText : MonoBehaviour{
	
	public KeyCode CommandKey = KeyCode.RightCommand;
	private int Commanding = 0;
	private bool SecondKeyOn = false;
	public string textInput = "";
	
	void Update(){
		CheckCommandFirst();
	}
	
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
}