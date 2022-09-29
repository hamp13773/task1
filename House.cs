using System.Collections;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private readonly float _minVolume = 0;
    private readonly float _maxVolume = 1;
    private readonly float recoveryRate = 0.0002f;

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            StartCoroutine(ChangeVolume(_maxVolume));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine(ChangeVolume(_maxVolume));
        StartCoroutine(ChangeVolume(_minVolume));
    }

    public IEnumerator ChangeVolume(float volumeToChange)
    {
        while (_audioSource.volume != volumeToChange)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volumeToChange, recoveryRate);
            yield return null;
        }
    }
}
