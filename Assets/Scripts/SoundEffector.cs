using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffector : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _slotSound, _winSound;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySlotSound()
    {
        _audioSource.PlayOneShot(_slotSound);

    }
    public void PlayWinSound()
    {
        _audioSource.PlayOneShot(_winSound);

    }
}
