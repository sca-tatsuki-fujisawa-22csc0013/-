using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject Ball;
    bool haveBall = false;
    Vector3 offset = new Vector3(0,0.5f,0.2f);

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (haveBall)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject b = Instantiate(Ball,transform.position + offset,Quaternion.identity);
                Rigidbody rb = b.GetComponent<Rigidbody>();
                //rb.AddForce();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
