using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSituation : MonoBehaviour
{
    public bool valid = false;
    public bool pBall = false;
    public bool eBall = false;
    Rigidbody _rb;
    [SerializeField] float _up = 1;
    [SerializeField] float _power = 1;

    // Start is called before the first frame update
    void Start()
    {
        valid = false;
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BallMove(Vector3 forward)
    {
        _rb.AddForce((forward + Vector3.up / _up) * _power,ForceMode.Impulse);
    }

    public void ParentNull()
    {
        this.transform.parent = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            valid = false;
            pBall = false;
            eBall = false;
        }
    }
}
