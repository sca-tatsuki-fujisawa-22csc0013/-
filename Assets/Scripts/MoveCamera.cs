using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject _player;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = _player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _player.transform.position - offset;
    }
}
