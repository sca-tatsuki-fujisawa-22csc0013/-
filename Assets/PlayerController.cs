using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float Speed = 1;
    [SerializeField] float JumpForce = 50;
    private Rigidbody rb;
    int jumpCount = 0;
    [SerializeField] float _rSpeed;
    [SerializeField] float _mSpeed;
    bool setRot;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        setRot = false;
    }

    // Update is called once per frame
    void Update()
    {
        var hInput = Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");
        Vector3 mVec = new Vector3(hInput, 0, vInput);
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = transform.forward * Mathf.Abs(vInput) * _mSpeed;
        }
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    rb.velocity = transform.forward * vInput * _mSpeed;
        //}

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (!setRot)
            {
                setRot = true;
                transform.Rotate(new Vector3(0, 180, 0), Space.World);
            }
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            setRot = false;
        }
        //else if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    if (setRot)
        //    {
        //        setRot = false;
        //        transform.Rotate(new Vector3(0, 180, 0), Space.World);
        //    }
        //}

        if (Input.GetKey(KeyCode.RightArrow))
        {
            CharaMove(hInput);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            CharaMove(hInput);
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            rb.AddForce(0, JumpForce, 0, ForceMode.Force);
            ++jumpCount;
        }
    }

    void CharaMove(float hInput)
    {
        if (setRot)
        {
            hInput = -hInput;
        }
        transform.Rotate(new Vector3(0, 1, 0) * hInput * _rSpeed, Space.World);
    }

    void ChangeRotate(float r)
    {
        Vector3 rot = transform.eulerAngles;
        rot.y = r;
        transform.eulerAngles = rot;
    }

    private void OnCollisionEnter(Collision collision)
    {
        jumpCount = 0;
    }
}
