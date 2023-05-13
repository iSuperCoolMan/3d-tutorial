using System.Collections;
using UnityEngine;

public class Security : MonoBehaviour
{
    [SerializeField] private Collider _targetCollider;
    [SerializeField] private GameObject _speaker;

    private IEnumerator _fadeInCoroutine;
    private IEnumerator _fadeOutCoroutine;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision == _targetCollider)
        {
            StopCoroutine(_fadeOutCoroutine);
            StartCoroutine(_fadeInCoroutine);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision == _targetCollider)
        {
            StopCoroutine(_fadeInCoroutine);
            StartCoroutine(_fadeOutCoroutine);
        }
    }

    private void Start()
    {
        _fadeInCoroutine = _speaker.GetComponent<Signaling>().FadeIn();
        _fadeOutCoroutine = _speaker.GetComponent<Signaling>().FadeOut();
    }
}
