using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RTS_FadeTextureOut : MonoBehaviour {

	public float loadingTextUpdate = 0.25f;
	public string[] loadingTextString;
	public Text loadingText;
	public Image loadingBar;
	public Image backgroundImage;
	public GameObject loadingBarBackground;
	public float startDelay = 3.0f;
	//The higher the value the faster the texture will be faded out
	[Range(0.001f,1f)]public float fadeSpeed = 0.05f;
	private bool ISAlphaWait = true;
	private float alpha_amnt = 1.0f;
	private float loadingTextTimerForUpdate;
	private int index_count;
	Color fade__Color;


	void FadeTextureOut__ForLoading ( ) {

		ISAlphaWait = false;
		DestroyImmediate(loadingBarBackground);
		DestroyImmediate(loadingText);
		
	}

	void Update () {

		loadingTextTimerForUpdate += 1 * Time.deltaTime;

		if(Time.timeSinceLevelLoad <= startDelay){
			loadingBar.fillAmount = Time.timeSinceLevelLoad / startDelay * 1;
		}


		if (ISAlphaWait == false) {
			alpha_amnt += -1 * fadeSpeed * Time.deltaTime;
			fade__Color = backgroundImage.color;
			fade__Color.a = alpha_amnt;
			backgroundImage.color = fade__Color;
		}


		if(loadingText != null){
			if (Time.timeSinceLevelLoad >= startDelay) {
				FadeTextureOut__ForLoading ();
			}else if (loadingTextTimerForUpdate >= loadingTextUpdate) {
				loadingTextTimerForUpdate = 0.0f;
				index_count += 1;
				if (index_count < loadingTextString.Length) {				
					loadingText.text = loadingTextString [index_count];
				} else {
					index_count = 0;
					loadingText.text = loadingTextString [index_count];
				}
			}
		}


		if(alpha_amnt <= 0){
			DestroyImmediate (gameObject);
		}


	}

	

}
