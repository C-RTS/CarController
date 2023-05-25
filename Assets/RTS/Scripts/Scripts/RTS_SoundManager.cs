using UnityEngine;
using System.Collections;

namespace FYP.ExtremeRacingRush{
	public class RTS_SoundManager : MonoBehaviour {

		private GameObject newGameobject;
		private GameObject audioContainer;
		private AudioSource raceMusic_AudioClip;


		public AudioClip blastSoundClip;
		public AudioSource AS_For_Others;


		static public RTS_SoundManager Instance;

        private void Awake ( ) {

			Instance = this;
        }

        void Start(){
			if (RTS_PlayerPrefs.GetAudio() == "ON") {
				AudioListener.pause = false;
			} else {
				AudioListener.pause = true;
			}

			audioContainer = new GameObject ();
			audioContainer.name = "Audio Container";
			AudioSound ();
		}

		void Update(){
			if (RTS_PlayerPrefs.audioData.music.Length > 0) {
				if (!raceMusic_AudioClip.isPlaying)
					PlayNextSoundTrack ();
			}
		}

		void AudioSound(){
			if (RTS_PlayerPrefs.audioData.music.Length > 0) {
				newGameobject = new GameObject ("Audio Clip: Music");
				newGameobject.transform.parent = audioContainer.transform;
				newGameobject.AddComponent<AudioSource> ();
				raceMusic_AudioClip = newGameobject.GetComponent<AudioSource> ();
				RTS_PlayerPrefs.audioData.currentAudioTrack = 0;
				raceMusic_AudioClip.clip = RTS_PlayerPrefs.audioData.music [RTS_PlayerPrefs.audioData.currentAudioTrack];
				raceMusic_AudioClip.loop = false;
				raceMusic_AudioClip.Play ();
			}
		}

		void PlayNextSoundTrack(){
			if (RTS_PlayerPrefs.audioData.musicSelection == AudioData.MusicSelection.ListOrder) {
				if (RTS_PlayerPrefs.audioData.currentAudioTrack < RTS_PlayerPrefs.audioData.music.Length - 1) {
					RTS_PlayerPrefs.audioData.currentAudioTrack += 1;
				} else {
					RTS_PlayerPrefs.audioData.currentAudioTrack = 0;
				}
			}else if(RTS_PlayerPrefs.audioData.musicSelection == AudioData.MusicSelection.Random){
				RTS_PlayerPrefs.audioData.currentAudioTrack = UnityEngine.Random.Range ( 0, RTS_PlayerPrefs.audioData.music.Length );
			}
			raceMusic_AudioClip.clip = RTS_PlayerPrefs.audioData.music [RTS_PlayerPrefs.audioData.currentAudioTrack];
			raceMusic_AudioClip.Play ();
		}

		public void playBlastSound ( ) {

			if (!AS_For_Others.isPlaying) {

				AS_For_Others.clip = blastSoundClip;
				AS_For_Others.Play();
			}
        }
		
	}
}