using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public bool haveBall = false;
    Vector3 offset = new Vector3(0, 0.6f, 0);
    [SerializeField] HitNPC _hitNpc;
    [SerializeField] BallSituation ballSituation;
    [SerializeField] GameObject _ball;
    Rigidbody _rb;
    SphereCollider _ballCol;

    void Start()
    {
        _rb = _ball.GetComponent<Rigidbody>();
        _ballCol = _ball.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (_hitNpc.hit == true && haveBall == false)
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        キャッチ時の判定
        //        ballSituation.eBall = true;
        //        ballSituation.valid = false;
        //        haveBall = true;
        //        _ball.transform.position = transform.position + offset + transform.forward * 0.3f;
        //        _rb.isKinematic = true;
        //        _ball.transform.parent = this.transform;
        //        _ballCol.isTrigger = true;
        //        Invoke("slow", 0.3f);
        //    }
        //}
        //else if (haveBall)
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        haveBall = false;
        //        ballSituation.ParentNull();
        //        _rb.isKinematic = false;
        //        _ballCol.isTrigger = false;
        //        ballSituation.BallMove(transform.forward);
        //    }
        //}

        switch (haveBall)
        {
            case true:
                //slow();
                break;
            case false:
                Catch();
                break;
        }
    }

    void Catch()
    {
        if (_hitNpc.hit == true && haveBall == false)
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //キャッチ時の判定
            ballSituation.eBall = true;
            ballSituation.valid = false;
            haveBall = true;
            _ball.transform.position = transform.position + offset + transform.forward * 0.3f;
            _rb.isKinematic = true;
            _ball.transform.parent = this.transform;
            _ballCol.isTrigger = true;
            Invoke("slow", 0.5f);
            //}
        }
    }


    void slow()
    {
        Invoke("HaveBall", 0.5f);
        ballSituation.ParentNull();
        _rb.isKinematic = false;
        _ballCol.isTrigger = false;
        ballSituation.BallMove(transform.forward);
    }

    void HaveBall()
    {
        haveBall = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball" && haveBall == false && ballSituation.pBall == true)
        {
            //当たった時の判定
        }
    }
}
