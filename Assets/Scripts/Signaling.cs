using System;
using System.Collections;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeChangeSpeed;
    [SerializeField][Range(0f, 1f)] private float _minVolume;
    [SerializeField][Range(0f, 1f)] private float _maxVolume;

    private Coroutine _fadeIn;
    private Coroutine _fadeOut;

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

    public void FadeIn()
    {
        if (_fadeOut != null)
        {
            StopCoroutine(_fadeOut);
            _fadeOut = null;
        }

        if (_fadeIn == null)
            _fadeIn = StartCoroutine(MoveVolumeTowards(_maxVolume));
    }

    public void FadeOut()
    {
        if (_fadeIn != null)
        {
            StopCoroutine(_fadeIn);
            _fadeIn = null;
        }

        if (_fadeOut == null)
            _fadeOut = StartCoroutine(MoveVolumeTowards(_minVolume));
    }

    private IEnumerator MoveVolumeTowards(float target)
    {
        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        while (_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }

        if (_audioSource.volume == _minVolume)
            _audioSource.Stop();
    }
}
