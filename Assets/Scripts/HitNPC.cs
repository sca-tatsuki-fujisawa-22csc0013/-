using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitNPC : MonoBehaviour
{
    [SerializeField] NPCManager _nManager;
    public bool hit = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball" && _nManager.haveBall != true)
        {
            hit = true;
            _nManager.Catch();
        }
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
