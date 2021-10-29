using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidBody;
    private Vector3 _oldVelocity;

    void Start()
    {
        var forceVector = new Vector3(0.2f, 0.1f, 1f);
        _rigidBody.AddForce(forceVector * 500f);
    }

    void FixedUpdate()
    {
        _oldVelocity = _rigidBody.velocity;
    }

    private void OnCollisionEnter(Collision other)
    {
        var contact = other.contacts[0];
        _rigidBody.velocity = Vector3.Reflect(_oldVelocity, contact.normal);
    }
}
