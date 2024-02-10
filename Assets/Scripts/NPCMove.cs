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
    [SerializeField] Transform ballPos;
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
            transform.position += transform.forward * Time.deltaTime * 5.0f;
            if (transform.position.z <= 0.5f)
            {
                npcManager.Invoke("slow", 0.5f);
            }
        }

        if (transform.position.z < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        if (transform.position.z < -1)
        {
            transform.position = new Vector3(transform.position.x, 0.3f, transform.position.z);
        }
    }

    public void NotHaveBall(bool pBall)
    {
        switch (pBall)
        {
            case false:
                transform.LookAt(ballPos.transform);
                break;
            case true:
                transform.LookAt(pPos.transform);
                transform.Rotate(new Vector3(0, transform.rotation.y - 180.0f, 0));
                break;
        }
        transform.position += transform.forward * Time.deltaTime * 5.0f;
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
