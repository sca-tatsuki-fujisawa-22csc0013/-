using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Anim
{
    idle,
    walk,
    run,
    jump,
    damage,
    down,
    salute,
}

public class AnimSample : MonoBehaviour
{
    //  AnimationControllの登録
    [SerializeField] private Animator animator;
    
    //  音声の登録
    [SerializeField] private AudioClip VoiceDamage;     //  ダメージ音声
    [SerializeField] private AudioClip VoiceDown;       //  ダウン音声
    [SerializeField] private AudioClip VoiceSalute;     //  勝利音声

    private AudioSource audioSource;
    private bool isRunning = false;
    private bool isWalking = false;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    //  歩く・止まる
    public void WalkAnim()
    {
        isWalking = !isWalking;
        animator.SetBool("Walking", isWalking);
    }
    
    //  走る・止まる
    public void RunAnim()
    {
        isRunning = !isRunning;
        animator.SetBool("Running", isRunning);
    }
    
    //  ジャンプ
    public void JumpAnim()
    {
        animator.SetTrigger("Jumpping");
    }
    
    //  ダメージ
    public void DamageAnim()
    {
        animator.SetTrigger("Damage");
        audioSource.PlayOneShot(VoiceDamage);
    }
    
    //  ダウン
    public void DownAnim()
    {
        animator.SetTrigger("Down");
        audioSource.PlayOneShot(VoiceDown);
    }
    
    //  勝利ポーズ
    public void SaluteAnim()
    {
        animator.SetTrigger("Salute");
        audioSource.PlayOneShot(VoiceSalute);
    }
    
    //  待機
    public void IdleAnim()
    {
        animator.SetTrigger("Idle");
    }
}
