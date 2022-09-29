using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    private readonly float recoveryRate = 0.0002f;

    public IEnumerator ChangeVolume(float volumeToChange)
    {
        while (_audioSource.volume != volumeToChange)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volumeToChange, recoveryRate);
            yield return null;
        }
    }
}