using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class House : MonoBehaviour
{
    private readonly float recoveryRate = 0.2f;
    private readonly float _minVolume = 0;
    private readonly float _maxVolume = 1;
    private bool _isProvoke = false;

    private AudioSource _audioSource;

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }

    private void Update()
    {
        if (_isProvoke)
        {
            StartCoroutine(RaiseVolume());
        }

        else
        {
            StartCoroutine(MinimaseVolume());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            _isProvoke = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isProvoke = false;
    }

    private IEnumerator MinimaseVolume()
    {
        StopCoroutine(RaiseVolume());
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minVolume, recoveryRate * Time.deltaTime);
        yield return null;
    }

    private IEnumerator RaiseVolume()
    {
        StopCoroutine(MinimaseVolume());
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, recoveryRate * Time.deltaTime);
        yield return null;
    }
}
