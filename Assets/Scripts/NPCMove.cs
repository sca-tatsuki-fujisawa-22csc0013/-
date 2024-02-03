using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NPCMove : MonoBehaviour
{
    private float turnSpeed = 180.0f;
    private float speed = 5;
    private Vector3 _velocity;
    private Vector3 moveDirection;
    private Quaternion rotation = Quaternion.identity;
    Rigidbody rb;
    [SerializeField] private Animator animator;
    private bool isRunning = false;
    [SerializeField] Transform pPos;
    [SerializeField] NPCManager npcManager;
    bool hitWall = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (npcManager.haveBall == true)
        {
            transform.LookAt(pPos);
            _velocity = (pPos.position - transform.position).normalized;
            if (transform.position.z <= 0)
            {
                npcManager.Invoke("slow", 0.5f);
            }
        }
        //else if (npcManager.haveBall == false && npcManager.ballSituation.pBall == true)
        //{
        //    _velocity = (transform.position - pPos.position).normalized;
        //    if (hitWall)
        //    {
        //        if(pPos.position.x < transform.position.x)
        //        {
        //            _velocity.x = 1.0f;
        //        }
        //        else if(pPos.position.x > transform.position.x)
        //        {
        //            _velocity.x = -1.0f;
        //        }
        //    }
        //}

        //moveDirection = new Vector3(_velocity.x, 0, _velocity.z);
        //moveDirection.Normalize();
        //var desiredForward = Vector3.RotateTowards(transform.forward, moveDirection, turnSpeed * Time.deltaTime, 0.0f);
        //rotation = Quaternion.LookRotation(desiredForward);
        //rb.MoveRotation(rotation);
        //transform.position += _velocity * speed * Time.deltaTime;
        if (transform.position.z <= 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            hitWall = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            hitWall = false;
        }
    }
}
