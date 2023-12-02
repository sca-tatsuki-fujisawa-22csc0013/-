using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    //  NPC
    [SerializeField] private GameObject npc;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    //  [歩く]ボタン
    public void OnClick_WalkButton()
    {
        npc.GetComponent<AnimSample>().WalkAnim();
    }

    //  [走る]ボタン
    public void OnClick_RunButton()
    {
        npc.GetComponent<AnimSample>().RunAnim();
    }

    //  [ジャンプ]ボタン
    public void OnClick_JumpButton()
    {
        npc.GetComponent<AnimSample>().JumpAnim();
    }

    //  [ダメージ]ボタン
    public void OnClick_DamageButton()
    {
        npc.GetComponent<AnimSample>().DamageAnim();
    }

    //  [ダウン]ボタン
    public void OnClick_DownButton()
    {
        npc.GetComponent<AnimSample>().DownAnim();
    }

    //  [勝利ポーズ]ボタン
    public void OnClick_SaluteButton()
    {
        npc.GetComponent<AnimSample>().SaluteAnim();
    }
    
    //  [待機]ボタン
    public void OnClick_Idle()
    {
        npc.GetComponent<AnimSample>().IdleAnim();
    }
}
