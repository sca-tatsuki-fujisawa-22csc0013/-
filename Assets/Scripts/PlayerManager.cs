using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public bool haveBall = false;
    Vector3 offset = new Vector3(0,0.6f,0);
    [SerializeField] HitObj _hitObj;
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
        if (_hitObj.hit == true && haveBall == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //ƒLƒƒƒbƒ`Žž‚Ì”»’è
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

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball" && haveBall == false && ballSituation.eBall == true)
        {
            //“–‚½‚Á‚½Žž‚Ì”»’è
        }
    }
}
