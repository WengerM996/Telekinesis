using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Levitate : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _forcePush;
    private float _explosionRadius = 50f;
    private float _offsetPush = 10f;

    private Rigidbody _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveUp();
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PushAway();
        }
    }

    private void MoveUp()
    {
        _rigidBody.AddForce(Vector3.up * _force, ForceMode.Impulse);
    }
    
    private void PushAway()
    {
        var pushPoint = transform.position;
        pushPoint.z -= _offsetPush;
        _rigidBody.AddExplosionForce(_forcePush, pushPoint, _explosionRadius, 0f, ForceMode.Impulse);
    }
}
