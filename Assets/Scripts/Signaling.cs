using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeChangeSpeed;

    private bool _isTargetInside;
    [SerializeField] [Range(0f, 1f)] private float _minVolume;
    [SerializeField] [Range(0f, 1f)] private float _maxVolume;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.name == _target.name)
        {
            _audioSource.volume = _minVolume;
            _audioSource.Play();
            _isTargetInside = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.name == _target.name)
        {
            _isTargetInside = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _isTargetInside = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_audioSource.isPlaying)
        {
            if (_isTargetInside)
            {
                if(_audioSource.volume < _maxVolume)
                    _audioSource.volume += _volumeChangeSpeed * Time.deltaTime;
            }
            else
            {
                _audioSource.volume -= _volumeChangeSpeed * Time.deltaTime;

                if (_audioSource.volume == _minVolume)
                    _audioSource.Stop();
            }
        }
    }
}
