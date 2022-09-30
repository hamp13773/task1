using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class House : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private UnityEvent _onTriggerStay;
    [SerializeField] private UnityEvent _onTriggerExit;

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            _onTriggerStay?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _onTriggerExit?.Invoke();
    }
}