using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    GameObject Fade;
    Image FadeImage;
    [SerializeField] PlayerManager _pManage;
    [SerializeField] NPCManager _eManage;
    bool play = true;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        Fade = GameObject.Find("fade");
        FadeImage = Fade.GetComponent<Image>();
        FadeImage.DOFade(0.0f, 0.5f)
                 .SetUpdate(UpdateType.Normal,true)
                 .OnComplete(FadeEnd);
    }

    // Update is called once per frame
    void Update()
    {
        if (_pManage.pLife == 0 || _eManage.eLife == 0)
        {
            if (play)
            {
                play = false;
                StartCoroutine(GameEnd());
            }
        }
    }

    void FadeEnd()
    {
        Fade.SetActive(false);
        Time.timeScale = 1;
    }

    IEnumerator GameEnd()
    {
        Fade.SetActive(true);
        FadeImage.DOFade(1.0f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("TitleScene");
    }
}
