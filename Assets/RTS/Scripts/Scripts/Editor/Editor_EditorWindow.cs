﻿using UnityEngine;
using UnityEditor;
using FYP.ExtremeRacingRush;


public class Editor_EditorWindow : EditorWindow {
	public enum Switch { Off, On }

	bool audioSettings;
	bool inputSettings;
	bool raceSettings;
	bool opponentVehicleSettings;
	bool playableVehicleSettings;
	bool playerPrefsSettings;
	bool debugSettings;
	bool showOpponentNames;
	bool showOpponentPrefabs;
	Vector2 scrollPosition = Vector2.zero;
	public AudioClip soundClip;
	Switch configureRaceSize;
	Switch configureCarSize;
	int raceView;
	int carView;
	int opponentCarView;
	int numberOfRaces;
	int numberOfCars;

	bool showAccelerationLevelBonus;
	bool showTopSpeedLevelBonus;
	bool showTireTractionLevelBonus;
	bool showSteerSensitivityLevelBonus;
	bool showBrakePowerLevelBonus;

	GUISkin defaultSkin;

	[MenuItem ("Window/Fyp Project/RGT Settings")]
	static void Init () {
		Editor_EditorWindow window = (Editor_EditorWindow)EditorWindow.GetWindow (typeof (Editor_EditorWindow));
		Texture icon = Resources.Load("RGTIcon") as Texture;
		GUIContent titleContent = new GUIContent ("RGT Settings", icon);
		window.titleContent = titleContent;
		window.minSize = new Vector2(300f,500f);
		window.Show();
	}

	void DisableAllTabs(){
		audioSettings = false;
		inputSettings = false;
		raceSettings = false;
		opponentVehicleSettings = false;
		playableVehicleSettings = false;
		playerPrefsSettings = false;
		debugSettings = false;
	}

	void OnGUI () {
		if(defaultSkin == null)
			defaultSkin = GUI.skin;
		GUISkin editorSkin = Resources.Load("EditorSkin") as GUISkin;
		GUI.skin = editorSkin;
		EditorGUILayout.BeginVertical("Box");
		EditorGUILayout.LabelField ("Fyp Project", editorSkin.customStyles [1]);
		EditorGUILayout.LabelField ("Project Editor", editorSkin.customStyles [1]);
		EditorGUILayout.LabelField (RTS_PlayerPrefs.debugData.projectVersion, editorSkin.customStyles [2]);
		EditorGUILayout.BeginHorizontal();
		editorSkin.button.active.textColor = Color.yellow;
		if (audioSettings) {
			editorSkin.button.normal.textColor = Color.yellow;
			editorSkin.button.hover.textColor = Color.yellow;
		}
		else {
			editorSkin.button.normal.textColor = Color.white;
			editorSkin.button.hover.textColor = Color.white;
		}
		if (GUILayout.Button ("Audio", GUILayout.MaxWidth(Screen.width * 0.33f), GUILayout.MaxHeight(35) )) {
			GUIUtility.hotControl = 0;
			GUIUtility.keyboardControl = 0;
			DisableAllTabs ();
			audioSettings = true;
		}
		if (inputSettings) {
			editorSkin.button.normal.textColor = Color.yellow;
			editorSkin.button.hover.textColor = Color.yellow;
		}
		else {
			editorSkin.button.normal.textColor = Color.white;
			editorSkin.button.hover.textColor = Color.white;
		}
		if (GUILayout.Button ("Input", GUILayout.MaxWidth(Screen.width * 0.33f), GUILayout.MaxHeight(35) )) {
			GUIUtility.hotControl = 0;
			GUIUtility.keyboardControl = 0;
			DisableAllTabs ();
			inputSettings = true;
		}
		if (raceSettings) {
			editorSkin.button.normal.textColor = Color.yellow;
			editorSkin.button.hover.textColor = Color.yellow;
		}
		else {
			editorSkin.button.normal.textColor = Color.white;
			editorSkin.button.hover.textColor = Color.white;
		}
		if (GUILayout.Button ("Races", GUILayout.MaxWidth(Screen.width * 0.33f), GUILayout.MaxHeight(35) )) {
			GUIUtility.hotControl = 0;
			GUIUtility.keyboardControl = 0;
			DisableAllTabs ();
			raceSettings = true;
		}
		EditorGUILayout.EndHorizontal ();


		EditorGUILayout.BeginHorizontal ();
		if (playableVehicleSettings) {
			editorSkin.button.normal.textColor = Color.yellow;
			editorSkin.button.hover.textColor = Color.yellow;
		}
		else {
			editorSkin.button.normal.textColor = Color.white;
			editorSkin.button.hover.textColor = Color.white;
		}
		if (GUILayout.Button ("Player Cars", GUILayout.MaxWidth(Screen.width * 0.5f), GUILayout.MaxHeight(40) )) {
			GUIUtility.hotControl = 0;
			GUIUtility.keyboardControl = 0;
			DisableAllTabs ();
			playableVehicleSettings = true;
		}

		if (opponentVehicleSettings) {
			editorSkin.button.normal.textColor = Color.yellow;
			editorSkin.button.hover.textColor = Color.yellow;
		}
		else {
			editorSkin.button.normal.textColor = Color.white;
			editorSkin.button.hover.textColor = Color.white;
		}
		if (GUILayout.Button ("AI Cars", GUILayout.MaxWidth(Screen.width * 0.5f), GUILayout.MaxHeight(40) )) {
			GUIUtility.hotControl = 0;
			GUIUtility.keyboardControl = 0;
			DisableAllTabs ();
			opponentVehicleSettings = true;
		}
		EditorGUILayout.EndHorizontal ();



		EditorGUILayout.BeginHorizontal ();
		if (playerPrefsSettings) {
			editorSkin.button.normal.textColor = Color.yellow;
			editorSkin.button.hover.textColor = Color.yellow;
		}
		else {
			editorSkin.button.normal.textColor = Color.white;
			editorSkin.button.hover.textColor = Color.white;
		}
		if (GUILayout.Button ("PlayerPrefs", GUILayout.MaxWidth(Screen.width * 0.5f), GUILayout.MaxHeight(35) )) {
			GUIUtility.hotControl = 0;
			GUIUtility.keyboardControl = 0;
			DisableAllTabs ();
			playerPrefsSettings = true;
		}

		if (debugSettings) {
			editorSkin.button.normal.textColor = Color.yellow;
			editorSkin.button.hover.textColor = Color.yellow;
		}
		else {
			editorSkin.button.normal.textColor = Color.white;
			editorSkin.button.hover.textColor = Color.white;
		}
		if (GUILayout.Button ("Debug Settings", GUILayout.MaxWidth(Screen.width * 0.5f), GUILayout.MaxHeight(35) )) {
			GUIUtility.hotControl = 0;
			GUIUtility.keyboardControl = 0;
			DisableAllTabs ();
			debugSettings = true;
		}
		EditorGUILayout.EndHorizontal ();


		editorSkin.button.normal.textColor = Color.white;
		editorSkin.button.hover.textColor = Color.white;


		editorSkin.button.normal.textColor = Color.grey;


		EditorGUILayout.LabelField ("Unity Project Settings:");

		EditorGUILayout.BeginHorizontal ();
		if (GUILayout.Button ("Build Settings", GUILayout.MaxWidth (Screen.width * 0.5f), GUILayout.MaxHeight (20))) {
			GUIUtility.hotControl = 0;
			GUIUtility.keyboardControl = 0;
			EditorWindow.GetWindow (System.Type.GetType("UnityEditor.BuildPlayerWindow,UnityEditor"));
		}
		if (GUILayout.Button ("Services", GUILayout.MaxWidth (Screen.width * 0.5f), GUILayout.MaxHeight (20))) {
			GUIUtility.hotControl = 0;
			GUIUtility.keyboardControl = 0;
			EditorApplication.ExecuteMenuItem ("Window/Services");
		}
		if (GUILayout.Button ("Lighting", GUILayout.MaxWidth (Screen.width * 0.5f), GUILayout.MaxHeight (20))) {
			GUIUtility.hotControl = 0;
			GUIUtility.keyboardControl = 0;
			EditorApplication.ExecuteMenuItem ("Window/Lighting");
		}
		EditorGUILayout.EndHorizontal ();

		EditorGUILayout.BeginHorizontal ();
		if (GUILayout.Button ("Physics", GUILayout.MaxWidth (Screen.width * 0.2f), GUILayout.MaxHeight (20))) {
			GUIUtility.hotControl = 0;
			GUIUtility.keyboardControl = 0;
			EditorApplication.ExecuteMenuItem ("Edit/Project Settings/Physics");
		}
		if (GUILayout.Button ("Quality", GUILayout.MaxWidth (Screen.width * 0.2f), GUILayout.MaxHeight (20))) {
			GUIUtility.hotControl = 0;
			GUIUtility.keyboardControl = 0;
			EditorApplication.ExecuteMenuItem ("Edit/Project Settings/Quality");
		}
		if (GUILayout.Button ("Graphics", GUILayout.MaxWidth (Screen.width * 0.2f), GUILayout.MaxHeight (20))) {
			GUIUtility.hotControl = 0;
			GUIUtility.keyboardControl = 0;
			EditorApplication.ExecuteMenuItem ("Edit/Project Settings/Graphics");
		}
		if (GUILayout.Button ("Tags and Layers", GUILayout.MaxWidth (Screen.width * 0.35f), GUILayout.MaxHeight (20))) {
			GUIUtility.hotControl = 0;
			GUIUtility.keyboardControl = 0;
			EditorApplication.ExecuteMenuItem ("Edit/Project Settings/Tags and Layers");
		}
		EditorGUILayout.EndHorizontal ();

		EditorGUILayout.BeginHorizontal ();
		if (GUILayout.Button ("Editor", GUILayout.MaxWidth (Screen.width * 0.5f), GUILayout.MaxHeight (20))) {
			GUIUtility.hotControl = 0;
			GUIUtility.keyboardControl = 0;
			EditorApplication.ExecuteMenuItem ("Edit/Project Settings/Editor");
		}
		if (GUILayout.Button ("Player", GUILayout.MaxWidth (Screen.width * 0.5f), GUILayout.MaxHeight (20))) {
			GUIUtility.hotControl = 0;
			GUIUtility.keyboardControl = 0;
			EditorApplication.ExecuteMenuItem ("Edit/Project Settings/Player");
		}
		if (GUILayout.Button ("Script Execution Order", GUILayout.MaxWidth (Screen.width * 0.5f), GUILayout.MaxHeight (20))) {
			GUIUtility.hotControl = 0;
			GUIUtility.keyboardControl = 0;
			EditorApplication.ExecuteMenuItem ("Edit/Project Settings/Script Execution Order");
		}
		EditorGUILayout.EndHorizontal ();
		EditorGUILayout.BeginHorizontal ();


		if (GUILayout.Button ("Audio", GUILayout.MaxWidth (Screen.width * 0.5f), GUILayout.MaxHeight (20))) {
			GUIUtility.hotControl = 0;
			GUIUtility.keyboardControl = 0;
			EditorApplication.ExecuteMenuItem ("Edit/Project Settings/Audio");
		}
		if (GUILayout.Button ("Time", GUILayout.MaxWidth (Screen.width * 0.5f), GUILayout.MaxHeight (20))) {
			GUIUtility.hotControl = 0;
			GUIUtility.keyboardControl = 0;
			EditorApplication.ExecuteMenuItem ("Edit/Project Settings/Time");
		}
		if (GUILayout.Button ("Network", GUILayout.MaxWidth (Screen.width * 0.5f), GUILayout.MaxHeight (20))) {
			GUIUtility.hotControl = 0;
			GUIUtility.keyboardControl = 0;
			EditorApplication.ExecuteMenuItem ("Edit/Project Settings/Network");
		}
		EditorGUILayout.EndHorizontal ();
		editorSkin.button.normal.textColor = Color.white;
		EditorGUILayout.EndVertical();
		scrollPosition = EditorGUILayout.BeginScrollView (scrollPosition, false, false);
/// Audio Settings
		if(audioSettings){
			EditorGUILayout.BeginVertical("Box");
			EditorGUILayout.LabelField ("Audio Settings", editorSkin.customStyles [0]);
			EditorGUILayout.EndVertical();
			RTS_PlayerPrefs.audioData.musicSelection = (AudioData.MusicSelection) EditorGUILayout.EnumPopup ("Music Selection", RTS_PlayerPrefs.audioData.musicSelection);
			RTS_PlayerPrefs.audioData.numberOfTracks = EditorGUILayout.IntSlider ("Number of Tracks", RTS_PlayerPrefs.audioData.numberOfTracks, 0, 50);
			if(RTS_PlayerPrefs.audioData.numberOfTracks != RTS_PlayerPrefs.audioData.music.Length){
				System.Array.Resize (ref RTS_PlayerPrefs.audioData.music, RTS_PlayerPrefs.audioData.numberOfTracks);
			}
			EditorGUILayout.BeginVertical("Box");
			EditorGUILayout.LabelField ("Music Tracks", editorSkin.customStyles [0]);
			EditorGUILayout.EndVertical();
			for(int i = 0; i < RTS_PlayerPrefs.audioData.music.Length; i++){
				RTS_PlayerPrefs.audioData.music[i] = (AudioClip) EditorGUILayout.ObjectField ("Track " + i, RTS_PlayerPrefs.audioData.music[i], typeof(AudioClip), false);
			}
			EditorGUILayout.BeginVertical("Box");
			EditorGUILayout.LabelField ("UI Interaction Sounds", editorSkin.customStyles [0]);
			EditorGUILayout.EndVertical();
			RTS_PlayerPrefs.audioData.menuBack = (AudioClip) EditorGUILayout.ObjectField ("Back", RTS_PlayerPrefs.audioData.menuBack, typeof(AudioClip), false);
			RTS_PlayerPrefs.audioData.menuSelect = (AudioClip) EditorGUILayout.ObjectField ("Confirm", RTS_PlayerPrefs.audioData.menuSelect, typeof(AudioClip), false);
			EditorUtility.SetDirty (RTS_PlayerPrefs.audioData);
		}
/// Input Settings
		if(inputSettings){
			EditorGUILayout.BeginVertical("Box");
			EditorGUILayout.LabelField ("Input Manager Axes Settings", editorSkin.customStyles [0]);
			EditorGUILayout.EndVertical();
			SerializedObject serializedObject = new SerializedObject (AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0]);

			SerializedProperty axisProperty = serializedObject.FindProperty ("m_Axes");
			EditorGUI.BeginChangeCheck ();
			EditorGUILayout.PropertyField (axisProperty, true);
			if (EditorGUI.EndChangeCheck ())
				serializedObject.ApplyModifiedProperties ();
			EditorGUILayout.BeginVertical("Box");
			EditorGUILayout.LabelField ("Keyboard Input Settings", editorSkin.customStyles [0]);
			EditorGUILayout.EndVertical();

			RTS_PlayerPrefs.inputData.pauseKey = (KeyCode)EditorGUILayout.EnumPopup ("Pause", RTS_PlayerPrefs.inputData.pauseKey);
			RTS_PlayerPrefs.inputData.cameraSwitchKey = (KeyCode)EditorGUILayout.EnumPopup ("Camera Switch", RTS_PlayerPrefs.inputData.cameraSwitchKey);
			RTS_PlayerPrefs.inputData.nitroKey = (KeyCode)EditorGUILayout.EnumPopup ("Nitro", RTS_PlayerPrefs.inputData.nitroKey);
			RTS_PlayerPrefs.inputData.shiftUp = (KeyCode)EditorGUILayout.EnumPopup ("Shift Up", RTS_PlayerPrefs.inputData.shiftUp);
			RTS_PlayerPrefs.inputData.shiftDown = (KeyCode)EditorGUILayout.EnumPopup ("Shift Down", RTS_PlayerPrefs.inputData.shiftDown);
			RTS_PlayerPrefs.inputData.lookBack = (KeyCode)EditorGUILayout.EnumPopup ("Look Back", RTS_PlayerPrefs.inputData.lookBack);

			EditorGUILayout.BeginVertical("Box");
			EditorGUILayout.LabelField ("Joystick Input Settings", editorSkin.customStyles [0]);
			EditorGUILayout.EndVertical();

			RTS_PlayerPrefs.inputData._pauseJoystick = (InputData.Joystick)EditorGUILayout.EnumPopup ("Pause", RTS_PlayerPrefs.inputData._pauseJoystick);
			switch(RTS_PlayerPrefs.inputData._pauseJoystick){
			case InputData.Joystick.None:
				RTS_PlayerPrefs.inputData.pauseJoystick = KeyCode.None;
				break;
			case InputData.Joystick.JoystickButton0:
				RTS_PlayerPrefs.inputData.pauseJoystick = KeyCode.JoystickButton0; 
				break;
			case InputData.Joystick.JoystickButton1:
				RTS_PlayerPrefs.inputData.pauseJoystick = KeyCode.JoystickButton1; 
				break;
			case InputData.Joystick.JoystickButton2:
				RTS_PlayerPrefs.inputData.pauseJoystick = KeyCode.JoystickButton2; 
				break;
			case InputData.Joystick.JoystickButton3:
				RTS_PlayerPrefs.inputData.pauseJoystick = KeyCode.JoystickButton3; 
				break;
			case InputData.Joystick.JoystickButton4:
				RTS_PlayerPrefs.inputData.pauseJoystick = KeyCode.JoystickButton4; 
				break;
			case InputData.Joystick.JoystickButton5:
				RTS_PlayerPrefs.inputData.pauseJoystick = KeyCode.JoystickButton5; 
				break;
			case InputData.Joystick.JoystickButton6:
				RTS_PlayerPrefs.inputData.pauseJoystick = KeyCode.JoystickButton6; 
				break;
			case InputData.Joystick.JoystickButton7:
				RTS_PlayerPrefs.inputData.pauseJoystick = KeyCode.JoystickButton7; 
				break;
			case InputData.Joystick.JoystickButton8:
				RTS_PlayerPrefs.inputData.pauseJoystick = KeyCode.JoystickButton8; 
				break;
			case InputData.Joystick.JoystickButton9:
				RTS_PlayerPrefs.inputData.pauseJoystick = KeyCode.JoystickButton9; 
				break;
			case InputData.Joystick.JoystickButton10:
				RTS_PlayerPrefs.inputData.pauseJoystick = KeyCode.JoystickButton10; 
				break;
			case InputData.Joystick.JoystickButton11:
				RTS_PlayerPrefs.inputData.pauseJoystick = KeyCode.JoystickButton11; 
				break;
			case InputData.Joystick.JoystickButton12:
				RTS_PlayerPrefs.inputData.pauseJoystick = KeyCode.JoystickButton12; 
				break;
			case InputData.Joystick.JoystickButton13:
				RTS_PlayerPrefs.inputData.pauseJoystick = KeyCode.JoystickButton13; 
				break;
			case InputData.Joystick.JoystickButton14:
				RTS_PlayerPrefs.inputData.pauseJoystick = KeyCode.JoystickButton14; 
				break;
			case InputData.Joystick.JoystickButton15:
				RTS_PlayerPrefs.inputData.pauseJoystick = KeyCode.JoystickButton15; 
				break;
			case InputData.Joystick.JoystickButton16:
				RTS_PlayerPrefs.inputData.pauseJoystick = KeyCode.JoystickButton16; 
				break;
			case InputData.Joystick.JoystickButton17:
				RTS_PlayerPrefs.inputData.pauseJoystick = KeyCode.JoystickButton17; 
				break;
			case InputData.Joystick.JoystickButton18:
				RTS_PlayerPrefs.inputData.pauseJoystick = KeyCode.JoystickButton18; 
				break;
			case InputData.Joystick.JoystickButton19:
				RTS_PlayerPrefs.inputData.pauseJoystick = KeyCode.JoystickButton19;
				break;
			}
			RTS_PlayerPrefs.inputData._cameraSwitchJoystick = (InputData.Joystick)EditorGUILayout.EnumPopup ("Camera Switch", RTS_PlayerPrefs.inputData._cameraSwitchJoystick);
			switch(RTS_PlayerPrefs.inputData._cameraSwitchJoystick){
			case InputData.Joystick.None:
				RTS_PlayerPrefs.inputData.cameraSwitchJoystick = KeyCode.None;
				break;
			case InputData.Joystick.JoystickButton0:
				RTS_PlayerPrefs.inputData.cameraSwitchJoystick = KeyCode.JoystickButton0; 
				break;
			case InputData.Joystick.JoystickButton1:
				RTS_PlayerPrefs.inputData.cameraSwitchJoystick = KeyCode.JoystickButton1; 
				break;
			case InputData.Joystick.JoystickButton2:
				RTS_PlayerPrefs.inputData.cameraSwitchJoystick = KeyCode.JoystickButton2; 
				break;
			case InputData.Joystick.JoystickButton3:
				RTS_PlayerPrefs.inputData.cameraSwitchJoystick = KeyCode.JoystickButton3; 
				break;
			case InputData.Joystick.JoystickButton4:
				RTS_PlayerPrefs.inputData.cameraSwitchJoystick = KeyCode.JoystickButton4; 
				break;
			case InputData.Joystick.JoystickButton5:
				RTS_PlayerPrefs.inputData.cameraSwitchJoystick = KeyCode.JoystickButton5; 
				break;
			case InputData.Joystick.JoystickButton6:
				RTS_PlayerPrefs.inputData.cameraSwitchJoystick = KeyCode.JoystickButton6; 
				break;
			case InputData.Joystick.JoystickButton7:
				RTS_PlayerPrefs.inputData.cameraSwitchJoystick = KeyCode.JoystickButton7; 
				break;
			case InputData.Joystick.JoystickButton8:
				RTS_PlayerPrefs.inputData.cameraSwitchJoystick = KeyCode.JoystickButton8; 
				break;
			case InputData.Joystick.JoystickButton9:
				RTS_PlayerPrefs.inputData.cameraSwitchJoystick = KeyCode.JoystickButton9; 
				break;
			case InputData.Joystick.JoystickButton10:
				RTS_PlayerPrefs.inputData.cameraSwitchJoystick = KeyCode.JoystickButton10; 
				break;
			case InputData.Joystick.JoystickButton11:
				RTS_PlayerPrefs.inputData.cameraSwitchJoystick = KeyCode.JoystickButton11; 
				break;
			case InputData.Joystick.JoystickButton12:
				RTS_PlayerPrefs.inputData.cameraSwitchJoystick = KeyCode.JoystickButton12; 
				break;
			case InputData.Joystick.JoystickButton13:
				RTS_PlayerPrefs.inputData.cameraSwitchJoystick = KeyCode.JoystickButton13; 
				break;
			case InputData.Joystick.JoystickButton14:
				RTS_PlayerPrefs.inputData.cameraSwitchJoystick = KeyCode.JoystickButton14; 
				break;
			case InputData.Joystick.JoystickButton15:
				RTS_PlayerPrefs.inputData.cameraSwitchJoystick = KeyCode.JoystickButton15; 
				break;
			case InputData.Joystick.JoystickButton16:
				RTS_PlayerPrefs.inputData.cameraSwitchJoystick = KeyCode.JoystickButton16; 
				break;
			case InputData.Joystick.JoystickButton17:
				RTS_PlayerPrefs.inputData.cameraSwitchJoystick = KeyCode.JoystickButton17; 
				break;
			case InputData.Joystick.JoystickButton18:
				RTS_PlayerPrefs.inputData.cameraSwitchJoystick = KeyCode.JoystickButton18; 
				break;
			case InputData.Joystick.JoystickButton19:
				RTS_PlayerPrefs.inputData.cameraSwitchJoystick = KeyCode.JoystickButton19;
				break;
			}
			RTS_PlayerPrefs.inputData._nitroJoystick = (InputData.Joystick)EditorGUILayout.EnumPopup ("Nitro", RTS_PlayerPrefs.inputData._nitroJoystick);
			switch(RTS_PlayerPrefs.inputData._nitroJoystick){
			case InputData.Joystick.None:
				RTS_PlayerPrefs.inputData.nitroJoystick = KeyCode.None;
				break;
			case InputData.Joystick.JoystickButton0:
				RTS_PlayerPrefs.inputData.nitroJoystick = KeyCode.JoystickButton0; 
				break;
			case InputData.Joystick.JoystickButton1:
				RTS_PlayerPrefs.inputData.nitroJoystick = KeyCode.JoystickButton1; 
				break;
			case InputData.Joystick.JoystickButton2:
				RTS_PlayerPrefs.inputData.nitroJoystick = KeyCode.JoystickButton2; 
				break;
			case InputData.Joystick.JoystickButton3:
				RTS_PlayerPrefs.inputData.nitroJoystick = KeyCode.JoystickButton3; 
				break;
			case InputData.Joystick.JoystickButton4:
				RTS_PlayerPrefs.inputData.nitroJoystick = KeyCode.JoystickButton4; 
				break;
			case InputData.Joystick.JoystickButton5:
				RTS_PlayerPrefs.inputData.nitroJoystick = KeyCode.JoystickButton5; 
				break;
			case InputData.Joystick.JoystickButton6:
				RTS_PlayerPrefs.inputData.nitroJoystick = KeyCode.JoystickButton6; 
				break;
			case InputData.Joystick.JoystickButton7:
				RTS_PlayerPrefs.inputData.nitroJoystick = KeyCode.JoystickButton7; 
				break;
			case InputData.Joystick.JoystickButton8:
				RTS_PlayerPrefs.inputData.nitroJoystick = KeyCode.JoystickButton8; 
				break;
			case InputData.Joystick.JoystickButton9:
				RTS_PlayerPrefs.inputData.nitroJoystick = KeyCode.JoystickButton9; 
				break;
			case InputData.Joystick.JoystickButton10:
				RTS_PlayerPrefs.inputData.nitroJoystick = KeyCode.JoystickButton10; 
				break;
			case InputData.Joystick.JoystickButton11:
				RTS_PlayerPrefs.inputData.nitroJoystick = KeyCode.JoystickButton11; 
				break;
			case InputData.Joystick.JoystickButton12:
				RTS_PlayerPrefs.inputData.nitroJoystick = KeyCode.JoystickButton12; 
				break;
			case InputData.Joystick.JoystickButton13:
				RTS_PlayerPrefs.inputData.nitroJoystick = KeyCode.JoystickButton13; 
				break;
			case InputData.Joystick.JoystickButton14:
				RTS_PlayerPrefs.inputData.nitroJoystick = KeyCode.JoystickButton14; 
				break;
			case InputData.Joystick.JoystickButton15:
				RTS_PlayerPrefs.inputData.nitroJoystick = KeyCode.JoystickButton15; 
				break;
			case InputData.Joystick.JoystickButton16:
				RTS_PlayerPrefs.inputData.nitroJoystick = KeyCode.JoystickButton16; 
				break;
			case InputData.Joystick.JoystickButton17:
				RTS_PlayerPrefs.inputData.nitroJoystick = KeyCode.JoystickButton17; 
				break;
			case InputData.Joystick.JoystickButton18:
				RTS_PlayerPrefs.inputData.nitroJoystick = KeyCode.JoystickButton18; 
				break;
			case InputData.Joystick.JoystickButton19:
				RTS_PlayerPrefs.inputData.nitroJoystick = KeyCode.JoystickButton19;
				break;
			}
			RTS_PlayerPrefs.inputData._shiftUpJoystick = (InputData.Joystick)EditorGUILayout.EnumPopup ("Shift Up", RTS_PlayerPrefs.inputData._shiftUpJoystick);
			switch(RTS_PlayerPrefs.inputData._shiftUpJoystick){
			case InputData.Joystick.None:
				RTS_PlayerPrefs.inputData.shiftUpJoystick = KeyCode.None;
				break;
			case InputData.Joystick.JoystickButton0:
				RTS_PlayerPrefs.inputData.shiftUpJoystick = KeyCode.JoystickButton0; 
				break;
			case InputData.Joystick.JoystickButton1:
				RTS_PlayerPrefs.inputData.shiftUpJoystick = KeyCode.JoystickButton1; 
				break;
			case InputData.Joystick.JoystickButton2:
				RTS_PlayerPrefs.inputData.shiftUpJoystick = KeyCode.JoystickButton2; 
				break;
			case InputData.Joystick.JoystickButton3:
				RTS_PlayerPrefs.inputData.shiftUpJoystick = KeyCode.JoystickButton3; 
				break;
			case InputData.Joystick.JoystickButton4:
				RTS_PlayerPrefs.inputData.shiftUpJoystick = KeyCode.JoystickButton4; 
				break;
			case InputData.Joystick.JoystickButton5:
				RTS_PlayerPrefs.inputData.shiftUpJoystick = KeyCode.JoystickButton5; 
				break;
			case InputData.Joystick.JoystickButton6:
				RTS_PlayerPrefs.inputData.shiftUpJoystick = KeyCode.JoystickButton6; 
				break;
			case InputData.Joystick.JoystickButton7:
				RTS_PlayerPrefs.inputData.shiftUpJoystick = KeyCode.JoystickButton7; 
				break;
			case InputData.Joystick.JoystickButton8:
				RTS_PlayerPrefs.inputData.shiftUpJoystick = KeyCode.JoystickButton8; 
				break;
			case InputData.Joystick.JoystickButton9:
				RTS_PlayerPrefs.inputData.shiftUpJoystick = KeyCode.JoystickButton9; 
				break;
			case InputData.Joystick.JoystickButton10:
				RTS_PlayerPrefs.inputData.shiftUpJoystick = KeyCode.JoystickButton10; 
				break;
			case InputData.Joystick.JoystickButton11:
				RTS_PlayerPrefs.inputData.shiftUpJoystick = KeyCode.JoystickButton11; 
				break;
			case InputData.Joystick.JoystickButton12:
				RTS_PlayerPrefs.inputData.shiftUpJoystick = KeyCode.JoystickButton12; 
				break;
			case InputData.Joystick.JoystickButton13:
				RTS_PlayerPrefs.inputData.shiftUpJoystick = KeyCode.JoystickButton13; 
				break;
			case InputData.Joystick.JoystickButton14:
				RTS_PlayerPrefs.inputData.shiftUpJoystick = KeyCode.JoystickButton14; 
				break;
			case InputData.Joystick.JoystickButton15:
				RTS_PlayerPrefs.inputData.shiftUpJoystick = KeyCode.JoystickButton15; 
				break;
			case InputData.Joystick.JoystickButton16:
				RTS_PlayerPrefs.inputData.shiftUpJoystick = KeyCode.JoystickButton16; 
				break;
			case InputData.Joystick.JoystickButton17:
				RTS_PlayerPrefs.inputData.shiftUpJoystick = KeyCode.JoystickButton17; 
				break;
			case InputData.Joystick.JoystickButton18:
				RTS_PlayerPrefs.inputData.shiftUpJoystick = KeyCode.JoystickButton18; 
				break;
			case InputData.Joystick.JoystickButton19:
				RTS_PlayerPrefs.inputData.shiftUpJoystick = KeyCode.JoystickButton19;
				break;
			}
			RTS_PlayerPrefs.inputData._shiftDownJoystick = (InputData.Joystick)EditorGUILayout.EnumPopup ("Shift Down", RTS_PlayerPrefs.inputData._shiftDownJoystick);
			switch(RTS_PlayerPrefs.inputData._shiftDownJoystick){
			case InputData.Joystick.None:
				RTS_PlayerPrefs.inputData.shiftDownJoystick = KeyCode.None;
				break;
			case InputData.Joystick.JoystickButton0:
				RTS_PlayerPrefs.inputData.shiftDownJoystick = KeyCode.JoystickButton0; 
				break;
			case InputData.Joystick.JoystickButton1:
				RTS_PlayerPrefs.inputData.shiftDownJoystick = KeyCode.JoystickButton1; 
				break;
			case InputData.Joystick.JoystickButton2:
				RTS_PlayerPrefs.inputData.shiftDownJoystick = KeyCode.JoystickButton2; 
				break;
			case InputData.Joystick.JoystickButton3:
				RTS_PlayerPrefs.inputData.shiftDownJoystick = KeyCode.JoystickButton3; 
				break;
			case InputData.Joystick.JoystickButton4:
				RTS_PlayerPrefs.inputData.shiftDownJoystick = KeyCode.JoystickButton4; 
				break;
			case InputData.Joystick.JoystickButton5:
				RTS_PlayerPrefs.inputData.shiftDownJoystick = KeyCode.JoystickButton5; 
				break;
			case InputData.Joystick.JoystickButton6:
				RTS_PlayerPrefs.inputData.shiftDownJoystick = KeyCode.JoystickButton6; 
				break;
			case InputData.Joystick.JoystickButton7:
				RTS_PlayerPrefs.inputData.shiftDownJoystick = KeyCode.JoystickButton7; 
				break;
			case InputData.Joystick.JoystickButton8:
				RTS_PlayerPrefs.inputData.shiftDownJoystick = KeyCode.JoystickButton8; 
				break;
			case InputData.Joystick.JoystickButton9:
				RTS_PlayerPrefs.inputData.shiftDownJoystick = KeyCode.JoystickButton9; 
				break;
			case InputData.Joystick.JoystickButton10:
				RTS_PlayerPrefs.inputData.shiftDownJoystick = KeyCode.JoystickButton10; 
				break;
			case InputData.Joystick.JoystickButton11:
				RTS_PlayerPrefs.inputData.shiftDownJoystick = KeyCode.JoystickButton11; 
				break;
			case InputData.Joystick.JoystickButton12:
				RTS_PlayerPrefs.inputData.shiftDownJoystick = KeyCode.JoystickButton12; 
				break;
			case InputData.Joystick.JoystickButton13:
				RTS_PlayerPrefs.inputData.shiftDownJoystick = KeyCode.JoystickButton13; 
				break;
			case InputData.Joystick.JoystickButton14:
				RTS_PlayerPrefs.inputData.shiftDownJoystick = KeyCode.JoystickButton14; 
				break;
			case InputData.Joystick.JoystickButton15:
				RTS_PlayerPrefs.inputData.shiftDownJoystick = KeyCode.JoystickButton15; 
				break;
			case InputData.Joystick.JoystickButton16:
				RTS_PlayerPrefs.inputData.shiftDownJoystick = KeyCode.JoystickButton16; 
				break;
			case InputData.Joystick.JoystickButton17:
				RTS_PlayerPrefs.inputData.shiftDownJoystick = KeyCode.JoystickButton17; 
				break;
			case InputData.Joystick.JoystickButton18:
				RTS_PlayerPrefs.inputData.shiftDownJoystick = KeyCode.JoystickButton18; 
				break;
			case InputData.Joystick.JoystickButton19:
				RTS_PlayerPrefs.inputData.shiftDownJoystick = KeyCode.JoystickButton19;
				break;
			}
			RTS_PlayerPrefs.inputData._lookBackJoystick = (InputData.Joystick)EditorGUILayout.EnumPopup ("Look Back", RTS_PlayerPrefs.inputData._lookBackJoystick);
			switch(RTS_PlayerPrefs.inputData._lookBackJoystick){
			case InputData.Joystick.None:
				RTS_PlayerPrefs.inputData.lookBackJoystick = KeyCode.None;
				break;
			case InputData.Joystick.JoystickButton0:
				RTS_PlayerPrefs.inputData.lookBackJoystick = KeyCode.JoystickButton0; 
				break;
			case InputData.Joystick.JoystickButton1:
				RTS_PlayerPrefs.inputData.lookBackJoystick = KeyCode.JoystickButton1; 
				break;
			case InputData.Joystick.JoystickButton2:
				RTS_PlayerPrefs.inputData.lookBackJoystick = KeyCode.JoystickButton2; 
				break;
			case InputData.Joystick.JoystickButton3:
				RTS_PlayerPrefs.inputData.lookBackJoystick = KeyCode.JoystickButton3; 
				break;
			case InputData.Joystick.JoystickButton4:
				RTS_PlayerPrefs.inputData.lookBackJoystick = KeyCode.JoystickButton4; 
				break;
			case InputData.Joystick.JoystickButton5:
				RTS_PlayerPrefs.inputData.lookBackJoystick = KeyCode.JoystickButton5; 
				break;
			case InputData.Joystick.JoystickButton6:
				RTS_PlayerPrefs.inputData.lookBackJoystick = KeyCode.JoystickButton6; 
				break;
			case InputData.Joystick.JoystickButton7:
				RTS_PlayerPrefs.inputData.lookBackJoystick = KeyCode.JoystickButton7; 
				break;
			case InputData.Joystick.JoystickButton8:
				RTS_PlayerPrefs.inputData.lookBackJoystick = KeyCode.JoystickButton8; 
				break;
			case InputData.Joystick.JoystickButton9:
				RTS_PlayerPrefs.inputData.lookBackJoystick = KeyCode.JoystickButton9; 
				break;
			case InputData.Joystick.JoystickButton10:
				RTS_PlayerPrefs.inputData.lookBackJoystick = KeyCode.JoystickButton10; 
				break;
			case InputData.Joystick.JoystickButton11:
				RTS_PlayerPrefs.inputData.lookBackJoystick = KeyCode.JoystickButton11; 
				break;
			case InputData.Joystick.JoystickButton12:
				RTS_PlayerPrefs.inputData.lookBackJoystick = KeyCode.JoystickButton12; 
				break;
			case InputData.Joystick.JoystickButton13:
				RTS_PlayerPrefs.inputData.lookBackJoystick = KeyCode.JoystickButton13; 
				break;
			case InputData.Joystick.JoystickButton14:
				RTS_PlayerPrefs.inputData.lookBackJoystick = KeyCode.JoystickButton14; 
				break;
			case InputData.Joystick.JoystickButton15:
				RTS_PlayerPrefs.inputData.lookBackJoystick = KeyCode.JoystickButton15; 
				break;
			case InputData.Joystick.JoystickButton16:
				RTS_PlayerPrefs.inputData.lookBackJoystick = KeyCode.JoystickButton16; 
				break;
			case InputData.Joystick.JoystickButton17:
				RTS_PlayerPrefs.inputData.lookBackJoystick = KeyCode.JoystickButton17; 
				break;
			case InputData.Joystick.JoystickButton18:
				RTS_PlayerPrefs.inputData.lookBackJoystick = KeyCode.JoystickButton18; 
				break;
			case InputData.Joystick.JoystickButton19:
				RTS_PlayerPrefs.inputData.lookBackJoystick = KeyCode.JoystickButton19;
				break;
			}

			EditorGUILayout.BeginVertical("Box");
			EditorGUILayout.LabelField ("Mobile Settings", editorSkin.customStyles [0]);
			EditorGUILayout.EndVertical();
			RTS_PlayerPrefs.inputData.useMobileController = EditorGUILayout.Toggle("Use Mobile Controller", RTS_PlayerPrefs.inputData.useMobileController);
			RTS_PlayerPrefs.inputData.mobileController = (GameObject) EditorGUILayout.ObjectField("Prefab", RTS_PlayerPrefs.inputData.mobileController, typeof (GameObject), false );

			EditorUtility.SetDirty (RTS_PlayerPrefs.inputData);
		}
/// Race Settings
		if(raceSettings){
			EditorGUILayout.BeginVertical("Box");
			EditorGUILayout.LabelField ("Race Settings", editorSkin.customStyles [0]);
			EditorGUILayout.EndVertical();

			configureRaceSize = (Switch) EditorGUILayout.EnumPopup ("Configure Race Size", configureRaceSize);
			if (configureRaceSize == Switch.On) {
				EditorGUILayout.HelpBox ("When you reduce this number the values of the affected arrays are deleted. Only reduce this number if you want fewer races.", MessageType.Warning);
				EditorGUILayout.BeginHorizontal ();
				numberOfRaces = EditorGUILayout.IntField ("Number Of Races", numberOfRaces);
				if (GUILayout.Button ("Update")) {
					GUIUtility.hotControl = 0;
					GUIUtility.keyboardControl = 0;
					RTS_PlayerPrefs.raceData.numberOfRaces = numberOfRaces;
					raceView = 0;
				}
				EditorGUILayout.EndHorizontal ();
				System.Array.Resize (ref RTS_PlayerPrefs.raceData.raceNames, RTS_PlayerPrefs.raceData.numberOfRaces);
				System.Array.Resize (ref RTS_PlayerPrefs.raceData.raceImages, RTS_PlayerPrefs.raceData.numberOfRaces);
				System.Array.Resize (ref RTS_PlayerPrefs.raceData.gameType, RTS_PlayerPrefs.raceData.numberOfRaces);
				System.Array.Resize (ref RTS_PlayerPrefs.raceData.numberOfRacers, RTS_PlayerPrefs.raceData.numberOfRaces);
				System.Array.Resize (ref RTS_PlayerPrefs.raceData.raceLaps, RTS_PlayerPrefs.raceData.numberOfRaces);
				System.Array.Resize (ref RTS_PlayerPrefs.raceData.lapLimit, RTS_PlayerPrefs.raceData.numberOfRaces);
				System.Array.Resize (ref RTS_PlayerPrefs.raceData.racerLimit, RTS_PlayerPrefs.raceData.numberOfRaces);
				System.Array.Resize (ref RTS_PlayerPrefs.raceData.raceLocked, RTS_PlayerPrefs.raceData.numberOfRaces);
				System.Array.Resize (ref RTS_PlayerPrefs.raceData.unlockAmount, RTS_PlayerPrefs.raceData.numberOfRaces);
				System.Array.Resize (ref RTS_PlayerPrefs.raceData.firstPrize, RTS_PlayerPrefs.raceData.numberOfRaces);
				System.Array.Resize (ref RTS_PlayerPrefs.raceData.secondPrize, RTS_PlayerPrefs.raceData.numberOfRaces);
				System.Array.Resize (ref RTS_PlayerPrefs.raceData.thirdPrize, RTS_PlayerPrefs.raceData.numberOfRaces);
				System.Array.Resize (ref RTS_PlayerPrefs.raceData.readyTime, RTS_PlayerPrefs.raceData.numberOfRaces);
				System.Array.Resize (ref RTS_PlayerPrefs.raceData.showWaypoints, RTS_PlayerPrefs.raceData.numberOfRaces);
				System.Array.Resize (ref RTS_PlayerPrefs.raceData.showWaypointArrow, RTS_PlayerPrefs.raceData.numberOfRaces);

				System.Array.Resize (ref RTS_PlayerPrefs.raceData.unlimitedRewards, RTS_PlayerPrefs.raceData.numberOfRaces);
			} else if(RTS_PlayerPrefs.raceData.numberOfRaces != numberOfRaces){
				numberOfRaces = RTS_PlayerPrefs.raceData.numberOfRaces;
			}
			EditorGUILayout.BeginHorizontal();
			if (GUILayout.Button ("<", GUILayout.MaxWidth(Screen.width * 0.33f), GUILayout.MaxHeight(35) )) {
				GUIUtility.hotControl = 0;
				GUIUtility.keyboardControl = 0;
				if (raceView > 0) {
					raceView -= 1;
				} else {
					raceView = RTS_PlayerPrefs.raceData.numberOfRaces - 1;
				}
			}
			GUILayout.Label("Race\n" + raceView.ToString(), GUILayout.MaxWidth(Screen.width * 0.33f), GUILayout.MaxHeight(35) );
			if (GUILayout.Button (">", GUILayout.MaxWidth(Screen.width * 0.33f), GUILayout.MaxHeight(35) )) {
				GUIUtility.hotControl = 0;
				GUIUtility.keyboardControl = 0;
				if (raceView < RTS_PlayerPrefs.raceData.numberOfRaces - 1) {
					raceView += 1;
				} else {
					raceView = 0;
				}
			}
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.BeginVertical();
			RTS_PlayerPrefs.raceData.raceNames[raceView] = EditorGUILayout.TextField("Race Name", RTS_PlayerPrefs.raceData.raceNames[raceView]);
			RTS_PlayerPrefs.raceData.raceImages[raceView] = (Sprite) EditorGUILayout.ObjectField("Race Image", RTS_PlayerPrefs.raceData.raceImages[raceView], typeof (Sprite), false, GUILayout.MaxHeight(16) );
			RTS_PlayerPrefs.raceData.gameType[raceView] = (RaceData.GameType) EditorGUILayout.EnumPopup ("Game Type", RTS_PlayerPrefs.raceData.gameType[raceView]);

			RTS_PlayerPrefs.raceData.raceLocked[raceView] = EditorGUILayout.Toggle("Race Locked", RTS_PlayerPrefs.raceData.raceLocked[raceView]);
			if(RTS_PlayerPrefs.raceData.purchaseLevelUnlock == RaceData.Switch.On)
				RTS_PlayerPrefs.raceData.unlockAmount[raceView] = EditorGUILayout.IntField("Unlock Amount", RTS_PlayerPrefs.raceData.unlockAmount[raceView]);
			RTS_PlayerPrefs.raceData.unlimitedRewards[raceView] = EditorGUILayout.Toggle("Unlimited Rewards", RTS_PlayerPrefs.raceData.unlimitedRewards[raceView]);
			RTS_PlayerPrefs.raceData.firstPrize[raceView] = EditorGUILayout.IntField("First Prize", RTS_PlayerPrefs.raceData.firstPrize[raceView]);
			RTS_PlayerPrefs.raceData.secondPrize[raceView] = EditorGUILayout.IntField("Second Prize", RTS_PlayerPrefs.raceData.secondPrize[raceView]);
			RTS_PlayerPrefs.raceData.thirdPrize[raceView] = EditorGUILayout.IntField("Third Prize", RTS_PlayerPrefs.raceData.thirdPrize[raceView]);
			RTS_PlayerPrefs.raceData.numberOfRacers[raceView] = EditorGUILayout.IntSlider("Number of Racers", RTS_PlayerPrefs.raceData.numberOfRacers[raceView], 1, 64);
			RTS_PlayerPrefs.raceData.racerLimit[raceView] = EditorGUILayout.IntSlider ("Racer Limit", RTS_PlayerPrefs.raceData.racerLimit[raceView], 1, 64);
			RTS_PlayerPrefs.raceData.raceLaps[raceView] = EditorGUILayout.IntField("Number of Laps", RTS_PlayerPrefs.raceData.raceLaps[raceView]);
			RTS_PlayerPrefs.raceData.lapLimit[raceView] = EditorGUILayout.IntField("Lap Limit", RTS_PlayerPrefs.raceData.lapLimit[raceView]);
			RTS_PlayerPrefs.raceData.readyTime[raceView] = EditorGUILayout.FloatField("Ready Time", RTS_PlayerPrefs.raceData.readyTime[raceView]);
			RTS_PlayerPrefs.raceData.showWaypoints[raceView] = EditorGUILayout.Toggle("Show Waypoints", RTS_PlayerPrefs.raceData.showWaypoints[raceView]);
			RTS_PlayerPrefs.raceData.showWaypointArrow[raceView] = EditorGUILayout.Toggle("Show RTS_Waypoint Arrow", RTS_PlayerPrefs.raceData.showWaypointArrow[raceView]);
			EditorGUILayout.EndVertical();
			EditorGUILayout.BeginVertical("Box");
			EditorGUILayout.LabelField ("General Settings", editorSkin.customStyles [0]);
			EditorGUILayout.EndVertical();
			RTS_PlayerPrefs.raceData.autoUnlockNextRace = (RaceData.Switch) EditorGUILayout.EnumPopup ("Autounlock Next Race", RTS_PlayerPrefs.raceData.autoUnlockNextRace);
			RTS_PlayerPrefs.raceData.purchaseLevelUnlock = (RaceData.Switch) EditorGUILayout.EnumPopup ("Purchase Level Unlocks", RTS_PlayerPrefs.raceData.purchaseLevelUnlock);
			RTS_PlayerPrefs.raceData.lockButtonText = EditorGUILayout.TextField ("Locked Button Text", RTS_PlayerPrefs.raceData.lockButtonText);
			RTS_PlayerPrefs.raceData.wrongWayDelay = EditorGUILayout.FloatField("Wrong Way Delay", RTS_PlayerPrefs.raceData.wrongWayDelay);
			EditorUtility.SetDirty (RTS_PlayerPrefs.raceData);
		}
/// Opponent Vehicles Settings
		if(opponentVehicleSettings){
			EditorGUILayout.BeginVertical("Box");
			EditorGUILayout.LabelField ("AI Vehicle Settings", editorSkin.customStyles [0]);
			EditorGUILayout.EndVertical();

			EditorGUILayout.BeginHorizontal();
			if (GUILayout.Button ("<", GUILayout.MaxWidth(Screen.width * 0.33f), GUILayout.MaxHeight(35) )) {
				GUIUtility.hotControl = 0;
				GUIUtility.keyboardControl = 0;
				if (opponentCarView > 0) {
					opponentCarView -= 1;
				} else {
					opponentCarView = 62;
				}
			}
			GUILayout.Label("Opponent\n" + opponentCarView.ToString(), GUILayout.MaxWidth(Screen.width * 0.33f), GUILayout.MaxHeight(35) );
			if (GUILayout.Button (">", GUILayout.MaxWidth(Screen.width * 0.33f), GUILayout.MaxHeight(35) )) {
				GUIUtility.hotControl = 0;
				GUIUtility.keyboardControl = 0;
				if (opponentCarView < 62) {
					opponentCarView += 1;
				} else {
					opponentCarView = 0;
				}
			}
			EditorGUILayout.EndHorizontal();
			GUI.skin = defaultSkin;
			RTS_PlayerPrefs.opponentVehicles.opponentNames[opponentCarView] = EditorGUILayout.TextField("Name", RTS_PlayerPrefs.opponentVehicles.opponentNames[opponentCarView]);
			RTS_PlayerPrefs.opponentVehicles.vehicles[opponentCarView] = (GameObject) EditorGUILayout.ObjectField("Prefab", RTS_PlayerPrefs.opponentVehicles.vehicles[opponentCarView], typeof (GameObject), false );
			RTS_PlayerPrefs.opponentVehicles.opponentBodyMaterials[opponentCarView] = (Material) EditorGUILayout.ObjectField("Body Material", RTS_PlayerPrefs.opponentVehicles.opponentBodyMaterials[opponentCarView], typeof (Material), false );
			RTS_PlayerPrefs.opponentVehicles.opponentBodyColors[opponentCarView] = EditorGUILayout.ColorField("Body Color", RTS_PlayerPrefs.opponentVehicles.opponentBodyColors[opponentCarView]);
			if(RTS_PlayerPrefs.opponentVehicles.opponentBodyMaterials[opponentCarView] != null){
				RTS_PlayerPrefs.opponentVehicles.opponentBodyMaterials [opponentCarView].color = RTS_PlayerPrefs.opponentVehicles.opponentBodyColors [opponentCarView];
			}
			EditorUtility.SetDirty (RTS_PlayerPrefs.opponentVehicles);
		}
/// Player Vehicles Settings
		if(playableVehicleSettings){
			EditorGUILayout.BeginVertical("Box");
			EditorGUILayout.LabelField ("Player Vehicle Settings", editorSkin.customStyles [0]);
			EditorGUILayout.EndVertical();

			configureCarSize = (Switch) EditorGUILayout.EnumPopup ("Configure Car Size", configureCarSize);
			if (configureCarSize == Switch.On) {
				EditorGUILayout.HelpBox ("When you reduce this number the values of the affected arrays are deleted. Only reduce this number if you want fewer playable vehicles.", MessageType.Warning);
				EditorGUILayout.BeginHorizontal ();
				numberOfCars = EditorGUILayout.IntField ("Number Of Cars", numberOfCars);
				if (GUILayout.Button ("Update")) {
					GUIUtility.hotControl = 0;
					GUIUtility.keyboardControl = 0;
					RTS_PlayerPrefs.playableVehicles.numberOfCars = numberOfCars;
					carView = 0;
				}
				EditorGUILayout.EndHorizontal ();
				System.Array.Resize (ref RTS_PlayerPrefs.playableVehicles.vehicles, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playableVehicles.vehicleNames, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playableVehicles.price, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playableVehicles.carMaterial, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playableVehicles.brakeMaterial, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playableVehicles.glassMaterial, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playableVehicles.rimMaterial, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playableVehicles.defaultBodyColors, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playableVehicles.defaultBrakeColors, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playableVehicles.defaultGlassColors, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playableVehicles.defaultRimColors, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playableVehicles.defaultNeonColors, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playableVehicles.carGlowLight, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playableVehicles.carUnlocked, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playableVehicles.speedometerType, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				//System.Array.Resize (ref RTS_PlayerPrefs.playableVehicles.vehicleUpgrades, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playableVehicles.topSpeedLevel, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playableVehicles.torqueLevel, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playableVehicles.brakeTorqueLevel, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playableVehicles.tireTractionLevel, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playableVehicles.steerSensitivityLevel, RTS_PlayerPrefs.playableVehicles.numberOfCars);

				System.Array.Resize (ref RTS_PlayerPrefs.playerPrefsData.redValues, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playerPrefsData.blueValues, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playerPrefsData.greenValues, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playerPrefsData.redGlowValues, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playerPrefsData.blueGlowValues, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playerPrefsData.greenGlowValues, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playerPrefsData.redGlassValues, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playerPrefsData.blueGlassValues, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playerPrefsData.greenGlassValues, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playerPrefsData.alphaGlassValues, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playerPrefsData.redBrakeValues, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playerPrefsData.blueBrakeValues, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playerPrefsData.greenBrakeValues, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playerPrefsData.redRimValues, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playerPrefsData.blueRimValues, RTS_PlayerPrefs.playableVehicles.numberOfCars);
				System.Array.Resize (ref RTS_PlayerPrefs.playerPrefsData.greenRimValues, RTS_PlayerPrefs.playableVehicles.numberOfCars);
			} else if(RTS_PlayerPrefs.playableVehicles.numberOfCars != numberOfCars){
				numberOfCars = RTS_PlayerPrefs.playableVehicles.numberOfCars;
			}
			EditorGUILayout.BeginHorizontal();
			if (GUILayout.Button ("<", GUILayout.MaxWidth(Screen.width * 0.33f), GUILayout.MaxHeight(35) )) {
				GUIUtility.hotControl = 0;
				GUIUtility.keyboardControl = 0;
				if (carView > 0) {
					carView -= 1;
				} else {
					carView = RTS_PlayerPrefs.playableVehicles.numberOfCars - 1;
				}
			}
			GUILayout.Label("Car\n" + carView.ToString(), GUILayout.MaxWidth(Screen.width * 0.33f), GUILayout.MaxHeight(35) );
			if (GUILayout.Button (">", GUILayout.MaxWidth(Screen.width * 0.33f), GUILayout.MaxHeight(35) )) {
				GUIUtility.hotControl = 0;
				GUIUtility.keyboardControl = 0;
				if (carView < RTS_PlayerPrefs.playableVehicles.numberOfCars - 1) {
					carView += 1;
				} else {
					carView = 0;
				}
			}
			EditorGUILayout.EndHorizontal();
			if (RTS_PlayerPrefs.playableVehicles.numberOfCars > 0) {
				RTS_PlayerPrefs.playableVehicles.vehicleNames [carView] = EditorGUILayout.TextField ("Name", RTS_PlayerPrefs.playableVehicles.vehicleNames [carView]);
				RTS_PlayerPrefs.playableVehicles.price [carView] = EditorGUILayout.IntField ("Price", RTS_PlayerPrefs.playableVehicles.price [carView]);
				RTS_PlayerPrefs.playableVehicles.carUnlocked [carView] = EditorGUILayout.Toggle ("Unlocked", RTS_PlayerPrefs.playableVehicles.carUnlocked [carView]);
				RTS_PlayerPrefs.playableVehicles.vehicles [carView] = (GameObject)EditorGUILayout.ObjectField ("Prefab", RTS_PlayerPrefs.playableVehicles.vehicles [carView], typeof(GameObject), false);
				RTS_PlayerPrefs.playableVehicles.carMaterial [carView] = (Material)EditorGUILayout.ObjectField ("Body Material", RTS_PlayerPrefs.playableVehicles.carMaterial [carView], typeof(Material), false);
				RTS_PlayerPrefs.playableVehicles.brakeMaterial [carView] = (Material)EditorGUILayout.ObjectField ("Brake Material", RTS_PlayerPrefs.playableVehicles.brakeMaterial [carView], typeof(Material), false);
				RTS_PlayerPrefs.playableVehicles.glassMaterial [carView] = (Material)EditorGUILayout.ObjectField ("Glass Material", RTS_PlayerPrefs.playableVehicles.glassMaterial [carView], typeof(Material), false);
				RTS_PlayerPrefs.playableVehicles.rimMaterial [carView] = (Material)EditorGUILayout.ObjectField ("Rim Material", RTS_PlayerPrefs.playableVehicles.rimMaterial [carView], typeof(Material), false);
				RTS_PlayerPrefs.playableVehicles.carGlowLight [carView] = (ParticleSystem)EditorGUILayout.ObjectField ("Neon Particle", RTS_PlayerPrefs.playableVehicles.carGlowLight [carView], typeof(ParticleSystem), false);
//new colors
				GUI.skin = defaultSkin;
				RTS_PlayerPrefs.playableVehicles.defaultBodyColors [carView] = EditorGUILayout.ColorField ("Default Body Color", RTS_PlayerPrefs.playableVehicles.defaultBodyColors [carView]);
				RTS_PlayerPrefs.playableVehicles.defaultBrakeColors [carView] = EditorGUILayout.ColorField ("Default Brake Color", RTS_PlayerPrefs.playableVehicles.defaultBrakeColors [carView]);
				RTS_PlayerPrefs.playableVehicles.defaultGlassColors [carView] = EditorGUILayout.ColorField ("Default Glass Color", RTS_PlayerPrefs.playableVehicles.defaultGlassColors [carView]);
				RTS_PlayerPrefs.playableVehicles.defaultRimColors [carView] = EditorGUILayout.ColorField ("Default Rim Color", RTS_PlayerPrefs.playableVehicles.defaultRimColors [carView]);
				RTS_PlayerPrefs.playableVehicles.defaultNeonColors [carView] = EditorGUILayout.ColorField ("Default Neon Color", RTS_PlayerPrefs.playableVehicles.defaultNeonColors [carView]);
				RTS_PlayerPrefs.playableVehicles.speedometerType [carView] = (RTS_DistanceUnits.SpeedType__CarRacing) EditorGUILayout.EnumPopup ("Speedometer Type", RTS_PlayerPrefs.playableVehicles.speedometerType [carView]);

				EditorGUILayout.BeginVertical ("box");
				showTopSpeedLevelBonus = EditorGUI.Foldout (EditorGUILayout.GetControlRect(), showTopSpeedLevelBonus, "  Top Speed Level Bonus", true);	
				EditorGUILayout.EndVertical();
				if (showTopSpeedLevelBonus) {
					//for (int i = 0; i < RTS_PlayerPrefs.playableVehicles.vehicleUpgrades [carView].topSpeed.Length; i++) {
					//	RTS_PlayerPrefs.playableVehicles.vehicleUpgrades [carView].topSpeed [i] = EditorGUILayout.FloatField ("Level " + (i + 1).ToString (), RTS_PlayerPrefs.playableVehicles.vehicleUpgrades [carView].topSpeed [i]);
					//}
				}
				EditorGUILayout.BeginVertical ("box");
				showAccelerationLevelBonus = EditorGUI.Foldout (EditorGUILayout.GetControlRect(), showAccelerationLevelBonus, "  Acceleration Level Bonus", true);						
				EditorGUILayout.EndVertical();
				if (showAccelerationLevelBonus) {
					//for (int i = 0; i < RTS_PlayerPrefs.playableVehicles.vehicleUpgrades [carView].acceleration.Length; i++) {
					//	RTS_PlayerPrefs.playableVehicles.vehicleUpgrades [carView].acceleration [i] = EditorGUILayout.FloatField ("Level " + (i + 1).ToString (), RTS_PlayerPrefs.playableVehicles.vehicleUpgrades [carView].acceleration [i]);
					//}
				}
				EditorGUILayout.BeginVertical ("box");
				showBrakePowerLevelBonus = EditorGUI.Foldout (EditorGUILayout.GetControlRect(), showBrakePowerLevelBonus, "  Brake Power Level Bonus", true);	
				EditorGUILayout.EndVertical();
				if (showBrakePowerLevelBonus) {
					//for (int i = 0; i < RTS_PlayerPrefs.playableVehicles.vehicleUpgrades [carView].brakePower.Length; i++) {
					//	RTS_PlayerPrefs.playableVehicles.vehicleUpgrades [carView].brakePower [i] = EditorGUILayout.FloatField ("Level " + (i + 1).ToString (), RTS_PlayerPrefs.playableVehicles.vehicleUpgrades [carView].brakePower [i]);
					//}
				}
				EditorGUILayout.BeginVertical ("box");
				showTireTractionLevelBonus = EditorGUI.Foldout (EditorGUILayout.GetControlRect(), showTireTractionLevelBonus, "  Tire Traction Level Bonus", true);	
				EditorGUILayout.EndVertical();
				if (showTireTractionLevelBonus) {
					//for (int i = 0; i < RTS_PlayerPrefs.playableVehicles.vehicleUpgrades [carView].tireTraction.Length; i++) {
					//	RTS_PlayerPrefs.playableVehicles.vehicleUpgrades [carView].tireTraction [i] = EditorGUILayout.FloatField ("Level " + (i + 1).ToString (), RTS_PlayerPrefs.playableVehicles.vehicleUpgrades [carView].tireTraction [i]);
					//}
				}
				EditorGUILayout.BeginVertical ("box");
				showSteerSensitivityLevelBonus = EditorGUI.Foldout (EditorGUILayout.GetControlRect(), showSteerSensitivityLevelBonus, "  Steer Sensitivity Level Bonus", true);	
				EditorGUILayout.EndVertical();
				if (showSteerSensitivityLevelBonus) {
					//for (int i = 0; i < RTS_PlayerPrefs.playableVehicles.vehicleUpgrades [carView].steerSensitivity.Length; i++) {
					//	RTS_PlayerPrefs.playableVehicles.vehicleUpgrades [carView].steerSensitivity [i] = EditorGUILayout.FloatField ("Level " + (i + 1).ToString (), RTS_PlayerPrefs.playableVehicles.vehicleUpgrades [carView].steerSensitivity [i]);
					//}
				}


				GUI.skin = editorSkin;

				EditorGUILayout.BeginVertical("Box");
				EditorGUILayout.LabelField ("Transmission", editorSkin.customStyles [0]);
				EditorGUILayout.EndVertical();
				RTS_PlayerPrefs.playableVehicles.manual = EditorGUILayout.Toggle ("Manual Shifting", RTS_PlayerPrefs.playableVehicles.manual);
				if (RTS_PlayerPrefs.playableVehicles.manual) {
					RTS_PlayerPrefs.SetTransmission ("Manual");
				} else {
					RTS_PlayerPrefs.SetTransmission ("Auto");
				}

				EditorGUILayout.BeginVertical("Box");
				EditorGUILayout.LabelField ("Render Textures & Graphics", editorSkin.customStyles [0]);
				EditorGUILayout.EndVertical();
				EditorGUILayout.LabelField ("Location:  Assets/FYP/Fyp Project/Render Textures", EditorStyles.wordWrappedMiniLabel);
				EditorGUILayout.Space ();
				RTS_PlayerPrefs.playableVehicles.rearMirror = EditorGUILayout.Toggle ("Rear View Mirror", RTS_PlayerPrefs.playableVehicles.rearMirror);
				RTS_PlayerPrefs.playableVehicles.sideMirrors = EditorGUILayout.Toggle ("Side View Mirrors", RTS_PlayerPrefs.playableVehicles.sideMirrors);
				RTS_PlayerPrefs.playableVehicles.reflectionProbe = EditorGUILayout.Toggle ("Reflection Probe", RTS_PlayerPrefs.playableVehicles.reflectionProbe);

				EditorGUILayout.BeginVertical("Box");
				EditorGUILayout.LabelField ("Mini Map", editorSkin.customStyles [0]);
				EditorGUILayout.EndVertical();
				RTS_PlayerPrefs.playableVehicles.fixedMiniMapRotation = EditorGUILayout.Toggle ("Fixed Rotation", RTS_PlayerPrefs.playableVehicles.fixedMiniMapRotation);

				EditorGUILayout.BeginVertical ("Box");
				EditorGUILayout.LabelField ("Starting Currency", editorSkin.customStyles [0]);
				EditorGUILayout.EndVertical ();
				RTS_PlayerPrefs.playableVehicles.startingCurrency = EditorGUILayout.IntField ("Starting Currency", RTS_PlayerPrefs.playableVehicles.startingCurrency);
				EditorGUILayout.BeginVertical ("Box");
				EditorGUILayout.LabelField ("Upgrades & Customization", editorSkin.customStyles [0]);
				EditorGUILayout.EndVertical ();
				RTS_PlayerPrefs.playableVehicles.paintPrice = EditorGUILayout.IntField ("Body Paint", RTS_PlayerPrefs.playableVehicles.paintPrice);
				RTS_PlayerPrefs.playableVehicles.brakeColorPrice = EditorGUILayout.IntField ("Brake Color", RTS_PlayerPrefs.playableVehicles.brakeColorPrice);
				RTS_PlayerPrefs.playableVehicles.rimColorPrice = EditorGUILayout.IntField ("Rim Color", RTS_PlayerPrefs.playableVehicles.rimColorPrice);
				RTS_PlayerPrefs.playableVehicles.glassColorPrice = EditorGUILayout.IntField ("Glass Tint", RTS_PlayerPrefs.playableVehicles.glassColorPrice);
				RTS_PlayerPrefs.playableVehicles.glowPrice = EditorGUILayout.IntField ("Neon Light", RTS_PlayerPrefs.playableVehicles.glowPrice);
				RTS_PlayerPrefs.playableVehicles.upgradeSpeedPrice = EditorGUILayout.IntField ("Upgrade Speed", RTS_PlayerPrefs.playableVehicles.upgradeSpeedPrice);
				RTS_PlayerPrefs.playableVehicles.upgradeAccelerationPrice = EditorGUILayout.IntField ("Upgrade Acceleration", RTS_PlayerPrefs.playableVehicles.upgradeAccelerationPrice);
				RTS_PlayerPrefs.playableVehicles.upgradeBrakesPrice = EditorGUILayout.IntField ("Upgrade Brakes", RTS_PlayerPrefs.playableVehicles.upgradeBrakesPrice);
				RTS_PlayerPrefs.playableVehicles.upgradeTiresPrice = EditorGUILayout.IntField ("Upgrade Tires", RTS_PlayerPrefs.playableVehicles.upgradeTiresPrice);
				RTS_PlayerPrefs.playableVehicles.upgradeSteeringPrice = EditorGUILayout.IntField ("Upgrade Steering", RTS_PlayerPrefs.playableVehicles.upgradeSteeringPrice);
				EditorGUILayout.BeginVertical ("Box");
				EditorGUILayout.LabelField ("EVP Support", editorSkin.customStyles [0]);
				EditorGUILayout.EndVertical ();
				RTS_PlayerPrefs.playableVehicles.EVPSupport = EditorGUILayout.Toggle ("EVP Support", RTS_PlayerPrefs.playableVehicles.EVPSupport);
				if (RTS_PlayerPrefs.playableVehicles.EVPSupport) {
					PlayerSettings.SetScriptingDefineSymbolsForGroup (EditorUserBuildSettings.selectedBuildTargetGroup, "CROSS_PLATFORM_INPUT;EVP_SUPPORT");
				} else {
					PlayerSettings.SetScriptingDefineSymbolsForGroup (EditorUserBuildSettings.selectedBuildTargetGroup, "CROSS_PLATFORM_INPUT;");
				}
			}
			EditorUtility.SetDirty (RTS_PlayerPrefs.playableVehicles);
		}
/// PlayerPrefs Settings
		if(playerPrefsSettings){
			EditorGUILayout.BeginVertical("Box");
			EditorGUILayout.LabelField ("PlayerPrefs Settings", editorSkin.customStyles [0]);
			EditorGUILayout.EndVertical();
			if (GUILayout.Button ("Delete PlayerPrefs Data", GUILayout.Height(40))) {
				GUIUtility.hotControl = 0;
				GUIUtility.keyboardControl = 0;
				DeleteAllPlayerPrefsData ();
			}
		}
/// Project Settings
		if(debugSettings){
			EditorGUILayout.BeginVertical("Box");
			EditorGUILayout.LabelField ("Debug Settings", editorSkin.customStyles [0]);
			EditorGUILayout.EndVertical();

			RTS_PlayerPrefs.debugData.launchWindow = EditorGUILayout.Toggle("Project Launch Window", RTS_PlayerPrefs.debugData.launchWindow);
			RTS_PlayerPrefs.debugData.projectVersion = EditorGUILayout.TextField ("Project Version", RTS_PlayerPrefs.debugData.projectVersion);
			RTS_PlayerPrefs.debugData.tutorialURL = EditorGUILayout.TextField ("Tutorial URL", RTS_PlayerPrefs.debugData.tutorialURL);
			RTS_PlayerPrefs.debugData.supportURL = EditorGUILayout.TextField ("Support URL", RTS_PlayerPrefs.debugData.supportURL);
			RTS_PlayerPrefs.debugData.documentationURL = EditorGUILayout.TextField ("Documentation URL", RTS_PlayerPrefs.debugData.documentationURL);
			EditorUtility.SetDirty (RTS_PlayerPrefs.debugData);
		}
		EditorGUILayout.EndScrollView ();
		Repaint ();
	}

	void DeleteAllPlayerPrefsData(){
		if (EditorUtility.DisplayDialog ("Fyp Project", "Are you sure you want to delete all PlayerPrefs?", "Yes", "No")) {
			for(int i = 1; i < RTS_PlayerPrefs.playableVehicles.numberOfCars; i ++){
				RTS_PlayerPrefs.playableVehicles.carUnlocked [i] = false;
			}
			PlayerPrefs.DeleteAll ();
			Debug.Log ("Deleted PlayerPrefs Data");
		}
	}


}