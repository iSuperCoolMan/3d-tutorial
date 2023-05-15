using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rogue : MonoBehaviour
{
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _speed;

    private Vector3[] _positions;
    private int _index;

    private void Start()
    {
        _positions = new Vector3[] { _endPoint.position, transform.position };
        _index = 0;
    }

    private void Update()
    {
        if (_index < _positions.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, _positions[_index], _speed * Time.deltaTime);
        
            if (transform.position == _positions[_index])
                _index++;
        }
    }
}
