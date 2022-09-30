using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    private House _house;
    private readonly float recoveryRate = 0.002f;
    private readonly float _minVolume = 0;
    private readonly float _maxVolume = 1;
    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        _house = GetComponent<House>();
    }

    private void Update()
    {
        if (_house.IsEnter == true)
        {
            StopCoroutine(ChangeVolume(_minVolume));
            StartCoroutine(ChangeVolume(_maxVolume));
        }

        else
        { 
            StopCoroutine(ChangeVolume(_maxVolume));
            StartCoroutine(ChangeVolume(_minVolume));
        }
    }

    private IEnumerator ChangeVolume(float volumeToChange)
    {
        while (_audioSource.volume != volumeToChange)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volumeToChange, recoveryRate * Time.deltaTime);
            yield return null;
        }
    }
}