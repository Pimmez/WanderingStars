using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class UIButtonSoundEffect : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
	public AudioCueEvent hoverSound;
	public AudioCueEvent clickSound;
	public AudioSource source;

	public void OnPointerEnter(PointerEventData ped)
	{
		hoverSound.Play(source);
	}

	public void OnPointerDown(PointerEventData ped)
	{
		clickSound.Play(source);
	}
}
