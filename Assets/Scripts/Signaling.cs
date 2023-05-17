using System;
using System.Collections;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeChangeSpeed;
    [SerializeField][Range(0f, 1f)] private float _minVolume;
    [SerializeField][Range(0f, 1f)] private float _maxVolume;

    private Coroutine _fadeInCoroutine;
    private Coroutine _fadeOutCoroutine;

    private void OnValidate()
    {
        if (_minVolume >= _maxVolume)
            _minVolume = _maxVolume;
    }

    private void Start()
    {
        _audioSource.volume = _minVolume;
    }

    public void FadeIn()
    {
        _fadeInCoroutine = CoroutinesStateHandler(_maxVolume, _fadeInCoroutine, ref _fadeOutCoroutine);
    }

    public void FadeOut()
    {
        _fadeOutCoroutine = CoroutinesStateHandler(_minVolume, _fadeOutCoroutine, ref _fadeInCoroutine);
    }

    private Coroutine CoroutinesStateHandler(float volumeEndPoint, Coroutine coroutineForStart, ref Coroutine coroutineForStop)
    {
        if (coroutineForStop != null)
        {
            StopCoroutine(coroutineForStop);
            coroutineForStop = null;
        }

        if (coroutineForStart == null)
            coroutineForStart = StartCoroutine(MoveVolumeTowards(volumeEndPoint));

        return coroutineForStart;
    }

    private IEnumerator MoveVolumeTowards(float volumeEndPoint)
    {
        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        while (_audioSource.volume != volumeEndPoint)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volumeEndPoint, _volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }

        if (_audioSource.volume == _minVolume)
            _audioSource.Stop();
    }
}
