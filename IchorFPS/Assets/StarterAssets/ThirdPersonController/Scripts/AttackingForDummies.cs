using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackingForDummies : MonoBehaviour
{
    private Animator anim;
    private Animator anim1;
    public float cooldownTime = 2f;
    private float nextFireTime = 0f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 0.7f;
    private float normalizedTimeThing = 0.5f;
    public bool canMove = true;
    public bool PlayerIsAttacking = false;
    private bool mustDeflect = false;
    private bool mustEnemyDeflect = false;
    
    public EnemyFollow ef;
    GameObject enemy;

    public AudioSource source;
    public AudioClip swing;
    public AudioClip deflectSound;
    [Range(0, 1)] public float SwingAudioVolume = 0.5f;
    private CharacterController controller;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        enemy = GameObject.FindWithTag("Enemy");
        anim = GetComponent<Animator>();
        anim1 = enemy.GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Debug.Log("can move: "+canMove);
        if(ef.mustEnemyDeflect && mustDeflect){
            anim.SetTrigger("Deflect");
            anim1.SetTrigger("Deflect");
            //source.clip = deflectSound;
            source.PlayOneShot(deflectSound, 0.8f);
            Debug.Log("Clash");
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > normalizedTimeThing && anim.GetCurrentAnimatorStateInfo(0).IsName("hit1") && noOfClicks == 0)
        {
            PlayerIsAttacking = false;
            //Debug.Log("First Click No: "+ noOfClicks);
            noOfClicks = 0;
            anim.SetInteger("clicks", noOfClicks);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > normalizedTimeThing && anim.GetCurrentAnimatorStateInfo(0).IsName("hit2") && noOfClicks == 1)
        {
            PlayerIsAttacking = false;
            //Debug.Log("Second Click No: "+ noOfClicks);
            noOfClicks = 0;
            anim.SetInteger("clicks", noOfClicks);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > normalizedTimeThing && anim.GetCurrentAnimatorStateInfo(0).IsName("hit3") && noOfClicks == 2)
        {
            PlayerIsAttacking = false;
            //Debug.Log("Third Click No: "+ noOfClicks);
            noOfClicks = 0;
            anim.SetInteger("clicks", noOfClicks);
        }
 
        if (Time.time - lastClickedTime > maxComboDelay)
        {
            PlayerIsAttacking = false;
            noOfClicks = 0;
            anim.SetInteger("clicks", noOfClicks);
        }
 
        //cooldown time
        if (Time.time > nextFireTime)
        {
            // Check for mouse input
            if (Input.GetMouseButtonDown(0))
            {
                OnClick();
 
            }
        }
        // Debug.Log(PlayerIsAttacking);
    }
 
    void OnClick()
    {
        //so it looks at how many clicks have been made and if one animation has finished playing starts another one.
        //Debug.Log(anim.GetCurrentAnimatorStateInfo(0));
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("GotHit") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Dead")){
            
            if (noOfClicks == 0)
            {
                PlayerIsAttacking = true;
                lastClickedTime = Time.time;
                noOfClicks=1;
                anim.SetInteger("clicks", noOfClicks);
            }
            
            if (noOfClicks == 1 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.3f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
            {
                PlayerIsAttacking = true;
                lastClickedTime = Time.time;
                noOfClicks=2;
                anim.SetInteger("clicks", noOfClicks);
            }
            if (noOfClicks == 2 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.1f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
            {
                PlayerIsAttacking = true;
                lastClickedTime = Time.time;
                noOfClicks=3;
                anim.SetInteger("clicks", noOfClicks);
            }
        }
    }
    private void attack1(AnimationEvent animationEvent){
        if (animationEvent.animatorClipInfo.weight > 0.5f)
		{
			AudioSource.PlayClipAtPoint(swing,transform.TransformPoint(controller.center), SwingAudioVolume);
		}
    }
    private void attack2(AnimationEvent animationEvent){
        if (animationEvent.animatorClipInfo.weight > 0.5f)
		{
			AudioSource.PlayClipAtPoint(swing,transform.TransformPoint(controller.center), SwingAudioVolume);
		}
    }
    private void attack3(AnimationEvent animationEvent){
        if (animationEvent.animatorClipInfo.weight > 0.5f)
		{
			AudioSource.PlayClipAtPoint(swing,transform.TransformPoint(controller.center), SwingAudioVolume);
		}
    }
    private void shouldDeflect(AnimationEvent animationEvent){
        mustDeflect = true;
    }
    private void shouldNotDeflect(AnimationEvent animationEvent){
        mustDeflect = false;
    }
    
}