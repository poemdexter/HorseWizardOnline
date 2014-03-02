using System;
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    public float RotateSpeed;
    private CharacterController _controller;
    private float _rotationX;
    private PlayerAnimation _playerAnimation;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal") * MovementSpeed * Time.deltaTime;
        var vertical = Input.GetAxis("Vertical") * MovementSpeed * Time.deltaTime;

        var forwardVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // get input

        if (Math.Abs(forwardVector.magnitude) < 0.1f)
            _playerAnimation.StopRun();
        else
            _playerAnimation.StartRun();

        // normalize vector so we have unit vector in direction of input
        if (forwardVector.magnitude > 1)
            forwardVector.Normalize();
        forwardVector *= MovementSpeed * Time.deltaTime; // set magnitude 

        _controller.SimpleMove(transform.TransformDirection(forwardVector));

        _rotationX += Input.GetAxis("Mouse X") * RotateSpeed * Time.deltaTime;
        _rotationX = _rotationX % 360;
        transform.eulerAngles = new Vector3(0, _rotationX, 0);
    }
}