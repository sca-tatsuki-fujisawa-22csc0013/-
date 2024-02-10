using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(new Vector3(0, 0, -5.0f), 2.0f)
                 .SetEase(Ease.InOutCubic)
                 .SetLoops(-1, LoopType.Yoyo);
    }
}
