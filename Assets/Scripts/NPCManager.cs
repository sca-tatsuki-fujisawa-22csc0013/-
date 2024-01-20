using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public enum Anim
    {
        stop = 0,
        run,
        damage,
    }
    public Anim _anim = Anim.stop;
    public bool hitDamage = false;

    public bool haveBall = false;
    Vector3 offset = new Vector3(0, 0.6f, 0);
    [SerializeField] HitNPC _hitNpc;
    [SerializeField] BallSituation ballSituation;
    [SerializeField] GameObject _ball;
    Rigidbody _rb;
    SphereCollider _ballCol;
    [SerializeField] private Animator animator;
    private bool isRunning = false;

    //  音声の登録
    [SerializeField] private AudioClip VoiceDamage;     //  ダメージ音声
    [SerializeField] private AudioClip VoiceDown;       //  ダウン音声
    [SerializeField] private AudioClip VoiceSalute;     //  勝利音声
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _rb = _ball.GetComponent<Rigidbody>();
        _ballCol = _ball.GetComponent<SphereCollider>();
        _anim = Anim.stop;
    }

    public void OnMoveAnim()
    {
        switch (_anim)
        {
            case Anim.stop:
                isRunning = false;
                break;
            case Anim.run:
                isRunning = true;
                break;
        }
        animator.SetBool("Running", isRunning);
    }

    public void OnDamageAnim()
    {
        animator.SetTrigger("Damage");
        audioSource.PlayOneShot(VoiceDamage);
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
        int rand = Random.Range(0,2);
        switch (rand)
        {
            case 0:
                return;
            case 1:
                break;
        }
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
            //Invoke("slow", 0.5f);
            //}
        }
    }

    bool stop = false;
    public void slow()
    {
        if (!stop)
        {
            stop = true;
            ballSituation.ParentNull();
            _rb.isKinematic = false;
            _ballCol.isTrigger = false;
            ballSituation.BallMove(transform.forward);
            Invoke("HaveBall", 0.5f);
        }
    }

    void HaveBall()
    {
        stop = false;
        haveBall = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball" && haveBall == false && ballSituation.pBall == true)
        {
            //当たった時の判定
            hitDamage = true;
            OnDamageAnim();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            //当たった時の判定
            hitDamage = false;
        }
    }
}
