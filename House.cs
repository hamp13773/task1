using System.Collections;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public bool IsEnter { get; private set; }

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
        IsEnter = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            IsEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsEnter = false;
    }
}
