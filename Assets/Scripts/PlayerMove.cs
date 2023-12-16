using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 60.0f;
    [SerializeField] private float speed = 1;
    private Vector3 _velocity;
    //private Vector2 inputVector;
    private Vector3 moveDirection;
    private Quaternion rotation = Quaternion.identity;
    Rigidbody rb;

    [SerializeField] private Animator animator;
    private bool isRunning = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue value)
    {
        var axis = value.Get<Vector2>();
        _velocity = new Vector3(axis.x, 0, axis.y);
        if (_velocity.x == 0 && _velocity.z == 0)
        {
            isRunning = false;
        }
        else
        {
            isRunning = true;
        }
        animator.SetBool("Running", isRunning);
    }

    private void Update()
    {
        moveDirection = new Vector3(_velocity.x, 0, _velocity.z);
        moveDirection.Normalize();
        var desiredForward = Vector3.RotateTowards(transform.forward, moveDirection, turnSpeed * Time.deltaTime, 0.0f);
        rotation = Quaternion.LookRotation(desiredForward);
        rb.MoveRotation(rotation);
        transform.position += _velocity * speed * Time.deltaTime;
        if(transform.position.z >= 0)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,0);
        }
    }
}
