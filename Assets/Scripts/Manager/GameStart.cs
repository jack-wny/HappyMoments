using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour
{
	public SoundControllder _soundController ;
	public void  ClickPlay(){
		DataManager.getInstance ().IsStart = true;
		Destroy (gameObject);
	}

	public void ClickSoundButton(){
		_soundController.PlayBgSound ();
	}

	public void ShareButton(){

	}
}

