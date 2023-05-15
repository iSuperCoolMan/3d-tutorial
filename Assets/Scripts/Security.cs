using System.Collections;
using UnityEngine;

public class Security : MonoBehaviour
{
    [SerializeField] private Rogue _rogue;
    [SerializeField] private GameObject _speaker;

    private IEnumerator _fadeInCoroutine;
    private IEnumerator _fadeOutCoroutine;

    private void Start()
    {
        _fadeInCoroutine = _speaker.GetComponent<Signaling>().FadeIn();
        _fadeOutCoroutine = _speaker.GetComponent<Signaling>().FadeOut();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision == _rogue.GetComponent<Collider>())
        {
            StopCoroutine(_fadeOutCoroutine);
            StartCoroutine(_fadeInCoroutine);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision == _rogue.GetComponent<Collider>())
        {
            StopCoroutine(_fadeInCoroutine);
            StartCoroutine(_fadeOutCoroutine);
        }
    }
}
