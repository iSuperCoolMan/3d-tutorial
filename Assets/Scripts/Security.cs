using System.Collections;
using UnityEngine;

public class Security : MonoBehaviour
{
    [SerializeField] private Rogue _rogue;
    [SerializeField] private Signaling _speakerSignalling;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Rogue>() == _rogue)
            _speakerSignalling.FadeIn();
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.GetComponent<Rogue>() == _rogue)
            _speakerSignalling.FadeOut();
    }
}
