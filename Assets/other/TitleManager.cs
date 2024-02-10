using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TitleManager : MonoBehaviour
{
    GameObject Fade;
    Image FadeImage;
    [SerializeField] AnimSample anim;
    [SerializeField] GameObject GameCanvas;
    public static bool gameStart = false;

    void Start()
    {
        if (!gameStart)
        {
            gameStart = true;
            GameObject gCanvas = Instantiate(GameCanvas);
            DontDestroyOnLoad(gCanvas);
        }
        Fade = GameObject.Find("fade");
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
        StartCoroutine(GameStartAnim());
    }

    IEnumerator GameStartAnim()
    {
        Fade.SetActive(true);
        FadeImage.DOFade(1.0f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MainScene");
    }
}
