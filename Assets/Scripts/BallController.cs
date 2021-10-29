using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    [SerializeField]
    private GameManager _gameManager;
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
        var collidingObject = contact.otherCollider.gameObject;
        Debug.Log("COLLISION " + collidingObject.name);
        if (collidingObject.name == "LoseWall")
        {
            _gameManager.Loose();
        }
        else if (collidingObject.name.Contains("Cube"))
        {
            _rigidBody.velocity = Vector3.Reflect(_oldVelocity, contact.normal);
            collidingObject.SetActive(false);
            _gameManager.CheckWin();
        }
        else
        {
            _rigidBody.velocity = Vector3.Reflect(_oldVelocity, contact.normal);
        }
    }
}
