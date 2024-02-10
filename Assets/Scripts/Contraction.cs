using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Contraction : MonoBehaviour
{
    [SerializeField] float toScale = 1.2f;
    [SerializeField] float toDuration = 0.3f;
    private Vector3 _originSize;

    private void Start()
    {
        _originSize = this.transform.localScale;
    }

    public void OnEnter()
    {
        transform.DOScale(Vector3.one * toScale, toDuration).SetLoops(-1, LoopType.Yoyo);
    }

    public void OnExit()
    {
        transform.DOKill();
        transform.DOScale(_originSize, 0);
    }
}
