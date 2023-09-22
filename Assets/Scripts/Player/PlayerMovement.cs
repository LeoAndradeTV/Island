using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _playerRb;

    private float _movementSpeed = 5;
    private float _turnSpeed = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerRb.velocity = PlayerInput.Instance.GetMovementInput() * _movementSpeed;
        transform.forward = Vector3.Slerp(transform.forward, _playerRb.velocity, Time.deltaTime * _turnSpeed);
    }
}
