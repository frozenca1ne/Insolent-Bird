using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
	[SerializeField] private AudioSource audioSource;

	public void PlayEffect(AudioClip effect)
	{
		audioSource.PlayOneShot(effect);
	}
	public void MuteSound(bool value)
	{
		audioSource.mute = value;
	}
}
