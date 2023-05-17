using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Security : MonoBehaviour
{
    [SerializeField] private UnityEvent _rogueEnter;
    [SerializeField] private UnityEvent _rogueExit;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Rogue _))
            _rogueEnter.Invoke();
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent(out Rogue _))
            _rogueExit.Invoke();
    }
}
