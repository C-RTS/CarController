using UnityEngine;
using System.Collections;

namespace FYP.ExtremeRacingRush{
	public class RTS_DrawGizmos : MonoBehaviour {

		#region Public Variables
		public Color gizmoColor = Color.green;
		public Vector3 gizmoSize = new Vector3 (0.1401f, 0.1401f, 0.1401f);
		#endregion

		#region Main Methods	
		void OnDrawGizmos(){
			
			Gizmos.color = gizmoColor;
			Gizmos.matrix = transform.localToWorldMatrix;
			Gizmos.DrawWireCube (Vector3.zero, gizmoSize);
		}
		#endregion

	}
}