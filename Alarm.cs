using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    private readonly float recoveryRate = 0.0002f;
    private readonly float _minVolume = 0;
    private readonly float _maxVolume = 1;
    private Coroutine _increaseVolume;
    private Coroutine _decreaseVolume;

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            StartCoroutine(ChangeVolume(_maxVolume));

            if (_increaseVolume != null)
            {
                StopCoroutine(_increaseVolume);
                _increaseVolume = StartCoroutine(ChangeVolume(_maxVolume));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(ChangeVolume(_minVolume));

        if (_decreaseVolume != null)
        {
            StopCoroutine(_decreaseVolume);
            _decreaseVolume = StartCoroutine(ChangeVolume(_minVolume));
        }
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