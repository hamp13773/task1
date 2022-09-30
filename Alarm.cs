using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent (typeof(House))]

public class Alarm : MonoBehaviour
{
    private readonly float recoveryRate = 0.0002f;
    private AudioSource _audioSource;
    private Coroutine _increaseVolume;
    private Coroutine _decreaseVolume;
    private readonly float _minVolume = 0;
    private readonly float _maxVolume = 1;

    public void IncreaseVolume()
    {
        StartCoroutine(ChangeVolume(_maxVolume));

        if (_increaseVolume != null)
        {
            StopCoroutine(_increaseVolume);
            _increaseVolume = StartCoroutine(ChangeVolume(_maxVolume));
        }
    }

    public void DecreaseVolume()
    {
        StartCoroutine(ChangeVolume(_minVolume));

        if (_decreaseVolume != null)
        {
            StopCoroutine(_decreaseVolume);
            _decreaseVolume = StartCoroutine(ChangeVolume(_minVolume));
        }
    }

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, recoveryRate);
            yield return null;
        }
    }
}