using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using FYP.ExtremeRacingRush;

public class RTS_BrakeLight : MonoBehaviour{
	public Color _colorReverse;
	public Color _colorBrakeOn;
	public Color _colorBrakeOff;
	private CarController carControllerRef;

	public bool localPlayer;
	public GameObject meshRendObject;
	public Material brakeMaterial;
	
	public bool opponentCar;

	private string gameMode;
	public int materialIndex = 8;

	private void Start(){
		carControllerRef = transform.root.GetComponent<CarController>();
		gameMode = RTS_PlayerPrefs.GetGameMode ();
		if (gameMode == "MULTIPLAYER") {
			//localPlayer = GetComponent<NetworkIdentity> ().isLocalPlayer;
		} else {
			localPlayer = true;
		}
		if (opponentCar) {
			brakeMaterial = GetComponent<MeshRenderer> ().materials [materialIndex];
		} else {
			brakeMaterial = meshRendObject.GetComponent<MeshRenderer> ().materials [materialIndex];
		}
		brakeMaterial.EnableKeyword ("_EMISSION");
	}

	private void Update(){		
		if (localPlayer) {	
			if (carControllerRef.BrakeInput > 0f) {
				if (carControllerRef.reversing) {
					brakeMaterial.SetColor ("_EmissionColor", _colorReverse);
				} else {
					brakeMaterial.SetColor ("_EmissionColor", _colorBrakeOn);
				}
			} else {
				Invoke("TurnOff_Lights", 0.5f);
			}
        }
       
    }

        void TurnOff_Lights(){
		brakeMaterial.SetColor ("_EmissionColor", _colorBrakeOff);
	}

}