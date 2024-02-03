using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TitleManager : MonoBehaviour
{
    
    [SerializeField] GameObject Fade;
    Image FadeImage;
    [SerializeField] AnimSample anim;
    [SerializeField] GameObject bgm;
    public static bool gameStart = false;

    void Start()
    {
        if (!gameStart)
        {
            gameStart = true;
            GameObject BGMOBJ = Instantiate(bgm);
            DontDestroyOnLoad(BGMOBJ);
        }
        FadeImage = Fade.GetComponent<Image>();
        FadeImage.DOFade(0.0f,0.5f).OnComplete(FadeEnd);
    }

    void FadeEnd()
    {
        Fade.SetActive(false);
        anim.SaluteAnim();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
