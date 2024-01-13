using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitNPC : MonoBehaviour
{
    [SerializeField] NPCManager _nManager;
    public bool hit = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ball" && _nManager.haveBall != true)
        {
            hit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            hit = false;
        }
    }
}
