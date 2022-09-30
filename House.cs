using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class House : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }
}