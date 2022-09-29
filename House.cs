using System.Collections;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Alarm _alarm;
    private readonly float _minVolume = 0;
    private readonly float _maxVolume = 1;

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        _alarm = GetComponent<Alarm>();
        _audioSource.Play();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            StartCoroutine(_alarm.ChangeVolume(_maxVolume));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine(_alarm.ChangeVolume(_maxVolume));
        StartCoroutine(_alarm.ChangeVolume(_minVolume));
    }
}
