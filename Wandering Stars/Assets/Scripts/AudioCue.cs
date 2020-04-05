using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AudioCue : ScriptableObject
{
	public abstract void Play(AudioSource source);
}