using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public enum Anim
    {
        stop = 0,
        run,
        damage,
    }
    public Anim _anim = Anim.stop;

    public bool haveBall = false;
    public bool hitDamage = false;
    Vector3 offset = new Vector3(0,0.6f,0);
    [SerializeField] HitObj _hitObj;
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

    public int pLife = 3;
    [SerializeField] LifeManager _lifeManager;

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
        pLife--;
        _lifeManager.LifeDown(pLife);
    }

    // Update is called once per frame
    void Update()
    {
        if (_hitObj.hit == true && haveBall == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //キャッチ時の判定
                ballSituation.pBall = true;
                ballSituation.valid = false;
                haveBall = true;
                _ball.transform.position = transform.position + offset + transform.forward * 0.3f;
                _rb.isKinematic = true;
                _ball.transform.parent = this.transform;
                _ballCol.isTrigger = true;
            }
        }
        else if (haveBall)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                haveBall = false;
                ballSituation.ParentNull();
                _rb.isKinematic = false;
                _ballCol.isTrigger = false;
                ballSituation.BallMove(transform.forward);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball" && haveBall == false && ballSituation.eBall == true)
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
