using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMovement : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private float _speed = 3f;

    private Vector2 _positionA;
    private Vector2 _positionB;
    private bool _movingToB = true;



    private void Start()
    {
        _positionA = _pointA.position;
        _positionB = _pointB.position;

    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 target = _movingToB ? _positionB : _positionA;
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target) <= 0.5f)
        {
           _movingToB =!_movingToB;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlatformerPlayer _))
        {
            PlatformerPlayer _player = other.gameObject.GetComponent<PlatformerPlayer>();
            _player.TakeDamage(3f);
        }
    }
}
