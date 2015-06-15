using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
  public Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();
  public List<AudioSource> channels = new List<AudioSource>();
  public AudioSource currentBgm;
  public string currentBgmName;
 

  void Start()
  {
    StartCoroutine(InitCoroutine());
  }


  IEnumerator InitCoroutine()
  {
    AudioClip _clip;
    string[] _keys = new string[]{
      "B-10",
    };
    clips = new Dictionary<string, AudioClip>();
    foreach (string _key in _keys) {
      _clip = (AudioClip)Resources.Load(string.Format("Sound/{0}", _key));
      clips.Add(string.Format("sound/{0}", _key), _clip);
    }
	PlayBGM ("B-10");
    yield return null;
  }

  public void PlaySE(string _name, float _volume = 0.3f, float _pan = 0f, float _pitch = 1.0f)
  {
    if (!clips.ContainsKey(_name)) {
      Debug.Log("SE not found : " + _name);
      return;
    }
    AudioClip _clip = clips[_name];
    DestroyStoppedSounds();
    if (IsDuplicateClip(_clip)) return;

    AudioSource _channel = gameObject.AddComponent<AudioSource>();
    _channel.clip   = _clip;
    _channel.volume = _volume;
	_channel.panStereo    = _pan;
	_channel.spatialBlend = _pan;
    _channel.loop   = false;
    _channel.pitch  = _pitch;
    _channel.Play();
    channels.Add(_channel);
  }

  public void PlaySELoop(string _name, int _count = 1, float _volume = 0.3f, float _pan = 0f, float _pitch = 1.0f)
  {
    StartCoroutine(PlaySELoopCoroutine(_name, _count, _volume, _pan, _pitch));
  }

  private IEnumerator PlaySELoopCoroutine(string _name, int _count = 1, float _volume = 0.3f, float _pan = 0f, float _pitch = 1.0f)
  {
    if (!clips.ContainsKey(_name)) {
      yield break;
    }
    AudioClip _clip = clips[_name];
    DestroyStoppedSounds();
    if (IsDuplicateClip(_clip)) yield break;

    AudioSource _channel = gameObject.AddComponent<AudioSource>();
    _channel.clip   = _clip;
    _channel.volume = _volume;
		_channel.panStereo    = _pan;
		_channel.spatialBlend = _pan;
    _channel.loop   = false;
    _channel.pitch  = _pitch;
    while (_count > 0) {
      _channel.Play();
      while (_channel.isPlaying) {yield return false;}
      _count--;
    }
    channels.Add(_channel);
  }

  public bool PlayBGM(string _name, bool _loop = true, float _volume = 0.7f, float _pan = 0f, float _pitch = 1f)
  {
    if (currentBgmName == _name) {return true;}

	AudioClip _clip=null;
    if (clips.ContainsKey(_name)) 
	{
		_clip = clips[_name];
    } 
	if (_clip == null) {
      return false;
    }
    if (currentBgm != null) {
      StopBGM();
    }
    currentBgmName = _name;

    currentBgm = gameObject.AddComponent<AudioSource>();
		currentBgm.clip   = _clip;
    currentBgm.volume = _volume;
	currentBgm.panStereo    = _pan;
	currentBgm.spatialBlend = _pan;
    currentBgm.loop   = _loop;
    currentBgm.pitch  = _pitch;
    currentBgm.Play();
    return true;
  }

  public IEnumerator PlayBGMCoroutine(string _name, bool _loop = true, float _volume = 0.7f, float _pan = 0f, float _pitch = 1f)
  {
    while (!PlayBGM(_name, _loop, _volume, _pan, _pitch)) {
      yield return new WaitForSeconds(0.1f);
    }
  }

  public void StopBGM()
  {
    if (!currentBgm) return;
    currentBgm.Stop();
    Destroy(currentBgm);
    currentBgmName = null;
  }

  public void DestroyStoppedSounds()
  {
    for (int i = 0; i < channels.Count; i++) {
      if (channels[i].isPlaying) continue;
      AudioSource _channel = channels[i];
      channels.Remove(_channel);
      _channel.Stop();
      Destroy(_channel);
    }
  }

  public bool IsDuplicateClip(AudioClip clip)
  {
    for (int i = 0; i < channels.Count; i++) {
      AudioSource _channel = channels[i];
      if (!_channel.isPlaying) continue;
      if (_channel.time > 0.03f) continue;
      if (_channel.clip == clip) {
        return true;
      }
    }
    return false;
  }
}
