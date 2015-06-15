using UnityEngine;
using System.Collections;

public class SoundControllder : MonoBehaviour
{

	private AudioSource _audioSouce ;
	public void Start(){
		_audioSouce = gameObject.GetComponent<AudioSource>();
		_audioSouce.Stop ();

	}
 	
	public void PlayBgSound(){
		_audioSouce.Play ();
	}

}

