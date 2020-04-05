using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "ScriptableObjects/AudioCueEvent")]
public class AudioCueEvent : AudioCue
{
	public AudioClip[] clips;

	public float volume;

	public float pitch;

	public bool randomPitch = false;

	public bool loop = false;

	public override void Play(AudioSource source)
	{
		if(clips.Length == 0)
		{
			return;
		}

		source.clip = clips[Random.Range(0, clips.Length)];
		source.volume = volume;
		if(randomPitch)
		{
			source.pitch = Random.Range(0.8f, 1.2f);
		}
		else
		{
			source.pitch = pitch;
		}
		source.loop = loop;
		source.Play();
	}
}