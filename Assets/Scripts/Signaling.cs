using System;
using System.Collections;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeChangeSpeed;
    [SerializeField][Range(0f, 1f)] private float _minVolume;
    [SerializeField][Range(0f, 1f)] private float _maxVolume;

    public IEnumerator FadeIn()
    {
        _audioSource.Play();

        while (_audioSource.volume < _maxVolume)
        {
            MoveVolumeTowards(_maxVolume);
            yield return null;
        }
    }

    public IEnumerator FadeOut()
    {
        while (_audioSource.volume > _minVolume)
        {
            MoveVolumeTowards(_minVolume);
            yield return null;
        }

        _audioSource.Stop();
    }

    private void OnValidate()
    {
        if (_minVolume >= _maxVolume)
            _minVolume = _maxVolume;
    }

    private void Start()
    {
        _audioSource.Stop();
        _audioSource.volume = _minVolume;
    }

    private void MoveVolumeTowards(float target)
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _volumeChangeSpeed * Time.deltaTime);
    }
}
