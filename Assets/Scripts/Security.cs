using System.Collections;
using UnityEngine;

public class Security : MonoBehaviour
{
    [SerializeField] private Rogue _rogue;
    [SerializeField] private Signaling _speakerSignalling;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision == _rogue.GetComponent<Collider>())
            _speakerSignalling.FadeIn();
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision == _rogue.GetComponent<Collider>())
            _speakerSignalling.FadeOut();
    }
}
