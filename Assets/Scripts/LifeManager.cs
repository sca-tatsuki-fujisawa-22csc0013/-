using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    [SerializeField] Sprite DecLifeImage;
    [SerializeField] Image[] Life;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LifeDown(int life)
    {
        Life[life].sprite = DecLifeImage;
    }
}
