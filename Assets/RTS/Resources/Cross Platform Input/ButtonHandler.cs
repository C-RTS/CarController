﻿using System;
using UnityEngine;

namespace FYP.ExtremeRacingRush.CrossPlatformInput.PlatformSpecific{
	public class ButtonHandler : MonoBehaviour{

		public string Name;

		public void SetDownState(){
			CrossPlatformInputManager.SetButtonDown(Name);
		}

		public void SetUpState(){
			CrossPlatformInputManager.SetButtonUp(Name);
		}

		public void SetAxisPositiveState(){
			CrossPlatformInputManager.SetAxisPositive(Name);
		}

		public void SetAxisNeutralState(){
			CrossPlatformInputManager.SetAxisZero(Name);
		}

		public void SetAxisNegativeState(){
			CrossPlatformInputManager.SetAxisNegative(Name);
		}
	}

}