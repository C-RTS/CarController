using System;
using UnityEngine;
using FYP.ExtremeRacingRush;

[ExecuteInEditMode]
public class RTS_MobileController : MonoBehaviour{

	public GameObject turnLeftButton;
	public GameObject turnRightButton;




	void OnEnable (){
		Enable__ControlRig__ForMob (RTS_PlayerPrefs.inputData.useMobileController);
	}

	void Enable__ControlRig__ForMob (bool enabled){
		foreach (Transform t in transform){
			t.gameObject.SetActive(enabled);
		}

	
		turnLeftButton.SetActive (false);
		turnRightButton.SetActive (false);
		

		int mobileType = RTS_PlayerPrefs.GetMobileSteeringType ();
		switch (mobileType) {
		case 0:									//Arrow Button Steering
			turnLeftButton.SetActive (true);
			turnRightButton.SetActive (true);
			break;
		
		}

		

	}

}