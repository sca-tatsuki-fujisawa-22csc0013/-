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
    [SerializeField] PlayerManager playerManager;
    //float hInput = 0;
    //float vInput = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var hInput = Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");
        if (playerManager.hitDamage)
        {
            hInput = 0;
            vInput = 0;
        }
        else
        {
            if (_velocity == Vector3.zero)
            {
                playerManager._anim = PlayerManager.Anim.stop;
            }
            else
            {
                playerManager._anim = PlayerManager.Anim.run;
            }
            playerManager.OnMoveAnim();
        }
        _velocity = new Vector3(hInput, 0, vInput);

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
