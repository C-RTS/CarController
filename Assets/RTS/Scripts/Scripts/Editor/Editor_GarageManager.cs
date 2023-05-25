using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;
using FYP.ExtremeRacingRush;

[CustomEditor(typeof(RTS_GarageManager))]
public class Editor_GarageManager : Editor {

	bool showRaceImages;
	bool showNeonParticles;
	bool showCarModels;

	public override void OnInspectorGUI(){
		RTS_GarageManager RTS_gameManager = (RTS_GarageManager)target;
		if (RTS_gameManager.sceneCarModel.Length != RTS_PlayerPrefs.playableVehicles.numberOfCars) {
			System.Array.Resize (ref RTS_gameManager.sceneCarModel, RTS_PlayerPrefs.playableVehicles.numberOfCars);
		}
		
		RTS_gameManager.raceImage = (Image) EditorGUILayout.ObjectField ("Race Image", RTS_gameManager.raceImage, typeof(Image), true);
		showNeonParticles = EditorGUILayout.Foldout (showNeonParticles, "Neon Particle Systems");
		
		showCarModels = EditorGUILayout.Foldout (showCarModels, "Car Models");
		if (showCarModels) {
			for (int i = 0; i < RTS_gameManager.sceneCarModel.Length; i++) {
				RTS_gameManager.sceneCarModel [i] = (GameObject) EditorGUILayout.ObjectField ("Car " + i, RTS_gameManager.sceneCarModel [i], typeof(GameObject), true);
			}
		}

		SerializedProperty uI = serializedObject.FindProperty ("uI");
		EditorGUI.BeginChangeCheck ();
		EditorGUILayout.PropertyField (uI, true);
		if (EditorGUI.EndChangeCheck ())
			serializedObject.ApplyModifiedProperties ();

	}

}